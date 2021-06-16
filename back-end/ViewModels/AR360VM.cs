using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class AR360VM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SourcePath { get; set; }
    }
}
