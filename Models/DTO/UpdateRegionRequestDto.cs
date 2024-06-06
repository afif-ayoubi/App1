using System.ComponentModel.DataAnnotations;

namespace App1.Models.DTO

{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must be a minimum of 3 characters long.")]
        [MaxLength(3, ErrorMessage = "Code must be a maximum of 3 characters long.")]
        public string Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name must be a maximum of 50 characters long.")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}