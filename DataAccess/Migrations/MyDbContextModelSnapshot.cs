﻿// <auto-generated />
using System;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Comment", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("GoodId")
                        .HasColumnType("int")
                        .HasColumnName("GoodId");

                    b.Property<int?>("Comment_")
                        .HasColumnType("int")
                        .HasColumnName("Comment");

                    b.Property<int>("Rate")
                        .HasColumnType("int")
                        .HasColumnName("Rate");

                    b.HasKey("UserId", "GoodId")
                        .HasName("PK__Comments__D7CB621F4C519DAB");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("UserId", "GoodId"));

                    b.HasIndex("GoodId");

                    b.ToTable("Comments", "dbo");
                });

            modelBuilder.Entity("Domain.Model.Good", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Category")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ID");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<string>("Descryption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descryption");

                    b.Property<decimal>("Price")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)")
                        .HasColumnName("Price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("Id")
                        .HasName("PK__Goods__3214EC2747D3C508");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Goods", "dbo");
                });

            modelBuilder.Entity("Domain.Model.GoodsList", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("GoodId")
                        .HasColumnType("int")
                        .HasColumnName("GoodId");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.HasKey("UserId", "GoodId")
                        .HasName("PK__GoodsLis__D7CB621F7A6EF2A9");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("UserId", "GoodId"));

                    b.HasIndex("GoodId");

                    b.ToTable("GoodsList", "dbo");
                });

            modelBuilder.Entity("Domain.Model.LikedList", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("GoodId")
                        .HasColumnType("int")
                        .HasColumnName("GoodId");

                    b.HasKey("UserId", "GoodId")
                        .HasName("PK__LikedLis__D7CB621F263FEB94");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("UserId", "GoodId"));

                    b.HasIndex("GoodId");

                    b.ToTable("LikedList", "dbo");
                });

            modelBuilder.Entity("Domain.Model.SavedAdress", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("Title")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Title");

                    b.Property<int?>("Apartament")
                        .HasColumnType("int")
                        .HasColumnName("Apartament");

                    b.Property<int?>("Building")
                        .HasColumnType("int")
                        .HasColumnName("Building");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("City");

                    b.Property<int?>("Front")
                        .HasColumnType("int")
                        .HasColumnName("Front");

                    b.Property<int>("House")
                        .HasColumnType("int")
                        .HasColumnName("House");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Street");

                    b.HasKey("UserId", "Title")
                        .HasName("PK__SavedAdr__D543AA01C2B1B66D");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("UserId", "Title"));

                    b.ToTable("SavedAdresses", "dbo");
                });

            modelBuilder.Entity("Domain.Model.Ship", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("GoodId")
                        .HasColumnType("int")
                        .HasColumnName("GoodId");

                    b.Property<int?>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime")
                        .HasColumnName("ShipDate");

                    b.Property<string>("Status")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Status");

                    b.HasKey("Id", "UserId", "GoodId")
                        .HasName("PK__Ships__DF685A06ADC55F86");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id", "UserId", "GoodId"));

                    b.HasIndex("GoodId");

                    b.HasIndex("UserId");

                    b.ToTable("Ships", "dbo");
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("Authed")
                        .HasColumnType("bit")
                        .HasColumnName("Authed");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit")
                        .HasColumnName("IsDelete");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Nickname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password");

                    b.Property<string>("Phonenumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Phonenumber");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Surname");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC27EF4AD3F1");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Users", "dbo");
                });

            modelBuilder.Entity("Domain.Model.Comment", b =>
                {
                    b.HasOne("Domain.Model.Good", "Good")
                        .WithMany("Comments")
                        .HasForeignKey("GoodId")
                        .IsRequired()
                        .HasConstraintName("FK__Comments__GoodId__46E78A0C");

                    b.HasOne("Domain.Model.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Comments__UserId__45F365D3");

                    b.Navigation("Good");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Model.GoodsList", b =>
                {
                    b.HasOne("Domain.Model.Good", "Good")
                        .WithMany("GoodsLists")
                        .HasForeignKey("GoodId")
                        .IsRequired()
                        .HasConstraintName("FK__GoodsList__GoodI__3F466844");

                    b.HasOne("Domain.Model.User", "User")
                        .WithMany("GoodsLists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__GoodsList__UserI__3E52440B");

                    b.Navigation("Good");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Model.LikedList", b =>
                {
                    b.HasOne("Domain.Model.Good", "Good")
                        .WithMany("LikedLists")
                        .HasForeignKey("GoodId")
                        .IsRequired()
                        .HasConstraintName("FK__LikedList__GoodI__4316F928");

                    b.HasOne("Domain.Model.User", "User")
                        .WithMany("LikedLists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__LikedList__UserI__4222D4EF");

                    b.Navigation("Good");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Model.SavedAdress", b =>
                {
                    b.HasOne("Domain.Model.User", "User")
                        .WithMany("SavedAdresses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__SavedAdre__UserI__398D8EEE");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Model.Ship", b =>
                {
                    b.HasOne("Domain.Model.Good", "Good")
                        .WithMany("Ships")
                        .HasForeignKey("GoodId")
                        .IsRequired()
                        .HasConstraintName("FK__Ships__GoodId__4AB81AF0");

                    b.HasOne("Domain.Model.User", "User")
                        .WithMany("Ships")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Ships__UserId__49C3F6B7");

                    b.Navigation("Good");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Model.Good", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GoodsLists");

                    b.Navigation("LikedLists");

                    b.Navigation("Ships");
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("GoodsLists");

                    b.Navigation("LikedLists");

                    b.Navigation("SavedAdresses");

                    b.Navigation("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
