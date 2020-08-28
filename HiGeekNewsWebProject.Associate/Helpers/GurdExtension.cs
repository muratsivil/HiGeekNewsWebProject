using System;
using System.Collections.Generic;
using System.Text;

namespace HiGeekNewsWebProject.Associate.Helpers
{
    public static class GurdExtension
    {
        public static void AgainstNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ApplicationException(parameterName);
            }
        }

        public static void AgainstFalse(bool condition, string parameterName)
        {
            if (!condition)
            {
                throw new ApplicationException(parameterName);
            }
        }
    }
}
