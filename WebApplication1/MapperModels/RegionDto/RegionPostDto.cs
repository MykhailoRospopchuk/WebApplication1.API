using System.ComponentModel.DataAnnotations;

namespace WebApplication1.MapperModels.RegionDto
{
    public class RegionPostDto
    {
        [Required]
        public string? RegionName { get; set; }
    }
}    