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
                new Category { Id = 1,Title = "تاسیسات" , ImagePath = "", ParentId = null},
                new Category { Id = 2, Title = "خانه"  , ImagePath = "", ParentId = null },
                new Category { Id = 3,Title = "نظافت"  , ImagePath = "", ParentId = null},
                new Category { Id = 4,Title = "زیبایی"  , ImagePath = "", ParentId = null},
                new Category { Id = 5,Title = "تعمیرات اشیا" , ImagePath = "" , ParentId = null},
                new Category { Id = 6,Title = " خودرو و حمل بار"  , ImagePath = "", ParentId = null},
                new Category { Id = 7,Title = "سلامت"  , ImagePath = "", ParentId = null},
                //new Category { Id = 8,Title = "آموزش" , ParentId = null , ImagePath = ""},

                new Category { Id = 8,Title = "برقکاری" , ParentId = 1 , ImagePath = "D:\\photos\\برقکاری کوچک.png"},
                new Category { Id = 9,Title = "لوله کشی" , ParentId = 1 , ImagePath = "D:\\photos\\لوله کشی.png"},
                new Category { Id = 10,Title = "سرمایش و گرمایش" , ParentId = 1 , ImagePath = "D:\\photos\\سرمایش گرمایش.png"},

                new Category { Id = 11, Title = "تعمیرات ساختمان" , ParentId = 2 , ImagePath = "D:\\photos\\تعمیرات ساختمان.png" },
                new Category { Id = 12,Title = "شیشه کاری" , ParentId = 2 , ImagePath = "D:\\photos\\بازسازی.png"},
                new Category { Id = 13,Title = "باغبانی" , ParentId = 2 , ImagePath = "D:\\photos\\باغبانی.png"},

                new Category { Id = 14,Title = "نظافت و پذیرایی" , ParentId = 3 , ImagePath = ""},
                new Category { Id = 15, Title = "شستشو" , ParentId = 3 , ImagePath = "" },
                new Category { Id = 16,Title = "کارواش و دیتیلینگ" , ParentId = 3 , ImagePath = ""},

                new Category { Id = 17,Title = "زیبایی بانوان" , ParentId = 4 , ImagePath = ""},
                new Category { Id = 18,Title = "پیرایش و زیبایی آقایان" , ParentId = 4 , ImagePath = ""},
                new Category { Id = 19,Title = "تندرستی و ورزش" , ParentId = 4 , ImagePath = ""},

                new Category { Id = 20,Title = "نصب و تعمیر لوازم خانگی" , ParentId = 5 , ImagePath = ""},
                new Category { Id = 21,Title = "خدمات کامپیوتری" , ParentId = 5 , ImagePath = ""},
                new Category { Id = 22,Title = "تعمیرات موبایل" , ParentId = 5 , ImagePath = ""},

                new Category { Id = 23,Title = "خدمات و تعمیرات خودرو" , ParentId = 6 , ImagePath = ""},
                new Category { Id = 24,Title = "باربری و جابجایی" , ParentId = 6 , ImagePath = ""},

                new Category { Id = 25,Title = "پرشکی و پرستاری" , ParentId = 7 , ImagePath = ""},
                new Category { Id = 26,Title = "حیوانات خانگی" , ParentId = 7 , ImagePath = ""},

            });
        }

    }
}

