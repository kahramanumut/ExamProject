﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Entities
{
    public class EntityBase
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID { get; set; }
    }
}
