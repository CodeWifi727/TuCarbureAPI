using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
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

      /*  public List<Station> Get()
        {
            return _context.Stations.OrderBy(row => row.marque).ToList();
        }*/
        public List<Station> Get()
        {
            return _context.Stations
           .Include(s => s.Releves)
           .ThenInclude(r => r.Carburant)
           .Select(s => new Station
           {
               idStationsService = s.idStationsService,
               marque = s.marque,
               adressePostale = s.adressePostale,
               longitude = s.longitude,
               latitude = s.latitude,
               ville = s.ville,
               Releves = s.Releves.ToList()
           })
           .ToList();
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
