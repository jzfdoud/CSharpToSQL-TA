﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToSQL_TA
{
    public class Student
    {

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StateCode { get; set; }
        public int SAT { get; set; }
        public decimal GPA { get; set; }
        public string Major { get; set; }
    }
}
