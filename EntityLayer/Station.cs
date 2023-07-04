using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuCarbureAPI.EntityLayer;

[Table("stations-services", Schema = "tucarbure")]
public class Station
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id-stations-Service")]
    public int idStationsService { get; set; }
    public string? marque { get; set; }
    public string? adressePostale { get; set; }
    public string? longitude { get; set; }
    public string? latitude { get; set; }
    public string? ville { get; set; }

}
