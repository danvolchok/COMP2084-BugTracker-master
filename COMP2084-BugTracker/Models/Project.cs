using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP2084_BugTracker.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200), MinLength(2)]
        public string Name { get; set; }

        [Required]
        public float Version { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public ICollection<Bug>? Bugs { get; set; }
    }
}
