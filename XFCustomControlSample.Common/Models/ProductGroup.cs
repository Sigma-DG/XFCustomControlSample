﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    public class ProductGroup : TreeNode
    {
        public Guid GroupId { get; set; }

        public string ImageUrl { get; set; }

        public int TotalItems { get; set; }

        public int NewItems { get; set; }
    }
}
