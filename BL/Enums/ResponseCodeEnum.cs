
using Castle.Components.DictionaryAdapter;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace BL.Enums
{
    public enum ResponseCodeEnum
    {
        [Description("Request Done Successfully")] Success = 1,
        [Description("An Error Occured")] Error = 2,
    }


  


}
