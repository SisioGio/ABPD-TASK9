using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TASK9.Models;

public partial class UserDTO
{


    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;


}