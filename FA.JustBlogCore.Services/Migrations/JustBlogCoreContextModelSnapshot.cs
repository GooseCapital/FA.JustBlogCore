// <auto-generated />
using System;
using FA.JustBlogCore.Services.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FA.JustBlogCore.Services.Migrations
{
    [DbContext(typeof(JustBlogCoreContext))]
    partial class JustBlogCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSlug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("112c75fa-4ff1-4067-8d8c-6ef260881f40"),
                            Name = "Thời sự",
                            UrlSlug = "thoi-su"
                        },
                        new
                        {
                            Id = new Guid("10136224-e831-474a-adc6-2684e166ce65"),
                            Name = "Góc nhìn",
                            UrlSlug = "goc-nhin"
                        },
                        new
                        {
                            Id = new Guid("1124571c-594d-446b-b78e-9f36ea20e6a8"),
                            Name = "Thế giới",
                            UrlSlug = "the-gioi"
                        },
                        new
                        {
                            Id = new Guid("1dd3215d-cdff-4b44-9ff2-13080ad0b14e"),
                            Name = "Giáo dục",
                            UrlSlug = "giao-duc"
                        });
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<int>("RateCount")
                        .HasColumnType("int");

                    b.Property<string>("ReviewedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRate")
                        .HasColumnType("int");

                    b.Property<string>("UrlSlug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSlug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8868ccad-c0fc-45b1-9f21-67e7ebf69d4a"),
                            Count = 0,
                            Name = "Giao thông",
                            UrlSlug = "giao-thong"
                        },
                        new
                        {
                            Id = new Guid("01da19e9-7763-4c98-86e7-34836fc73930"),
                            Count = 0,
                            Name = "Chính trị",
                            UrlSlug = "chinh-tri"
                        },
                        new
                        {
                            Id = new Guid("590eaa7f-fac1-46d9-8653-5010c32fcf8b"),
                            Count = 0,
                            Name = "Tuyến đầu chống dịch",
                            UrlSlug = "tuyen-dau-chong-dich"
                        },
                        new
                        {
                            Id = new Guid("d2514a38-eb91-4b0b-a65e-2c249afe2d4b"),
                            Count = 0,
                            Name = "Tuyển sinh",
                            UrlSlug = "tuyen-sinh"
                        },
                        new
                        {
                            Id = new Guid("b8575823-8f43-4e2a-b8cc-4695312d7822"),
                            Count = 0,
                            Name = "Điểm thi",
                            UrlSlug = "diem-thi"
                        },
                        new
                        {
                            Id = new Guid("5728903d-f608-44f0-8c32-24eb9412b331"),
                            Count = 0,
                            Name = "Du học",
                            UrlSlug = "du-hoc"
                        },
                        new
                        {
                            Id = new Guid("0eeadff0-ce09-4b26-8e6b-149ab73b5940"),
                            Count = 0,
                            Name = "Học tiếng Anh",
                            UrlSlug = "hoc-tieng-anh"
                        },
                        new
                        {
                            Id = new Guid("a5727b29-1578-4407-877f-b9d15f5cc4c6"),
                            Count = 0,
                            Name = "Trắc nghiệm",
                            UrlSlug = "trac-nghiem"
                        });
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<Guid>("PostsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTagMap");
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Comment", b =>
                {
                    b.HasOne("FA.JustBlogCore.Services.Model.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Post", b =>
                {
                    b.HasOne("FA.JustBlogCore.Services.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("FA.JustBlogCore.Services.Model.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.JustBlogCore.Services.Model.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FA.JustBlogCore.Services.Model.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
