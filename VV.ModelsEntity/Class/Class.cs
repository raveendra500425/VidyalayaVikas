using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VV.ModelsEntity
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public string ClassName { get; set; }
        public string ClassDuration { get; set; }
        public string ClassPromotionCycle { get; set; }

        public string ClassTotalPromotion { get; set; }
        public bool isDeleted { get; set; }

    }
}
