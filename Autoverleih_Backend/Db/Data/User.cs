using System.ComponentModel.DataAnnotations;

namespace Autoverleih_Backend.Db.Data;

public class User
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
}