using App.Domain.Core.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.Configurations
{
    public class HouseWorkConfigurations : IEntityTypeConfiguration<HouseWork>
    {
        public void Configure(EntityTypeBuilder<HouseWork> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Description).HasMaxLength(1000);
            builder.Property(h => h.ViewCount).HasDefaultValue(1);
            builder.Property(x => x.BasePrice).HasDefaultValue(10000).IsRequired();
            builder.Property(h => h.BasePrice).HasColumnType("decimal(18,2)");

            builder.HasOne(h => h.Category)
                .WithMany()
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(h => h.Expert)
                .WithMany(e => e.Skills);

            builder.HasData(new List<HouseWork>
            {//سرمایش و گرمایش
                new HouseWork { Id = 1 , Title = "تعمیر و سرویس پکیج" , BasePrice  = 5000 , Description = "نیاز به توضیحات تکمیلی مشکل" , CategoryId = 10 },
                new HouseWork { Id = 2 , Title = "تعمیر و سرویس آبگرمکن" , BasePrice  = 3000 , Description = "" , CategoryId = 10},
                new HouseWork { Id = 3 , Title = "نصب و تعمیر رادیاتور شوفاژ" , BasePrice  = 3500 , Description = "" , CategoryId = 10},
                new HouseWork { Id = 4 , Title = "تعمیر و سرویس کولر آبی" , BasePrice  = 4000 , Description = "پرتقاضا" , CategoryId = 10},
                new HouseWork { Id = 5 , Title = "تعمیر و نصب کولر گازی" , BasePrice  = 2500 , Description = "" , CategoryId = 10 },

                //لوله کشی
                new HouseWork { Id = 6 , Title = "نصب و تعمیر شیرآلات" , BasePrice  = 5000 , Description = "نیاز به توضیحات تکمیلی مشکل" , CategoryId = 9 },
                new HouseWork { Id = 7 , Title = "تخلیه چاه و لوله بازکنی" , BasePrice  = 4000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 8 , Title = "نصب و تعمیر دستگاه تصفیه آب" , BasePrice  = 1000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 9 , Title = "لوله کشی گاز" , BasePrice  = 2000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 10 , Title = "اتصال به شبکه فاضلاب شهری" , BasePrice  = 4000 , Description = "به صورت تخصصی" , CategoryId = 9 },

                //برقکاری
                new HouseWork { Id = 11 , Title = "سیم و کابل کشی" , BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 8 },
                new HouseWork { Id = 12 , Title = "رفع اتصالی" , BasePrice  = 3500 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 13 , Title = "کلید و پریز" , BasePrice  = 1000 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 14 , Title = "نصب و تعویض فیوز" , BasePrice  = 3500 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 15 , Title = "نصب و تعمیر دوربین مداربسته" , BasePrice  = 2000 , Description = "" , CategoryId = 8 },

                //تعمیرات ساختمان
                new HouseWork { Id = 16 , Title = "نقاشی ساختمان" , BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 11 },
                new HouseWork { Id = 17 , Title = "نصب کاغذ دیواری" , BasePrice  = 3500 , Description = "" , CategoryId = 11 },
                new HouseWork { Id = 18 , Title = "ساخت و نصب توری" , BasePrice  = 2000 , Description = "" , CategoryId = 11 },
                new HouseWork { Id = 19 , Title = "بنایی" , BasePrice  = 1000 , Description = "" , CategoryId = 11 },
                new HouseWork { Id = 20 , Title = "کفسابی" , BasePrice  = 3500 , Description = "به صورت تخصصی" , CategoryId = 11 },

                //شیشه کاری
                new HouseWork { Id = 21 , Title = "ساخت و نصب درب و پنجره" , BasePrice  = 1000 , Description = "" , CategoryId = 12 },
                new HouseWork { Id = 22 , Title = "شیشه بری و آینه کاری" , BasePrice  = 3500 , Description = "" , CategoryId = 12 },
                new HouseWork { Id = 23 , Title = "هندریل شیشه ای" , BasePrice  = 2000 , Description = "جدید" , CategoryId = 12 },
                new HouseWork { Id = 24 , Title = "پارتیشن شیشه ای" , BasePrice  = 1000 , Description = "" , CategoryId = 12 },
                new HouseWork { Id = 25 , Title = "نصب و تعمیر درب اتوماتیک" , BasePrice  = 3500 , Description = "" , CategoryId = 12 },

                //باغبانی
                new HouseWork { Id = 26 , Title = " مشاوره گل و گیاه" , BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 13 },
                new HouseWork { Id = 27 , Title = "تشخیص و کنترل آفت" , BasePrice  = 3500 , Description = "" , CategoryId = 13 },
                new HouseWork { Id = 28 , Title = "رسیگی به فضای سبز" , BasePrice  = 2000 , Description = "" , CategoryId = 13 },

                //نظافت و پذیرایی
                new HouseWork { Id = 29 , Title = "سرویس عادی نظافت" , BasePrice  = 1000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 30 , Title = "سرویس لوکس نظافت" , BasePrice  = 3500 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 31 , Title = "پذیرایی" , BasePrice  = 2000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 32 , Title = "کارگر ساده" , BasePrice  = 1000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 33 , Title = "نظافت راه پله" , BasePrice  = 3500 , Description = "" , CategoryId = 14 },

                //شستشو
                new HouseWork { Id = 34 , Title = "شستشو در منزل" , BasePrice  = 1000 , Description = "(فرش ، موکت ، مبل)" , CategoryId = 15 },
                new HouseWork { Id = 35 , Title = "قالیشویی" , BasePrice  = 3500 , Description = "" , CategoryId = 15 },
                new HouseWork { Id = 36 , Title = "خشکشویی" , BasePrice  = 2000 , Description = "" , CategoryId = 15 },
                new HouseWork { Id = 37 , Title = "پرده شویی" , BasePrice  = 1000 , Description = "" , CategoryId = 15 },

                //کارواش و دیتیلینگ
                new HouseWork { Id = 38 , Title = "کارواش" , BasePrice  = 1000 , Description = "(آب ، نانو)" , CategoryId = 16 },
                new HouseWork { Id = 39 , Title = "صفرشویی خودرو" , BasePrice  = 3500 , Description = "" , CategoryId = 16 },
                new HouseWork { Id = 40 , Title = "سرامیک حودرو" , BasePrice  = 2000 , Description = "جدید" , CategoryId = 16 },
                new HouseWork { Id = 41 , Title = "واکس و پولیش" , BasePrice  = 1000 , Description = "" , CategoryId = 16 },
                new HouseWork { Id = 42 , Title = "صافکاری و نقاشی" , BasePrice  = 3500 , Description = "به صورت تخصصی" , CategoryId = 16 },

               //زیبایی بانوان
                new HouseWork { Id = 43 , Title = "خدمات ناخن" , BasePrice  = 1000 , Description = "" , CategoryId = 17 },
                new HouseWork { Id = 44 , Title = " رنگ مو در منزل" , BasePrice  = 3500 , Description = "" , CategoryId = 17 },
                new HouseWork { Id = 45 , Title = "پاکسازی و لایه برداری پوست" , BasePrice  = 2000 , Description = "جدید" , CategoryId = 17 },
                new HouseWork { Id = 46 , Title = "آرایش صورت در منزل" , BasePrice  = 1000 , Description = "" , CategoryId = 17 },
                new HouseWork { Id = 47 , Title = "لیفت و لیمنت مژه" , BasePrice  = 3500 , Description = "" , CategoryId = 17 },
                
                //پیرایش وزیبایی آقایان
                new HouseWork { Id = 48 , Title = "کوتاهی مو و اصلاح صورت" , BasePrice  = 1000 , Description = "" , CategoryId = 18 },
                new HouseWork { Id = 49 , Title = "مراقب و زیبایی آقایان" , BasePrice  = 3500 , Description = "" , CategoryId = 18 },
                new HouseWork { Id = 50 , Title = "گریم داماد" , BasePrice  = 2000 , Description = "" , CategoryId = 18 },

                //تندرستی و ورزش
                new HouseWork { Id = 51 , Title = "برنامه ورزشی و تغذیه" , BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 19 },
                new HouseWork { Id = 52 , Title = "کلاس یوگا در خانه" , BasePrice  = 3500 , Description = "" , CategoryId = 19 },
                new HouseWork { Id = 53 , Title = "کلاس پیلاتس در خانه" , BasePrice  = 2000 , Description = "" , CategoryId = 19 },
                new HouseWork { Id = 54 , Title = "کلاس سی ایکس در خانه" , BasePrice  = 1000 , Description = "جدید" , CategoryId = 19 },
                new HouseWork { Id = 55 , Title = "حرکات اصلاحی" , BasePrice  = 3500 , Description = "" , CategoryId = 19 },

                //نصب و تعمیر لوازم خانگی
                new HouseWork { Id = 56 , Title = "نصب و تعمیر یخچال فریزر" , BasePrice  = 1000 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 57 , Title = " نصب و تعمیر ماشین ظرفشویی" , BasePrice  = 3500 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 58 , Title = "نصب و تعمیر ماشین لباسشویی" , BasePrice  = 2000 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 59 , Title = "نصب و تعمیر فر" , BasePrice  = 1000 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 60 , Title = "نصب و تعمیر هود آشپرخانه" , BasePrice  = 3500 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 61 , Title = "نصب و تعمیر اجاق گاز" , BasePrice  = 1000 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 62 , Title = " تعمیرات تلویزیون" , BasePrice  = 3500 , Description = "به صورت تخصصی" , CategoryId = 20 },
                new HouseWork { Id = 63 , Title = "تعمیر چای ساز و قهوه ساز" , BasePrice  = 2000 , Description = "جدید" , CategoryId = 20 },
                new HouseWork { Id = 64 , Title = "تعمیر جاروبرقی" , BasePrice  = 1000 , Description = "" , CategoryId = 20 },
                new HouseWork { Id = 65 , Title = "نصب و تعویض فیلتر آب" , BasePrice  = 3500 , Description = "" , CategoryId = 20 },

               //خدمات کامپیوتری
                new HouseWork { Id = 66 , Title = "تعمیر کامپیوتر و لپتاپ" , BasePrice  = 1000 , Description = "" , CategoryId = 21 },
                new HouseWork { Id = 67 , Title = " تعمیر ماشین های اداری" , BasePrice  = 3500 , Description = "" , CategoryId = 21 },
                new HouseWork { Id = 68 , Title = "پشتیبانی شبکه وسرور" , BasePrice  = 2000 , Description = "" , CategoryId = 21 },
                new HouseWork { Id = 69 , Title = "طراحی سایت و لوگو" , BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 21 },
                new HouseWork { Id = 70 , Title = "مودم و اینترنت" , BasePrice  = 3500 , Description = "" , CategoryId = 21 },

                //تعمیرات موبایل
                new HouseWork { Id = 71 , Title = "خدمات تاچ و ال سی دی" , BasePrice  = 1000 , Description = "" , CategoryId = 22 },
                new HouseWork { Id = 72 , Title = " خدمات باتری" , BasePrice  = 3500 , Description = "" , CategoryId = 22 },
                new HouseWork { Id = 73 , Title = "خدمات نرم افزاری" , BasePrice  = 2000 , Description = "جدید" , CategoryId = 22 },
                new HouseWork { Id = 74 , Title = "خدمات اسپیکر" , BasePrice  = 1000 , Description = "" , CategoryId = 22 },
                new HouseWork { Id = 75 , Title = "خدمات دوربین" , BasePrice  = 3500 , Description = "" , CategoryId = 22 },

                // خدمات و تعمیرات خودرو
                new HouseWork { Id = 76 , Title = "تعویض باتری خودرو" , BasePrice  = 1000 , Description = "زیر قیمت کارخانه" , CategoryId = 23 },
                new HouseWork { Id = 77 , Title = " برق و باتری خودرو" , BasePrice  = 3500 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 78 , Title = "مکانیکی خودرو" , BasePrice  = 2000 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 79 , Title = "امداد خودرو" , BasePrice  = 1000 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 80 , Title = "پنچرگیری" , BasePrice  = 3500 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 81 , Title = "کارشناسی خودرو" , BasePrice  = 1000 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 82 , Title = "تعویض لاستیک" , BasePrice  = 3500 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 83 , Title = "تعویض لنت خودرو" , BasePrice  = 2000 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 84 , Title = "سوخت رسانی" , BasePrice  = 1000 , Description = "" , CategoryId = 23 },
                new HouseWork { Id = 85 , Title = "تعمیر موتور سیکلت" , BasePrice  = 3500 , Description = "" , CategoryId = 23 },

                //خدمات باربری
                new HouseWork { Id = 86 , Title = "اسباب کشی با خاور و کامیون" , BasePrice  = 1000 , Description = "" , CategoryId = 24 },
                new HouseWork { Id = 87 , Title = " اسباب کشی با وانت و نیسان" , BasePrice  = 3500 , Description = "" , CategoryId = 24 },
                new HouseWork { Id = 88 , Title = "اسباب کشی و حمل بین شهری" , BasePrice  = 2000 , Description = "نیاز به توضیح" , CategoryId = 24 },
                new HouseWork { Id = 89 , Title = "کارگر جابجایی" , BasePrice  = 1000 , Description = "" , CategoryId = 24 },
                new HouseWork { Id = 90 , Title = "حمل نخاله و ضایعات ساختمانی" , BasePrice  = 3500 , Description = "" , CategoryId = 24 },

                //پزشکی و پرستاری
                new HouseWork { Id = 91 , Title = "مراقبت و نگهداری" , BasePrice  = 1000 , Description = "" , CategoryId = 25 },
                new HouseWork { Id = 92 , Title = " پرستاری و تزریقات" , BasePrice  = 3500 , Description = "" , CategoryId = 25 },
                new HouseWork { Id = 93 , Title = "معاینه پزشکی" , BasePrice  = 2000 , Description = "" , CategoryId = 25 },
                new HouseWork { Id = 94 , Title = "پیراپزشکی" , BasePrice  = 1000 , Description = "" , CategoryId = 25 },
                new HouseWork { Id = 95 , Title = "آزمایش و نمونه گیری" , BasePrice  = 3500 , Description = "" , CategoryId = 25 },


                //حیوانات خانکی
                new HouseWork { Id = 96 , Title = "هتل های حیوانات خانگی" , BasePrice  = 1000 , Description = "جدید" , CategoryId = 26 },
                new HouseWork { Id = 97 , Title = " خدماتدامپزشکی در محل" , BasePrice  = 3500 , Description = "" , CategoryId = 26 },
                new HouseWork { Id = 98 , Title = "خدمات تربیتی حیوانات خانگی" , BasePrice  = 2000 , Description = "به صورت تخصصی" , CategoryId = 26 },
                new HouseWork { Id = 99 , Title = "خدمات شستشو و آرایشی" , BasePrice  = 1000 , Description = "" , CategoryId = 26 },
                new HouseWork { Id = 100 , Title = "پت شاپ" , BasePrice  = 3500 , Description = "" , CategoryId = 26 },
            });

        }
    }
}
