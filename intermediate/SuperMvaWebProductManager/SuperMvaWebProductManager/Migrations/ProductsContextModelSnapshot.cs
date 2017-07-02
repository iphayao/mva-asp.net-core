using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SuperMvaWebProductManager.Models;

namespace SuperMvaWebProductManager.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperMvaWebProductManager.Models.Category", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SuperMvaWebProductManager.Models.Product", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SuperMvaWebProductManager.Models.Product", b =>
                {
                    b.HasOne("SuperMvaWebProductManager.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_Categories");
                });
        }
    }
}
