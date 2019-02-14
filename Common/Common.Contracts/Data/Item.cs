using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class Item : RequestBase
    {
        public int Id { get; set; }
        
        public string DisplayText { get; set; }

        public string Descriptions { get; set; }
    }
}
