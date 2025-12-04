using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Exceptions
{
    public abstract class NotFoundException(string message) : Exception(message)
    {

    }
}
