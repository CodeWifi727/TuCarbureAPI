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
    [Column("id-releve")]
    public int idReleve { get; set; }

    [Column("date-heure")]
    public DateTime DateHeure { get; set; }

    [Column("prix-carburant")]
    public int PrixCarburant { get; set; }

}
