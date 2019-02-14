using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class TreeLeaf : Item
    {
        public Item Parent { get; set; }
    }
}
