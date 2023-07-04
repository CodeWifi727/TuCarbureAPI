using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;

namespace TuCarbureAPI.RepositoryLayer
{
    public class ReleveRepository : IRepository<Releve>
    {
        private readonly MySqlConnectionContext _context;

        public ReleveRepository(MySqlConnectionContext context)
        {
            _context = context;
        }

        public List<Releve> Get()
        {
            return _context.Releves.OrderBy(row => row.DateHeure).ToList();
        }

        public Releve? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Releve insert(Releve entity)
        {
            throw new NotImplementedException();
        }
    }
}
