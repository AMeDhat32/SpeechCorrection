namespace SpeechCorrection.APIs.DTOs
{
    public class PatientDto
    {
        public int? FamilyMembersCount { get; set; }
        public int? SiblingRank { get; set; }
        public double? LatestIqTestResult { get; set; }
        public double? LatestRightEarTestResult { get; set; }
        public double? LatestLeftEarTestResult { get; set; }
    }
}
