using System.ComponentModel.DataAnnotations;

namespace WebApplication1.MapperModels.RegionDto
{
    public class RegionPutDto : BaseDto
    {
        [Required]
        public string? RegionName { get; set; }
    }
}