using Microsoft.AspNetCore.Mvc;
using VV.Interface;
using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;
using VV.iService;

namespace VidyalayaVikas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClassController : Controller
    {
        private readonly iClass_Interface _classInterface;

        public ClassController(iClass_Interface classInterface)
        {
            _classInterface = classInterface;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var cls = await _classInterface.GetClassById(id);
            if (cls == null)
            {
                return NotFound();
            }
            return Ok(cls);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> AddClass(Class cls)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdclass = await _classInterface.AddClass(cls);
            return CreatedAtAction(nameof(GetClassById), new { classId = createdclass.ClassId }, createdclass);
        }

    }
}
