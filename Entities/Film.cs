namespace Entities;

using System.Collections.Generic;



public class Film
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Regisseur { get; set; }
    public string? Style { get; set; }
    public string? Description { get; set; }
    public List<Seance>? Seances { get; } = new List<Seance>();
    public override string ToString()
    {
        string res = "";
        res += $"ID: {Id}\nNAME: {Name} \nREGISSEUR: {Regisseur} \nSTYLE: {Style} \nDESCRIPTION: {Description} \nSEANCES:\n";
        foreach (Seance seance in Seances)
        {
            res += $"{seance.Id} {seance.TimeStart} {seance.TimeEnd} {seance.Duration}\n";
        }
        return res;
    }
}

