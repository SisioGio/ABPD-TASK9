using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TASK8.Models;

public partial class PrescriptionDetails
{



    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
    public ICollection<object> Medicaments { get; set; } = null!;

}