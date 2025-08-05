using System;

namespace Domain.Entities
{
    public class Education
    {
        public long Id { get; set; }

        public string Degree { get; set; }

        public string University { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
    }
}
