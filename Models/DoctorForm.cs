using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TASK8.Models;

public partial class DoctorForm
{
    public int IdDoctor { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

}