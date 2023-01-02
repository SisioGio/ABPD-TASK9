using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
namespace TASK8.Models;

public partial class PrescriptionMedicament
{


    // public int IdPrescriptionMedicament { get; set; }
    public int Dose { get; set; }

    public int IdPrescription { get; set; }
    public int IdMedicament { get; set; }
    public string Details { get; set; }

    public virtual Medicament Medicament { get; set; } = null!;

    public virtual Prescription Prescription { get; set; } = null!;

}