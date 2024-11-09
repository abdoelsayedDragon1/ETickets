using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string? Name { get; set; }
        public string? Description { get; set; }
       //[Required]
        public string? CinemaLogo { get; set; }
        [Required]
        public string? Address { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
