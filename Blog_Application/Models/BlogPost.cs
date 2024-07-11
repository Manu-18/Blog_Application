using System.ComponentModel.DataAnnotations;

namespace Blog_Application.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly DateModified { get; set; }
    }
}
