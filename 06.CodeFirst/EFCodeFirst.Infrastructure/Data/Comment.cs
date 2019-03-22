namespace EFCodeFirst.Infrastructure.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public int PostId { get; set; }
        
        [Required]
        [StringLength(250)]
        public int Content { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
