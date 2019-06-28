using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Helpers
{
    public class AutoGenerators
    {
        public string GenerateTag(int length)
        {
            string tag = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, length);
            return tag;
        }
    }
}