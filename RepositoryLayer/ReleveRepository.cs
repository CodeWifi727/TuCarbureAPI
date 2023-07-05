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
            return _context.Releves
                .Include(r => r.Station)
                .Include(r => r.Carburant)
                //afficher seulement un relever par station
                .GroupBy(r => r.Station)
                .Select(g => g.First())
                .ToList();
            //.OrderBy(row => row.DateHeure)

        }

        public Releve? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Releve insert(Releve entity)
        {
            throw new NotImplementedException();
        }

        public Releve UpdatePriceAndDate(int releveId, float newPrice)
        {
            var releveToUpdate = _context.Releves.Find(releveId);
            if (releveToUpdate != null)
            {
                releveToUpdate.PrixCarburant = newPrice;
                releveToUpdate.DateHeure = DateTime.Now; // Set the current date and time
                _context.SaveChanges();
            }

            return releveToUpdate;
        }

public List<Releve> LastPrice(int stationId)
{
    // Find the station with the given stationId
    var releveStation = _context.Stations.Find(stationId);

    if (releveStation == null)
    {
        // Return an empty list if the stationId doesn't exist
        return new List<Releve>();
    }

    var lastPrices = _context.Carburants
        .Join(
            _context.Releves,
            carburant => carburant.idCarburant,
            releve => releve.idCarburant,
            (carburant, releve) => new { Carburant = carburant, Releve = releve }
        )
        .Join(
            _context.Stations,
            carburantReleve => carburantReleve.Releve.idStation,
            station => station.idStationsService,
            (carburantReleve, station) => new { CarburantReleve = carburantReleve, Station = station }
        )
        .Where(joinResult => joinResult.Station.idStationsService == stationId)
        .GroupBy(joinResult => new { joinResult.CarburantReleve.Carburant.nom, joinResult.CarburantReleve.Carburant.codeEuropeen })
        .Select(groupedResult => new Releve
        {
            Carburant = new Carburant // Create a new Carburant object here
            {
                nom = groupedResult.Key.nom,
                codeEuropeen = groupedResult.Key.codeEuropeen
            },
            PrixCarburant = groupedResult.Min(item => item.CarburantReleve.Releve.PrixCarburant),
            DateHeure = groupedResult.Max(item => item.CarburantReleve.Releve.DateHeure)
        })
        .OrderBy(result => result.PrixCarburant)
        .ToList();

    return lastPrices;
}
        public List<Releve> LowerPrice(float longitude, float latitude)
        {
            // Find the stations with the given longitude and latitude
            var closestStations = _context.Stations
                .OrderBy(s => Math.Pow((double)(s.longitude - longitude), 2) + Math.Pow((double)(s.latitude - latitude), 2))
                .Take(5) // Adjust this value to get the number of closest stations you want
                .ToList();

            if (closestStations.Count == 0)
            {
                // Return an empty list if no stations found
                return new List<Releve>();
            }

            // Get the stationIds of the closest stations
            var closestStationIds = closestStations.Select(s => s.idStationsService).ToList();

            return _context.Releves
                .Where(r => closestStationIds.Contains(r.idStation)) // Filter by closest stationIds
                .Include(r => r.Station) // Include Station
                .OrderBy(row => row.PrixCarburant) // Order by PrixCarburant
                .Include(r => r.Carburant) // Include Carburant
                .ToList();
        }
    }
}
