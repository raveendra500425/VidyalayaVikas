using System;
using System.ComponentModel.DataAnnotations;

namespace VV.ModelsEntity
{
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ErrorMessage { get; set; }

        [Required]
        public string MethodName { get; set; }

        public string StackTrace { get; set; }

        [Required]
        public DateTime ErrorDateTime { get; set; }
    }
}
