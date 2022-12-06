using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Response
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
    }
    public class BaseResponseList<T>
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<T> Result { get; set; }
        public string Message { get; set; }
    }
}
