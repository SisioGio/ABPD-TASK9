using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TASK8.Models;

public partial class Medicament
{

    public int IdMedicament { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; } = new List<PrescriptionMedicament>();

}