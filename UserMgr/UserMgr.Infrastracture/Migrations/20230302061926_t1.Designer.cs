// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMgr.Infrastracture;

#nullable disable

namespace UserMgr.Infrastracture.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20230302061926_t1")]
    partial class t1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserMgr.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("passwordHash")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.UserAccessFail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LockEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("isLockOut")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("user_access_fail", (string)null);
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.UserLoginHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("user_login_history", (string)null);
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.User", b =>
                {
                    b.OwnsOne("UserMgr.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .IsUnicode(false)
                                .HasColumnType("varchar(20)");

                            b1.Property<int>("RegionNumber")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.UserAccessFail", b =>
                {
                    b.HasOne("UserMgr.Domain.Entities.User", "User")
                        .WithOne("UserAccessFail")
                        .HasForeignKey("UserMgr.Domain.Entities.UserAccessFail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.UserLoginHistory", b =>
                {
                    b.OwnsOne("UserMgr.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<long>("UserLoginHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .IsUnicode(false)
                                .HasColumnType("varchar(20)");

                            b1.Property<int>("RegionNumber")
                                .HasColumnType("int");

                            b1.HasKey("UserLoginHistoryId");

                            b1.ToTable("user_login_history");

                            b1.WithOwner()
                                .HasForeignKey("UserLoginHistoryId");
                        });

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("UserMgr.Domain.Entities.User", b =>
                {
                    b.Navigation("UserAccessFail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
