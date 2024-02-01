namespace Entities;


public class Seance
{
    public int Id { get; set; }
    public Film? Film { get; set; } = null!;
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }
    public string? Duration { get; set; }

    public override string? ToString()
    {
        return $"ID: {Id} TIMESTART: {TimeStart} TIMEEND: {TimeEnd} DURATION: {Duration} FILM:\n {Film.Id} {Film.Name} {Film.Description} {Film.Regisseur} {Film.Style}";
    }
}
