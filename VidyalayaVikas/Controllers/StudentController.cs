using Microsoft.AspNetCore.Mvc;
using VV.Interface;
using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VidyalayaVikas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly iStudent_Interface _studentInterface;

        public StudentController(iStudent_Interface studentInterface)
        {
            _studentInterface = studentInterface;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentInterface.GetAllStudents();
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentInterface.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Invalid data. Please check the input and try again."
                });
            }

            try
            {
                var createdStudent = await _studentInterface.AddStudent(student);
                return Ok(new
                {
                    Message = "Student saved successfully",
                    Student = createdStudent
                });
            }
            catch (Exception ex)
            {
                // If there's an error, return an appropriate message.
                return StatusCode(500, new
                {
                    Message = "An error occurred while saving the student.",
                    Error = ex.Message
                });
            }
        }


        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var updatedStudent = await _studentInterface.UpdateStudent(student);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentInterface.DeleteStudentById(id);
            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
