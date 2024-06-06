using System.ComponentModel.DataAnnotations;

namespace App1.Models.DTO

{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name must be a maximum of 50 characters long.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description must be a maximum of 500 characters long.")]
        public string Description { get; set; }

        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }

    }
}