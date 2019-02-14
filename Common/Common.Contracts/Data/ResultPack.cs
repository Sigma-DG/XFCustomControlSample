using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Contracts.Data
{
    public class ResultPack<T>
    {
        public ResultPack()
        {
            CreationDate = DateTimeOffset.Now;
        }

        public bool IsSucceeded { get; set; }

        public T ReturnParam { get; set; }

        public DateTimeOffset CreationDate { get; private set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string ErrorMetadata { get; set; }
    }
}
