namespace App.Domain.Core.Dto.Dashboard
{
    public class StatisticsExpertDto
    {
        public int Id { get; set; }
        public int ActiveCount { get; set; }
        public int DoneSuggestions { get; set; }
        public int CommentsCount { get; set; }
        public float Balance { get; set; }
    }
}
