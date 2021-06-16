using System.ComponentModel.DataAnnotations;

namespace ViewModels.CreateHotspot
{
    public class CreateAR360VM
    {
        [Required]
        public string SourcePath { get; set; }
    }
}
