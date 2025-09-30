namespace PERROVERDE8.API.Models;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime StartAt { get; set; }
    public DateTime? EndAt { get; set; }
    public bool IsOnline { get; set; }
    public string? Notes { get; set; }
}