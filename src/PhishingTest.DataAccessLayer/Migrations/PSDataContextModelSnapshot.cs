using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PhishingTest.DataAccessLayer.DataContext;

namespace PhishingTest.DataAccessLayer.Migrations
{
    [DbContext(typeof(PSDataContext))]
    partial class PSDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhishingTest.DataAccessLayer.Entities.CompromisedCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Password")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<int>("PhishingSiteId");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 500);

                    b.HasKey("Id");

                    b.ToTable("CompromisedCredential");
                });
        }
    }
}
