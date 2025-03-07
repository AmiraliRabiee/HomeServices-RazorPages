namespace App.Domain.Core.Dto.Dashboard
{
    public class StatisticsCustomerDto
    {
        public int Id { get; set; }
        public int ActiveCount { get; set; }
        public int DoneCount { get; set; }
        public int CommentCount { get; set; }
        public float Balance { get; set; }
    }
}
