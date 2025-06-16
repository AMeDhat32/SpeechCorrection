namespace SpeechCorrection.APIs.DTOs
{
    public class DoctorDto
    {
        public string? About { get; set; }

        public List<string>? WorkingDays { get; set; } = new();
        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }
    }
}
