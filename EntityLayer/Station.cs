using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuCarbureAPI.EntityLayer;

[Table("stations_services", Schema = "tucarbure")]
public class Station
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_stations_Service")]
    public int idStationsService { get; set; }
    public string? marque { get; set; }
    public string? adressePostale { get; set; }
    public float? longitude { get; set; }
    public float? latitude { get; set; }
    public string? ville { get; set; }
    public List<Releve> Releves { get; set; }

}
