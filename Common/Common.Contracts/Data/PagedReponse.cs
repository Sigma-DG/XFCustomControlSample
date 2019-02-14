using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class PagedReponse<T> : ResultPack<List<T>>
    {
        public int TotalServerItems { get; set; }
    }
}
