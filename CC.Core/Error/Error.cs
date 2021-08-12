using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Core.Error
{
    public class Error
    {
        public Error(ErrorCode code)
            : this(code.GetDescription(), code)
        {        }

        public Error(string reason, ErrorCode errorCode)
        {
            Code = errorCode;
            Description = reason;
        }

        public ErrorCode Code { get; private set; }
        public string Description { get; private set; }
    }
}
