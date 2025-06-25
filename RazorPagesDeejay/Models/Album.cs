namespace RazorPagesDeejay.Models
{
    public class Album
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Artist { get; set; }
        public string? CoverArtUrl { get; set; }
    }
}
