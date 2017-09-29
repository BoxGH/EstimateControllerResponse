using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Tj.ResponseTimer.Models;

namespace Tj.ResponseTimer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tj.ResponseTimer.Models.ForTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PagePath");

                    b.Property<string>("PagePath2");

                    b.Property<string>("PagePath3");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Tj.ResponseTimer.Models.RequestResponseTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("EndRequest");

                    b.Property<long>("MeasureTime");

                    b.Property<string>("PagePath");

                    b.Property<long>("ServerIn");

                    b.Property<long>("ServerOut");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Tj.ResponseTimer.Models.SomeDataClassForView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FieldNamber");

                    b.Property<string>("FieldString");

                    b.HasKey("Id");
                });
        }
    }
}
