using System;
using System.Linq;

using Toys.Data.Data;
using Toys.Data.Models;
using Toys.Data.Repositories;
using Toys.Web.Models;

namespace Toys.Web.Services
{
    public interface IToyService
    {
        public PagedResult<Toy> GetToyPage(int currentPage);
    }
    public class ToyService : GenericService, IToyService
    {
        private IToyRepository toyRepository;

        public ToyService(IToyRepository toyRepository, ToyUniverseContext context)
        {
            this.toyRepository = toyRepository;
        }



        public PagedResult<Toy> GetToyPage(int currentPage)
        {
            return GetPaged<Toy>(toyRepository.Context.Toys, currentPage, 5);
        }
    }
}
