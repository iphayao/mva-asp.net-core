using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SuperMvaWepForm.Models;

namespace SuperMvaWepForm.Migrations
{
    [DbContext(typeof(AlbumContext))]
    [Migration("20170628161319_addedrank")]
    partial class addedrank
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperMvaWepForm.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<string>("Genre");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<decimal>("Price");

                    b.Property<int>("Rank");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("ID");

                    b.ToTable("Album");
                });
        }
    }
}
