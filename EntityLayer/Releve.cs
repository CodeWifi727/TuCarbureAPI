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
    public int PrixCarburant { get; set; }

}
