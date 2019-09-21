using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Common.ExceptionHandling
{
    public class POCException:Exception
    {
        public POCException():base()
        {

        }
        public POCException(string message):base(message)
        {

        }
        public POCException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
