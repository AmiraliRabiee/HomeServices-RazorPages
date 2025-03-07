namespace App.Domain.Core.Dto.Dashboard
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public DateTime RegissterDate { get; set; }
        public int? ExpertId { get; set; }
        public string? ExpertName { get; set; }
        public string Opinion { get; set; }
        public int? Points { get; set; }
    }
}
