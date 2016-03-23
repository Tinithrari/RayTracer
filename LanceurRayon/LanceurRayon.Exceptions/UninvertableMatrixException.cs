using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Exceptions
{
    /// <summary>
    /// Exception appelée quand une matrice n'est pas inversible.
    /// </summary>
    public class UninvertableMatrixException : Exception
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public UninvertableMatrixException() : base("This matrix is not invertable !!!")
        {
            
        }
    }
}
