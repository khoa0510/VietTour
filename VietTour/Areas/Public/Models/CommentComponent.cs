namespace VietTour.Areas.Public.Models
{
    public class CommentComponent
    {
        //comment id
        public int comment_id { get; set; }
        //user id
        public int user_id { get; set; }

        //content 
        public string? content { get; set; }

        // ngày cmt
        public DateOnly date { get; set; }
    }
}
