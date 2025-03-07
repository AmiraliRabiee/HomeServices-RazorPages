using App.Domain.Core.Entites.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.ParentCategory)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Category>
            {
                new Category { Id = 1,Title = "تاسیسات" , ImagePath = "\\Images\\Categories\\tasisat1.jpg", ParentId = null},
                //new Category { Id = 2, Title = "خانه"  , ImagePath = "\\Images\\Categories\\Home.jpg", ParentId = null },
                new Category { Id = 3,Title = "نظافت"  , ImagePath = "\\Images\\Categories\\3 فعلی.jpg", ParentId = null},
                new Category { Id = 4,Title = "زیبایی"  , ImagePath = "\\Images\\Categories\\zibaii.jpg", ParentId = null},
                new Category { Id = 5,Title = "تعمیرات اشیا" , ImagePath = "\\Images\\Categories\\tamirat.jpg" , ParentId = null},
                new Category { Id = 6,Title = "خودرو"  , ImagePath = "\\Images\\Categories\\6 فعلی (2).jpg", ParentId = null},
                new Category { Id = 7,Title = "سلامت"  , ImagePath = "\\Images\\Categories\\7 فعلی.jpg", ParentId = null},
                //new Category { Id = 8,Title = "آموزش" , ParentId = null , ImagePath = ""},

                new Category { Id = 8,Title = "برقکاری" , ParentId = 1 , ImagePath = "\\Images\\Categories\\8 فعلی.png"},
                new Category { Id = 9,Title = "لوله کشی" , ParentId = 1 , ImagePath = "\\Images\\Categories\\9 فعلی.png"},
                new Category { Id = 10,Title = "سرمایش و گرمایش" , ParentId = 1 , ImagePath = "\\Images\\Categories\\10 فعلی.png"},

                //new Category { Id = 11, Title = "تعمیرات ساختمان" , ParentId = 2 , ImagePath = "\\Images\\Categories\\11 فعلی.png" },
                //new Category { Id = 12,Title = "شیشه کاری" , ParentId = 2 , ImagePath = "\\Images\\Categories\\12 فعلی.jpg"},
                //new Category { Id = 13,Title = "باغبانی" , ParentId = 2 , ImagePath = "\\Images\\Categories\\13 فعلی.png"},

                new Category { Id = 14,Title = "نظافت و پذیرایی" , ParentId = 3 , ImagePath = "\\Images\\Categories\\916efcce-9fdb-45ac-9d9b-8b821748a1f5-category_image (2).png"},
                new Category { Id = 15, Title = "شستشو" , ParentId = 3 , ImagePath = "\\Images\\Categories\\15فعلی.png" },
                new Category { Id = 16,Title = "کارواش و دیتیلینگ" , ParentId = 3 , ImagePath = "\\Images\\Categories\\16 فعلی.png"},

                new Category { Id = 17,Title = "زیبایی بانوان" , ParentId = 4 , ImagePath = "\\Images\\Categories\\17.png"},
                new Category { Id = 18,Title = "پیرایش و زیبایی آقایان" , ParentId = 4 , ImagePath = "\\Images\\Categories\\18.png"},
                new Category { Id = 19,Title = "تندرستی و ورزش" , ParentId = 4 , ImagePath = "\\Images\\Categories\\19.png"},

                new Category { Id = 20,Title = "نصب و تعمیر لوازم خانگی" , ParentId = 5 , ImagePath = "\\Images\\Categories\\20.png"},
                new Category { Id = 21,Title = "خدمات کامپیوتری" , ParentId = 5 , ImagePath = "\\Images\\Categories\\21.png"},
                new Category { Id = 22,Title = "تعمیرات موبایل" , ParentId = 5 , ImagePath = "\\Images\\Categories\\22.png"},

                new Category { Id = 23,Title = "خدمات و تعمیرات خودرو" , ParentId = 6 , ImagePath = "\\Images\\Categories\\23.png"},
                new Category { Id = 24,Title = "باربری و جابجایی" , ParentId = 6 , ImagePath = "\\Images\\Categories\\24.png"},

                new Category { Id = 25,Title = "پرشکی و پرستاری" , ParentId = 7 , ImagePath = "\\Images\\Categories\\25.png"},
                new Category { Id = 26,Title = "حیوانات خانگی" , ParentId = 7 , ImagePath = "\\Images\\Categories\\26.png"},

            });
        }

    }
}

