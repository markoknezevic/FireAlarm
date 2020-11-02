﻿// <auto-generated />
using System;
using FireAlarm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FireAlarm.Data.Migrations
{
    [DbContext(typeof(FireAlarmDbContext))]
    partial class FireAlarmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FireAlarm.Data.Entities.Alarm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<long>("SensorId")
                        .HasColumnName("sensor_id");

                    b.Property<double>("TemperatureValue")
                        .HasColumnName("temperature_value");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("alarms");
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Sensor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<short>("StatusId")
                        .HasColumnName("status_id");

                    b.Property<double>("TriggerTemperature")
                        .HasColumnName("trigger_temperature");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnName("user_email");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("sensors");
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Status", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Temperature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<long>("SensorId")
                        .HasColumnName("sensor_id");

                    b.Property<double>("TemperatureValue")
                        .HasColumnName("value");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("temperatures");
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Alarm", b =>
                {
                    b.HasOne("FireAlarm.Data.Entities.Sensor", "Sensor")
                        .WithMany("Alarms")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Sensor", b =>
                {
                    b.HasOne("FireAlarm.Data.Entities.Status", "Status")
                        .WithMany("Sensors")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FireAlarm.Data.Entities.Temperature", b =>
                {
                    b.HasOne("FireAlarm.Data.Entities.Sensor", "Sensor")
                        .WithMany("Temperatures")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
