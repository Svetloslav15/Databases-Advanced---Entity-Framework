namespace EFCodeFirst.Infrastructure.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public HashSet<Post> Posts { get; set; } = new HashSet<Post>();

        public HashSet<Reply> Replies { get; set; } = new HashSet<Reply>();

        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
