using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class AddRegionDto
    {
        [MinLength(3)] [MaxLength(3)]
        public required string Code { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
