using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Exceptions
{
    public sealed class UnauthorizedException(string msg = "InValid Email Or Password") 
                      : Exception(msg)
    {

    }
}
