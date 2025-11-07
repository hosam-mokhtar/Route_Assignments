using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Contracts
{
    public interface IDataSeeding
    {
        //public void DataSeed();
        public Task DataSeedAsync();
    }
}
