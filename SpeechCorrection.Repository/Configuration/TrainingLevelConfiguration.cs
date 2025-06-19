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
    public class TrainingLevelConfiguration : IEntityTypeConfiguration<TrainingLevel>
    {
        public void Configure(EntityTypeBuilder<TrainingLevel> builder)
        {
            builder.HasKey(tl => tl.Id);
            builder.HasMany(tl => tl.TrainingRecords)
                   .WithOne(tr => tr.TrainingLevel)
                   .HasForeignKey(tr => tr.TrainingLevelId);
        }
    }
}
