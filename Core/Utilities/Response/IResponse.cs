using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Response
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
