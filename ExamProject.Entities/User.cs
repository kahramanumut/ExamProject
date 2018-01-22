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
    [Table("User_tbl")]
    public class User:EntityBase
    {
        [DisplayName("Ad")]
        [StringLength(30)]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [StringLength(30)]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        [StringLength(20)]
        public string Username { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
