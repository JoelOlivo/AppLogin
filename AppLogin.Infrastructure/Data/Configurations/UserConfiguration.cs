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
                    id => id.Value,
                    value => new UserId(value) 
                )
                .IsRequired();

            // Configuración del Value Object UserEmail
            builder.Property(u => u.Email)
                .HasConversion(
                    email => email.Value, 
                    value => new UserEmail(value)
                )
                .IsRequired()
                .HasMaxLength(100);

            // Configuración del Value Object UserPassword
            builder.Property(u => u.Password)
                .HasConversion(
                    password => password.Value,
                    value => new UserPassword(value) 
                )
                .IsRequired()
                .HasMaxLength(100);

            // Configuración del Value Object UserFirstName
            builder.Property(u => u.FirstName)
                .HasConversion(
                    firstName => firstName.Value,
                    value => new UserFirstName(value)
                )
                .IsRequired()
                .HasMaxLength(50);

            // Configuración del Value Object UserLastName
            builder.Property(u => u.LastName)
                .HasConversion(
                    lastName => lastName.Value,
                    value => new UserLastName(value) 
                )
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}
