using System;
using System.Collections.Generic;
using System.Text;

namespace XFCustomControlSample.Common.Models
{
    public class RequestBase
    {
        public RequestBase()
        {
            UniqueRequestId = new Guid();
            CreationDate = DateTimeOffset.Now;
        }

        public Guid UniqueRequestId { get; private set; }

        public DateTimeOffset CreationDate { get; private set; }
    }
}
