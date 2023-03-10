// <auto-generated />
using System;
using BestRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BestRestaurant.Migrations
{
    [DbContext(typeof(BestRestaurantContext))]
    [Migration("20230310003746_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BestRestaurant.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CuisineType")
                        .HasColumnType("longtext");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("longtext");

                    b.HasKey("CuisineId");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("BestRestaurant.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CuisineId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("RestaurantId");

                    b.HasIndex("CuisineId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("BestRestaurant.Models.RestaurantReview", b =>
                {
                    b.Property<int>("RestaurantReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantReviewId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("ReviewId");

                    b.ToTable("RestaurantReviews");
                });

            modelBuilder.Entity("BestRestaurant.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Rating")
                        .HasColumnType("longtext");

                    b.Property<string>("Restaurant")
                        .HasColumnType("longtext");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("longtext");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BestRestaurant.Models.Restaurant", b =>
                {
                    b.HasOne("BestRestaurant.Models.Cuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuisine");
                });

            modelBuilder.Entity("BestRestaurant.Models.RestaurantReview", b =>
                {
                    b.HasOne("BestRestaurant.Models.Restaurant", "Restaurant")
                        .WithMany("JoinEntities")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BestRestaurant.Models.Review", "Review")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("BestRestaurant.Models.Cuisine", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("BestRestaurant.Models.Restaurant", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("BestRestaurant.Models.Review", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
