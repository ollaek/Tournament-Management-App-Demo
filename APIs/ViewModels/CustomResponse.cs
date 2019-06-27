using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIs.ViewModels
{
    public class CustomResponse<T>
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T ReturnObject { get; set; }
    }
}