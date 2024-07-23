using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Shared
{
    public static class DevCode
    {
        public static bool IsNullOrEmpty(this string str) =>
            string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    }
}
