using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wkmvc.Data;

namespace wkmvc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160730061135_SYS_USER_1")]
    partial class SYS_USER_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("wkmvc.Data.Models.SYS_USER", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ACCOUNT")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("CREATEDATE");

                    b.Property<string>("CREATEUSER")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("EN_NAME")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("EN_NAME_SIMPLE")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool>("ISCANLOGIN");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<DateTime>("UPDATEDATE");

                    b.Property<string>("UPDATEUSER")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("USERNAME")
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("ID");

                    b.ToTable("SYS_USER");
                });
        }
    }
}
