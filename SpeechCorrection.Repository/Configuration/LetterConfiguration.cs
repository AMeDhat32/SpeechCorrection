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
    public class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            
            builder.HasKey(l => l.Id);
           
            builder.HasMany(l => l.TrainingLevels)
                   .WithOne(tl => tl.Letter)
                   .HasForeignKey(tl => tl.LetterId);
        }
    
    
    }
}
