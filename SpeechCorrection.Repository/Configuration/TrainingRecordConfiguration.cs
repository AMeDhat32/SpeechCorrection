using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeechCorrection.Core.Models.TrainingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Repository.Configuration
{
    public class TrainingRecordConfiguration : IEntityTypeConfiguration<TrainingRecord>
    {
        public void Configure(EntityTypeBuilder<TrainingRecord> builder)
        {
            builder.HasKey(tr => tr.Id);
            
        }
    }
}
