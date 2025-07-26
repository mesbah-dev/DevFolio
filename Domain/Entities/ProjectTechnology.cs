namespace Domain.Entities
{
    public class ProjectTechnology
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
