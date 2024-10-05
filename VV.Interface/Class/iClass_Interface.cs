using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VV.Interface
{
    public interface iClass_Interface
    {
        Task<Class> GetClassById(int id);
        Task<Class> AddClass(Class cls);
    }
}
