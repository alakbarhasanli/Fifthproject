using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Exceptions
{
    public class BaseException:Exception
    {
        public BaseException(string message):base(message)
        {
            
        }
        public BaseException():base("Data Not Found")
        {
            
        }
    }
}
