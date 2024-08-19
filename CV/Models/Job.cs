namespace CV.Models
{
    public class Job
    {
        public string? Start { get; set; }
        public DateTime StartDate => DateTime.Parse(Start ?? "2000-01-01");
        public string? Slut { get; set; }
        public DateTime SlutDate => DateTime.Parse(Slut ?? "2000-01-01");
        public List<string>? Titler { get; set; } = [];
        public string? Firma { get; set; }
        public List<string> TagLines { get; set; } = [];
        public List<string> Teknologier { get; set; } = [];
    }
}
