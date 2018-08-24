using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    public class TreeNode : TreeLeaf
    {
        public List<Item> Children { get; set; }
    }
}
