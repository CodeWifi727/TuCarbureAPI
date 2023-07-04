using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;

namespace TuCarbureAPI.RepositoryLayer
{
    public class StationRepository : IRepository<Station>
    {
        private readonly MySqlConnectionContext _context;

        public StationRepository(MySqlConnectionContext context)
        {
            _context = context;
        }

        public List<Station> Get()
        {
            return _context.Stations.OrderBy(row => row.marque).ToList();
        }

        public Station? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Station insert(Station entity)
        {
            throw new NotImplementedException();
        }
    }
}
