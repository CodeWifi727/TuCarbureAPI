using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuCarbureAPI.EntityLayer;

[Table("releves", Schema = "tucarbure")]
public class Releve
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_releve")]
    public int idReleve { get; set; }

    [Column("date_heure")]
    public DateTime DateHeure { get; set; }

    [Column("prix_carburant")]
    public float PrixCarburant { get; set; }


    [Column("fk_carburant")]
    public int idCarburant { get; set; }

    [ForeignKey("idCarburant")]
    public Carburant Carburant { get; set; }

    [Column("fk_station_service")]
    public int idStation { get; set; }

    [ForeignKey("idStation")]
    public Station Station { get; set; }
}
