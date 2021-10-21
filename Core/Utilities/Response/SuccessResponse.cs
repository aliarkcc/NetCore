using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Response
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string message):base(true,message)
        {

        }
        public SuccessResponse():base(true)
        {

        }
    }
}
