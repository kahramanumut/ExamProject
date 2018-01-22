using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Entities
{
    [Table("QuestionAnswer_tbl")]
    public class QuestionAnswer:EntityBase
    {
        [DisplayName("Soru")]
        [Required]
        [StringLength(200), MinLength(5, ErrorMessage = "Soru {1} karakterden fazla olmalıdır"),
         MaxLength(200, ErrorMessage = "Soru {1} karakterden az olmalıdır.")]
        public string Question { get; set; }

        [DisplayName("1. Cevap")]
        [Required]
        [StringLength(50), MinLength(1, ErrorMessage ="Cevap {1} karakterden fazla olmalıdır"),
         MaxLength(50 , ErrorMessage = "Cevap {1} karakterden az olmalıdır")]
        public string FirstAnswer { get; set; }

        [DisplayName("2. Cevap")]
        [Required]
        [StringLength(50), MinLength(1, ErrorMessage = "Cevap {1} karakterden fazla olmalıdır"),
         MaxLength(50, ErrorMessage = "Cevap {1} karakterden az olmalıdır")]
        public string SecondAnswer { get; set; }

        [DisplayName("3. Cevap")]
        [Required]
        [StringLength(50), MinLength(1, ErrorMessage = "Cevap {1} karakterden fazla olmalıdır"),
         MaxLength(50, ErrorMessage = "Cevap {1} karakterden az olmalıdır")]
        public string ThirdAnswer { get; set; }

        [DisplayName("4. Cevap")]
        [Required]
        [StringLength(50), MinLength(1, ErrorMessage = "Cevap {1} karakterden fazla olmalıdır"),
         MaxLength(50, ErrorMessage = "Cevap {1} karakterden az olmalıdır")]
        public string FourthAnswer { get; set; }

        public int TrueAnswer { get; set; }
    }
}
