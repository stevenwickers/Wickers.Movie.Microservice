namespace Wickers.Movie.Models
{
    public class MovieModel
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; } = "";
        public string WorldwideGross { get; set; } = "";
        public string ProductionBudget { get; set; } = "";
        public string MovieLink { get; set; } = "";
        public string DomesticGross { get; set; } = "";
    }
}