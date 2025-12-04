using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Exceptions
{
    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product with this Id : {id} is Not Found")
    {

    }
}
