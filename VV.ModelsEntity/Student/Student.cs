using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VV.ModelsEntity
{
    public class Student
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
