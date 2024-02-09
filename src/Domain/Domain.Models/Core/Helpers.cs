using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models.Core
{
    public static class Helpers
    {
        public static int ToInt(this Enum value)
        {
            return  Convert.ToInt32(value);
        }
        public static string ToT2D(this Enum value)
        {
            return $"{value.ToInt():00}";
        }
    }
}
