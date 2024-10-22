using System.ComponentModel.DataAnnotations;

namespace StudendsGradeApp.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SubjectId { get; set; }

        [Required]
        [Range(0, 100)]
        public float Grade { get; set; }

        public string Remarks { get; set; }

    }
}
