using Microsoft.EntityFrameworkCore;
using VV.Interface;
using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VV.iService
{
    public class iStudent_Service : iStudent_Interface
    {
        private readonly VVDbContext _dbContext;
        private readonly iErrorLogging_Service _errorLoggingService;

        public iStudent_Service(VVDbContext dbContext, iErrorLogging_Service errorLoggingService)
        {
            _dbContext = dbContext;
            _errorLoggingService = errorLoggingService;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                return await _dbContext.Student.Where(s => s.IsDeleted == true).ToListAsync();
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(GetAllStudents), ex.StackTrace);
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await _dbContext.Student.FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == true);
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(GetStudentById), ex.StackTrace);
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                student.CreatedDate = DateTime.Now;
                await _dbContext.Student.AddAsync(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(AddStudent), ex.StackTrace);
                throw;
            }
        }

       


        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                var existingStudent = await _dbContext.Student.AsNoTracking().FirstOrDefaultAsync(s => s.Id == student.Id && s.IsDeleted == true);
                if (existingStudent == null)
                {
                    return null;
                }

                student.CreatedDate = existingStudent.CreatedDate; // original creation date
                student.UpdatedDate = DateTime.Now;

                _dbContext.Student.Update(student);
                await _dbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(UpdateStudent), ex.StackTrace);
                throw; // Optionally rethrow the exception
            }
        }

        public async Task<int> DeleteStudentById(int id)
        {
            try
            {
                var student = await _dbContext.Student.FirstOrDefaultAsync(s => s.Id == id);
                if (student == null)
                {
                    return 0; // Return 0 if the student is not found
                }

                // Set the IsDeleted flag to false
                student.IsDeleted = false;

                // Update the student record in the database
                _dbContext.Student.Update(student);
                await _dbContext.SaveChangesAsync();

                return student.Id; // Return the student's ID
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(DeleteStudentById), ex.StackTrace);
                throw; // Optionally rethrow the exception
            }
        }
    }
}
