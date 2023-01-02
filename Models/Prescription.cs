using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TASK8.Models;

public partial class Prescription
{

    public int IdPrescription { get; set; }
    public int IdDoctor { get; set; }
    public int IdPatient { get; set; }

    public DateTime Date { get; set; }


    public DateTime DueDate { get; set; }




    // [ForeignKey("IdDoctor")]
    public virtual Doctor Doctor { get; set; } = null!;
    // [ForeignKey("IdPatient")]
    public virtual Patient Patient { get; set; } = null!;
    // public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; } = new List<PrescriptionMedicament>();


}