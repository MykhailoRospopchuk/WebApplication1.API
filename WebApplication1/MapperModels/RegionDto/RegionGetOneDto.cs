using System.ComponentModel.DataAnnotations;

namespace WebApplication1.MapperModels.RegionDto
{
    public class RegionGetOneDto : BaseDto
    {   
        [Required]
        public string? RegionName { get; set; }
    }
}