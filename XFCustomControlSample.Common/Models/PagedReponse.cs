using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    public class PagedReponse<T> : ResultPack<T>
    {
        public int TotalServerItems { get; set; }
    }
}
