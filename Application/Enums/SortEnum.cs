using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum SortEnum
    {

        /// <summary>
        /// Default sorting (implementation-specific behavior).
        /// </summary>
        Default = 0,

        /// <summary>
        /// Sort by newest items first.
        /// </summary>
        New = 1,

        /// <summary>
        /// Sort by oldest items first.
        /// </summary>
        Old = 2
    }
}
