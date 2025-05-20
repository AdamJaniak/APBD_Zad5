using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace Cw_5.Models;

public class PerscriptionMedicament
{
    [Required]
    public int IdMedicament { get; set; }
    
    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; }
    
    [Required]
    public int IdPerscription { get; set; }
    
    [ForeignKey(nameof(IdPerscription))]
    public virtual Perscription Perscription { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}