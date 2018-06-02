using System.ComponentModel.DataAnnotations.Schema;

namespace SpyStore.Models.Entities
{
    public class Post
    {
        //omitted for brevity
        public int BlogId { get; set; }
        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }
    }
}
