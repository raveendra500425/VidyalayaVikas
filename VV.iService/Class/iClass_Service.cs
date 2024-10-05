using Microsoft.EntityFrameworkCore;
using VV.Interface;
using VV.ModelsEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VV.iService
{
    public class iClass_Service : iClass_Interface
    {
        private readonly VVDbContext _dbContext;
        private readonly iErrorLogging_Service _errorLoggingService;

        public iClass_Service(VVDbContext dbContext, iErrorLogging_Service errorLoggingService)
        {
            _dbContext = dbContext;
            _errorLoggingService = errorLoggingService;
        }


        public async Task<Class> GetClassById(int id)
        {
            try
            {
                return await _dbContext.Class.FirstOrDefaultAsync(s => s.ClassId == id && s.isDeleted == true);
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(GetClassById), ex.StackTrace);
                throw; // Optionally rethrow the exception
            }
        }
        public async Task<Class> AddClass(Class cls)
        {
            try
            {
                await _dbContext.Class.AddAsync(cls);
                await _dbContext.SaveChangesAsync();
                return cls;
            }
            catch (Exception ex)
            {
                await _errorLoggingService.LogErrorAsync(ex.Message, nameof(AddClass), ex.StackTrace);
                throw;
            }
        }


    }
}
