using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Exceptions
{
    public class UninvertableMatrixException : Exception
    {
        public UninvertableMatrixException() : base("This matrix is not invertable !!!")
        {
            
        }
    }
}
