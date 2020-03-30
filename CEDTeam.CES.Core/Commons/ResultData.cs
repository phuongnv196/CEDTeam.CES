using System;
using System.Collections.Generic;
using System.Text;

namespace CEDTeam.CES.Core.Commons
{
    public class ResultData<T>
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public long ResultID { get; set; }
        public int ReturnValue { get; set; }
        public T Result { get; set; }
    }
}
