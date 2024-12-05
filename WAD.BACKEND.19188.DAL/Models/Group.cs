using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._19188.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Group name is required.")]
        [MaxLength(100, ErrorMessage = "Group name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string Description { get; set; }
    }
}
