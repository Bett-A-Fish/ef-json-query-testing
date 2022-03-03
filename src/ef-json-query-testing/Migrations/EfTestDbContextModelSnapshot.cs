﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ef_json_query_testing
{
    [DbContext(typeof(EfTestDbContext))]
    partial class EfTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ef_json_query_testing.DynamicField", b =>
                {
                    b.Property<int>("DynamicFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DynamicFieldId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DynamicListTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsQueryable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("JsonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DynamicFieldId");

                    b.HasIndex("DynamicListTypeId");

                    b.ToTable("DynamicFields");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicListItem", b =>
                {
                    b.Property<int>("DynamicListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DynamicListItemId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DynamicListTypeId")
                        .HasColumnType("int");

                    b.HasKey("DynamicListItemId");

                    b.HasIndex("DynamicListTypeId");

                    b.ToTable("DynamicListItems");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicListType", b =>
                {
                    b.Property<int>("DynamicListTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DynamicListTypeId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DynamicListTypeId");

                    b.ToTable("DynamicListTypes");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicMediaInformation", b =>
                {
                    b.Property<int>("DynamicMediaInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DynamicMediaInformationId"), 1L, 1);

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DynamicMediaInformationId");

                    b.HasIndex("FieldId");

                    b.HasIndex("MediaId");

                    b.ToTable("DynamicMediaInformation");
                });

            modelBuilder.Entity("ef_json_query_testing.Media_Dynamic", b =>
                {
                    b.Property<int>("Media_DynamicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Media_DynamicId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileHeight")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int?>("FileWidth")
                        .HasColumnType("int");

                    b.Property<bool>("Hold")
                        .HasColumnType("bit");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Media_DynamicId");

                    b.ToTable("Media_Dynamic");
                });

            modelBuilder.Entity("ef_json_query_testing.Media_Json", b =>
                {
                    b.Property<int>("Media_JsonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Media_JsonId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileHeight")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int?>("FileWidth")
                        .HasColumnType("int");

                    b.Property<bool>("Hold")
                        .HasColumnType("bit");

                    b.Property<string>("JsonDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Media_JsonId");

                    b.ToTable("Media_Json");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicField", b =>
                {
                    b.HasOne("ef_json_query_testing.DynamicListItem", "DynamicListType")
                        .WithMany()
                        .HasForeignKey("DynamicListTypeId");

                    b.Navigation("DynamicListType");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicListItem", b =>
                {
                    b.HasOne("ef_json_query_testing.DynamicListType", "DynamicListType")
                        .WithMany()
                        .HasForeignKey("DynamicListTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DynamicListType");
                });

            modelBuilder.Entity("ef_json_query_testing.DynamicMediaInformation", b =>
                {
                    b.HasOne("ef_json_query_testing.DynamicField", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ef_json_query_testing.Media_Dynamic", "Media")
                        .WithMany("DynamicMediaInformation")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("ef_json_query_testing.Media_Dynamic", b =>
                {
                    b.Navigation("DynamicMediaInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
