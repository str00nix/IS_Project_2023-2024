﻿using AdminApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.Models
{
    public class Genre : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
