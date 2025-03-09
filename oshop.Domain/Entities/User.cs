using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Column("PasswordHash")]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }  
}
