using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wkmvc.Data;

namespace wkmvc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160801014751_SYS_USER_ONLINE")]
    partial class SYS_USER_ONLINE
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

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("EN_Name")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("EN_Nme_Simple")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool>("IsCanLogin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<int?>("UserOnlineUserID");

                    b.HasKey("ID");

                    b.HasIndex("UserOnlineUserID");

                    b.ToTable("SYS_USER");
                });

            modelBuilder.Entity("wkmvc.Data.Models.SYS_USER_ONLINE", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConnectId")
                        .HasAnnotation("MaxLength", 36);

                    b.Property<bool>("IsOnlie");

                    b.Property<DateTime>("OffLineDate");

                    b.Property<DateTime>("OnlineDate");

                    b.Property<string>("UserIP")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("UserID");

                    b.ToTable("SYS_USER_ONLINE");
                });

            modelBuilder.Entity("wkmvc.Data.Models.SYS_USER", b =>
                {
                    b.HasOne("wkmvc.Data.Models.SYS_USER_ONLINE", "UserOnline")
                        .WithMany()
                        .HasForeignKey("UserOnlineUserID");
                });
        }
    }
}
