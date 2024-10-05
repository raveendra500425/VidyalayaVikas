using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VV.Interface
{
    public interface iStudent_Interface
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<int> DeleteStudentById(int id);
    }
}
