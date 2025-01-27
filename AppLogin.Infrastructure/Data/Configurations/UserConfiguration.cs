using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppLogin.Domain.Entities;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Especificar el nombre de la tabla
            builder.ToTable("Users");

            // Configurar la clave primaria
            builder.HasKey(u => u.Id);

            // Configuración del Value Object UserId
            builder.Property(u => u.Id)
                .HasConversion(
                    id => id.Value, // De UserId a Guid
                    value => new UserId(value) // De Guid a UserId
                )
                .IsRequired();

            // Configuración del Value Object UserEmail
            builder.Property(u => u.Email)
                .HasConversion(
                    email => email.Value, // De UserEmail a string
                    value => new UserEmail(value) // De string a UserEmail
                )
                .IsRequired()
                .HasMaxLength(100);

            // Configuración del Value Object UserPassword
            builder.Property(u => u.Password)
                .HasConversion(
                    password => password.Value, // De UserPassword a string
                    value => new UserPassword(value) // De string a UserPassword
                )
                .IsRequired()
                .HasMaxLength(100);

            // Configuración del Value Object UserFirstName
            builder.Property(u => u.FirstName)
                .HasConversion(
                    firstName => firstName.Value, // De UserFirstName a string
                    value => new UserFirstName(value) // De string a UserFirstName
                )
                .IsRequired()
                .HasMaxLength(50);

            // Configuración del Value Object UserLastName
            builder.Property(u => u.LastName)
                .HasConversion(
                    lastName => lastName.Value, // De UserLastName a string
                    value => new UserLastName(value) // De string a UserLastName
                )
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}
