using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class TreeNode : TreeLeaf
    {
        public List<Item> Children { get; set; }
    }
}
