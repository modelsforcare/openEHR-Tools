using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.rm.datatypes
{
    public enum VALIDITY_KIND
    {
        /**
         * Constant to indicate mandatory presence of something.
         */
        MANDATORY,
        /**
         * Constant to indicate optional presence of something.
         */
        OPTIONAL,
        /**
         * Constant to indicate disallowed presence of something.
         */
        PROHIBITED
    }
}
