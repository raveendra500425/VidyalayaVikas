using System;
using System.Threading.Tasks;
using VV.ModelsEntity;
using Microsoft.EntityFrameworkCore;

namespace VV.iService
{
    public class iErrorLogging_Service
    {
        private readonly VVDbContext _dbContext;

        public iErrorLogging_Service(VVDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task LogErrorAsync(string errorMessage, string methodName, string stackTrace)
        {
            var errorLog = new ErrorLog
            {
                ErrorMessage = errorMessage,
                MethodName = methodName,
                ErrorDateTime = DateTime.Now,
                StackTrace = stackTrace
            };

            await _dbContext.ErrorLogs.AddAsync(errorLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
