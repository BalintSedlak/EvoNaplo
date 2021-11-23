namespace EvoNaploTFS.Models.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int OwnerId { get; set; }
        public int CommenterId { get; set; }
        public string CommenterName { get; set; }

        public CommentDTO(string comment, int ownerId, int commenterId,string commenterName)
        {
            Comment = comment;
            OwnerId = ownerId;
            CommenterId = commenterId;
            CommenterName = commenterName;
        }
    }
}
