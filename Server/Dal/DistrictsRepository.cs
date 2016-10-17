using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;

namespace Dal
{
    public interface IDistrictsRepository
    {
        IList<District> List(string query);
    }
    public class DistrictsRepository : IDistrictsRepository
    {
        public IList<District> List(string query)
        {
            throw new NotImplementedException();
        }
    }
}
