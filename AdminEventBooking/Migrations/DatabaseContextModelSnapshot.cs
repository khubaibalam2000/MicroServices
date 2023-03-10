// <auto-generated />
using System;
using AdminEventBooking.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminEventBooking.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdminEventBooking.Database.Entities.Event", b =>
                {
                    b.Property<int>("eventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("eventId"), 1L, 1);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("eventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organizationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("organzationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<DateTime>("registrationEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("eventId");

                    b.ToTable("Event", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
