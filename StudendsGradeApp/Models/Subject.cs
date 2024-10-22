using System.ComponentModel.DataAnnotations;

namespace StudendsGradeApp.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
