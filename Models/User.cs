using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TASK9.Models;

public partial class User
{

    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
    public DateTime? RefreshTokenExpirationDate { get; set; }
}