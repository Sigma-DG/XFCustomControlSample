using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    [DataContract]
    public class ImageList
    {
        [DataMember(Name = "photos")]
        public List<string> Photos = null;
    }
}
