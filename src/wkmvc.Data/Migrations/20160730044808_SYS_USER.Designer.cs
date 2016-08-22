using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wkmvc.Data;

namespace wkmvc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160730044808_SYS_USER")]
    partial class SYS_USER
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
                        .IsRequired();

                    b.Property<string>("EN_NAME");

                    b.Property<string>("EN_NAME_SIMPLE");

                    b.Property<bool>("ISCANLOGIN");

                    b.Property<string>("PASSWORD")
                        .IsRequired();

                    b.Property<DateTime>("UPDATEDATE");

                    b.Property<string>("UPDATEUSER")
                        .IsRequired();

                    b.Property<string>("USERNAME");

                    b.HasKey("ID");

                    b.ToTable("SYS_USER");
                });
        }
    }
}
