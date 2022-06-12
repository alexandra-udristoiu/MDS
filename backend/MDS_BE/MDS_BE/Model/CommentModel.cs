namespace MDS_BE.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}