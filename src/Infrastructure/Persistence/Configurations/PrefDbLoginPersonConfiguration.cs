using ApiTrottling.Domain.Entities;
using ApiTrottling.Domain.Entities.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTrottling.Infrastructure.Persistence.Configurations;

public class PrefDbLoginPersonConfiguration :IEntityTypeConfiguration<PrefDbLoginPerson>
{
    public void Configure(EntityTypeBuilder<PrefDbLoginPerson> builder)
    {
        builder.HasKey(e => e.MobilePhone);

        builder.ToTable("PrefDb_Login_Person");

        builder.Property(e => e.MobilePhone)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.AddressFromCity)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Address_From_City");

        builder.Property(e => e.AddressFromPostCode)
            .HasMaxLength(4)
            .IsUnicode(false)
            .HasColumnName("Address_From_PostCode");

        builder.Property(e => e.AddressFromStreet)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Address_From_Street");

        builder.Property(e => e.AddressToCity)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Address_To_City");

        builder.Property(e => e.AddressToPostCode)
            .HasMaxLength(4)
            .IsUnicode(false)
            .HasColumnName("Address_To_PostCode");

        builder.Property(e => e.AddressToStreet)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Address_To_Street");

        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.FirstName)
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.Property(e => e.Gender)
            .HasMaxLength(1)
            .IsUnicode(false);

        builder.Property(e => e.LastName)
            .HasMaxLength(255)
            .IsUnicode(false);
        
        builder.Property(e => e.SmsToken)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("Sms_Token");

        builder.Property(e => e.SmsTokenExpireDate).
            HasColumnName("Sms_Token_Expire_Date");

        builder.Property(e => e.SessionCookie)
            .HasMaxLength(8000)
            .IsUnicode(false)
            .HasColumnName("SessionCookie");

        builder.Property(e => e.SessionId)
            .HasColumnType("UniqueIdentifier")
            .HasColumnName("SessionId");

    }
}