using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toys.Data.Data;
using Toys.Data.Models;
using Toys.Data.Repositories;

namespace Toys.Data.Repositories
{
    public interface IToyRepository : IBaseRepository<Toy>
    {
    }

    public class ToyRepository : GenericRepository<Toy>, IToyRepository
    {
        public ToyRepository(ToyUniverseContext context) : base(context)
        {
        }
    }
}