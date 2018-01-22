using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Entities
{
    // Question Description
    [Table("Questions_tbl")]
    public class Question:EntityBase
    {
        [Required,StringLength(100)]
        public string QuestionTitle { get; set; }

        [Required,StringLength(1000)]
        public string QuestionText { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual List<QuestionAnswer> Questions { get; set; }
    }
}
