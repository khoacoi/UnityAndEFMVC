﻿using Application.Domain.ContactModule.ProfilePhoneAggregate;
using System.Data.Entity.ModelConfiguration;

namespace Application.DAL.EntityConfiguration.ContactModule
{
    class ProfilePhoneConfiguration : EntityTypeConfiguration<ProfilePhone>
    {
        public ProfilePhoneConfiguration()
        {
            this.HasKey(pp => pp.ProfilePhoneId);
            // 1..*
            this.HasRequired(pp => pp.Phone)
                .WithMany(pp => pp.ProfilePhones)
                .HasForeignKey(pp => pp.PhoneId)
                .WillCascadeOnDelete(false);

            // 1..*
            this.HasRequired(pp => pp.PhoneType)
                .WithMany(pp => pp.ProfilePhones)
                .HasForeignKey(pp => pp.PhoneTypeId)
                .WillCascadeOnDelete(false);

            // 1..*
            this.HasRequired(pp => pp.Profile)
                .WithMany(pp => pp.ProfilePhones)
                .HasForeignKey(pp => pp.ProfileId)
                .WillCascadeOnDelete(false);

            //configure table map
            this.ToTable("ProfilePhone");
        }
    }
}
