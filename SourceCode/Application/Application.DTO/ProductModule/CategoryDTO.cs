﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductModule
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int Order { get; set; }
        public int CategoryLevel { get; set; }
        public string CategoryImage { get; set; }
        //public int? CategoryParent { get; set; }
    }
}
