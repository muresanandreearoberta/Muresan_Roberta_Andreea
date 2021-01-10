﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muresan_Roberta_Andreea.Models
{
    public class MeniuCategory
    {
        public int ID { get; set; }
        public int MeniuID { get; set; }
        public Meniu Meniu { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
