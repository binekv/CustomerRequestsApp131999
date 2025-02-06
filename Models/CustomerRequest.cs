using System.ComponentModel.DataAnnotations;

public class CustomerRequest
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, StringLength(500)]
    public string Message { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}