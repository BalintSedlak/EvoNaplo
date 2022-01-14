using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNaplo.Infrastructure.GuardClauses
{
    /// <summary>
    /// An entry point to a set of Guard Clauses defined as extension methods on IGuardClause.
    /// </summary>
    public class Guard : IGuardClause
    {
        /// <summary>
        /// An entry point to a set of Guard Clauses.
        /// </summary>
        public static IGuardClause Against { get; private set; }

        private Guard() 
        {
            Against = new Guard();
        }
    }
}
