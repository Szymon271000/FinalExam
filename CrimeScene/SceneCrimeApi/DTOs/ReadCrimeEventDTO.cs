namespace SceneCrimeApi.DTOs
{
    public class ReadCrimeEventDTO
    {
        public string? Id { get; set; }

        public DateTime dateOfEvent { get; set; }
        public string? type { get; set; }

        public string? shortDescription { get; set; }

        public string? city { get; set; }
        public string? address { get; set; }

        public float? postalCode { get; set; }
        public bool? isAssigend { get; set; }
        public bool? isFinished { get; set; }
        public string? lawEnforcementId { get; set; }
    }
}
