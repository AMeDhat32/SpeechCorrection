using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models
{
    public class Patient
    {
        public string Id { get; set; }
        public int? FamilyMembersCount { get; set; }
        public int? SiblingRank { get; set; }
        public double? LatestIqTestResult { get; set; }
        public double? LatestRightEarTestResult { get; set; }
        public double? LatestLeftEarTestResult { get; set; }
    }
}
