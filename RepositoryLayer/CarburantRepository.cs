using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;

namespace TuCarbureAPI.RepositoryLayer
{
    public class CarburantRepository : IRepository<Carburant>
    {
        private readonly MySqlConnectionContext _context;

        public CarburantRepository(MySqlConnectionContext context)
        {
            _context = context;
        }

        public List<Carburant> Get()
        {
            return _context.Carburants.OrderBy(row => row.nom).ToList();
        }

        public Carburant? Get(int id)
        {
            return _context.Carburants.FirstOrDefault(c => c.idCarburant == id);
        }

        public Carburant insert(Carburant entity)
        {
            throw new NotImplementedException();
        }
    }
}
