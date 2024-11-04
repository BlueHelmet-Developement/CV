namespace CV.Models
{
    public class Experience
    {
        public List<Job> Joberfaring { get; set; } = [];
        public List<Job> Uddannelse { get; set; } = [];
        public List<Job> Frivillig { get; set; } = [];
        public string Personlig { get; set; } = "";
    }
}
