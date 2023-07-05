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

//La méthode LastPrice prend en paramètre l'identifiant d'une station.
public List<Releve> LastPrice(int stationId)
{
    // Elle commence par chercher la station correspondante dans le contexte de base de données _context.
    var releveStation = _context.Stations.Find(stationId);

    if (releveStation == null)
    {
        // Si la station n'existe pas, la méthode retourne une liste vide.
        return new List<Releve>();
    }

    var lastPrices = _context.Carburants

    /* la méthode effectue une série d'opérations de jointure (join) sur les entités Carburants, 
    Releves et Stations pour récupérer les données nécessaires.*/
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

        //Les résultats de la jointure sont filtrés pour ne garder que ceux qui correspondent à l'identifiant de la station donnée.
        .Where(joinResult => joinResult.Station.idStationsService == stationId)

        //Les résultats sont ensuite regroupés par le nom et le code européen du carburant.
        .GroupBy(joinResult => new { joinResult.CarburantReleve.Carburant.nom, joinResult.CarburantReleve.Carburant.codeEuropeen })

        /*En utilisant la clause Select, un nouvel objet Releve est créé
         pour chaque groupe, contenant les informations pertinentes : 
         un nouvel objet Carburant avec le nom et le code européen, 
         le prix minimum du carburant dans ce groupe, et 
         la date et l'heure maximales associées. */
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
        //Les résultats sont triés par ordre croissant des prix du carburant.
        .OrderBy(result => result.PrixCarburant)
        //Finalement, les résultats sont convertis en une liste de Releve et renvoyés.
        .ToList();

    return lastPrices;
}
        //La méthode LowerPrice prend en paramètres la longitude et la latitude d'un emplacement.
        public List<Releve> LowerPrice(float longitude, float latitude)
        {
            /* Les stations du contexte de base de données _context.Stations sont triées par distance, en utilisant 
            la formule du carré de la distance (distance euclidienne) entre chaque station et l'emplacement donné.*/
            var closestStations = _context.Stations
                .OrderBy(s => Math.Pow((double)(s.longitude - longitude), 2) + Math.Pow((double)(s.latitude - latitude), 2))
                .Take(5) // les 5 stations les plus proches que vous souhaitez

                .ToList();

            // Si aucune station n'a été trouvée (la liste closestStations est vide), 
            if (closestStations.Count == 0)
            {
                //la méthode renvoie une liste vide de relevés de prix (List<Releve>).
                return new List<Releve>();
            }

            // Obtenir les stationIds des stations les plus proches
            var closestStationIds = closestStations.Select(s => s.idStationsService).ToList();

            //Les entités Station et Carburant associées à chaque relevé sont incluses en utilisant la méthode Include.
            return _context.Releves
                .Where(r => closestStationIds.Contains(r.idStation)) // Filter by closest stationIds
                .Include(r => r.Station) // Include Station
                .OrderBy(row => row.PrixCarburant) // Order by PrixCarburant
                .Include(r => r.Carburant) // Include Carburant
                .ToList();
        }
    }
}
