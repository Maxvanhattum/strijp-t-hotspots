using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class InterviewVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string TitleInterview { get; set; }
        [Required]
        public string DescriptionInterview { get; set; }
        [Required]
        public string UploaderInterview { get; set; }
    }
}
