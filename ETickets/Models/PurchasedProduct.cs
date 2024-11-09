using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace ETickets.Models
{
    public class PurchasedProduct
    {
        public int Id { get; set; } 
        
        public string ApplicationUserId { get; set; } 
        public string ApplicatinName { get; set; }
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public double MoviePrice { get; set; }
        public double ProductPrice { get; set; }
        public int numOfTicets { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
        [ValidateNever]
        public Movie Movie { get; set; }
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }
        
    }
}
