using System.ComponentModel.DataAnnotations;

namespace TripplanetAPI.Models
{
    public record Location
    {
        [Key]
        public string id { get; init; } = String.Empty;
        public urls? urls { get; init; }
        public location? location { get; init; }
    }
    public record urls
    {
        [Key]
        public int Id { get; init; }
        public string small { get; init; } = String.Empty;
    }
    public record location
    {
        [Key]
        public int Id { get; init; }
        public string name { get; init; } = String.Empty;
        public position? position { get; init; }
    }
    public record position
    {
        [Key]
        public int Id { get; init; }
        public double? latitude { get; init; }
        public double? longitude { get; init; }
    }
}
