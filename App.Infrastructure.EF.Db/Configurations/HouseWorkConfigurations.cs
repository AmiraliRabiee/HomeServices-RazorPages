using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Entites.Service;

namespace App.Infrastructure.EFCore.Configurations
{
    public class HouseWorkConfigurations : IEntityTypeConfiguration<HouseWork>
    {
        public void Configure(EntityTypeBuilder<HouseWork> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Description).HasMaxLength(1000);
            builder.Property(h => h.ViewCount).HasDefaultValue(1);
            builder.Property(h => h.BasePrice).HasColumnType("decimal(18,2)");

            builder.HasOne(h => h.Category)
                .WithMany()
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(new List<HouseWork>
            {//سرمایش و گرمایش
                new HouseWork { Id = 1 , Title = "تعمیر و سرویس پکیج" ,ImagePath = "\\Images\\HomeServices\\1h.jpg", BasePrice  = 5000 , Description = "نیاز به توضیحات تکمیلی مشکل" , CategoryId = 10 },
                new HouseWork { Id = 2 , Title = "تعمیر و سرویس آبگرمکن" ,ImagePath = "\\Images\\HomeServices\\2h.jpg", BasePrice  = 3000 , Description = "" , CategoryId = 10},
                new HouseWork { Id = 3 , Title = "نصب و تعمیر رادیاتور شوفاژ" ,ImagePath = "\\Images\\HomeServices\\3h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 10},
                new HouseWork { Id = 4 , Title = "تعمیر و سرویس کولر آبی" ,ImagePath = "\\Images\\HomeServices\\4h.jpg", BasePrice  = 4000 , Description = "پرتقاضا" , CategoryId = 10},
                new HouseWork { Id = 5 , Title = "تعمیر و نصب کولر گازی" ,ImagePath = "\\Images\\HomeServices\\5h.jpg", BasePrice  = 2500 , Description = "" , CategoryId = 10 },

                //لوله کشی
                new HouseWork { Id = 6 , Title = "نصب و تعمیر شیرآلات" , ImagePath = "\\Images\\HomeServices\\6h.jpg",BasePrice  = 5000 , Description = "نیاز به توضیحات تکمیلی مشکل" , CategoryId = 9 },
                new HouseWork { Id = 7 , Title = "تخلیه چاه و لوله بازکنی" ,ImagePath = "\\Images\\HomeServices\\7h.jpg", BasePrice  = 4000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 8 , Title = "نصب و تعمیر دستگاه تصفیه آب" ,ImagePath = "\\Images\\HomeServices\\8h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 9 , Title = "لوله کشی گاز" , ImagePath = "\\Images\\HomeServices\\9h.jpg", BasePrice  = 2000 , Description = "" , CategoryId = 9 },
                new HouseWork { Id = 10 , Title = "اتصال به شبکه فاضلاب شهری" ,ImagePath = "\\Images\\HomeServices\\10h.jpg", BasePrice  = 4000 , Description = "به صورت تخصصی" , CategoryId = 9 },

                //برقکاری
                new HouseWork { Id = 11 , Title = "سیم و کابل کشی" ,ImagePath = "\\Images\\HomeServices\\11h.png", BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 8 },
                new HouseWork { Id = 12 , Title = "رفع اتصالی" ,ImagePath = "\\Images\\HomeServices\\12h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 13 , Title = "کلید و پریز" ,ImagePath = "\\Images\\HomeServices\\13h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 14 , Title = "نصب و تعویض فیوز" ,ImagePath = "\\Images\\HomeServices\\14h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 8 },
                new HouseWork { Id = 15 , Title = "نصب و تعمیر دوربین مداربسته" ,ImagePath = "\\Images\\HomeServices\\15h.jpg", BasePrice  = 2000 , Description = "" , CategoryId = 8 },

                ////تعمیرات ساختمان
                //new HouseWork { Id = 16 , Title = "نقاشی ساختمان" ,ImagePath = "\\Images\\HomeServices\\16h.png", BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 11 },
                //new HouseWork { Id = 17 , Title = "نصب کاغذ دیواری" ,ImagePath = "\\Images\\HomeServices\\17h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 11 },
                //new HouseWork { Id = 18 , Title = "ساخت و نصب توری" ,ImagePath = "\\Images\\HomeServices\\18h.jpg", BasePrice  = 2000 , Description = "" , CategoryId = 11 },
                //new HouseWork { Id = 19 , Title = "بنایی" ,ImagePath = "\\Images\\HomeServices\\19h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 11 },
                //new HouseWork { Id = 20 , Title = "کفسابی" ,ImagePath = "\\Images\\HomeServices\\20h.jpg", BasePrice  = 3500 , Description = "به صورت تخصصی" , CategoryId = 11 },

                ////شیشه کاری
                //new HouseWork { Id = 21 , Title = "ساخت و نصب درب و پنجره" ,ImagePath = "\\Images\\HomeServices\\21h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 12 },
                //new HouseWork { Id = 22 , Title = "شیشه بری و آینه کاری" ,ImagePath = "\\Images\\HomeServices\\22h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 12 },
                //new HouseWork { Id = 23 , Title = "هندریل شیشه ای" , ImagePath = "\\Images\\HomeServices\\23h.jpg", BasePrice  = 2000 , Description = "جدید" , CategoryId = 12 },
                //new HouseWork { Id = 24 , Title = "پارتیشن شیشه ای" ,ImagePath = "\\Images\\HomeServices\\24h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 12 },
                //new HouseWork { Id = 25 , Title = "نصب و تعمیر درب اتوماتیک" ,ImagePath = "\\Images\\HomeServices\\25h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 12 },

                ////باغبانی
                //new HouseWork { Id = 26 , Title = " مشاوره گل و گیاه" , ImagePath = "\\Images\\HomeServices\\26h.png",BasePrice  = 1000 , Description = "به صورت تخصصی" , CategoryId = 13 },
                //new HouseWork { Id = 27 , Title = "تشخیص و کنترل آفت" ,ImagePath = "\\Images\\HomeServices\\27h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 13 },
                //new HouseWork { Id = 28 , Title = "رسیگی به فضای سبز" ,ImagePath = "\\Images\\HomeServices\\28h.jpg", BasePrice  = 2000 , Description = "" , CategoryId = 13 },

                //نظافت و پذیرایی
                new HouseWork { Id = 29 , Title = "سرویس عادی نظافت" ,ImagePath = "\\Images\\HomeServices\\29h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 30 , Title = "سرویس لوکس نظافت" ,ImagePath = "\\Images\\HomeServices\\30h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 31 , Title = "پذیرایی" ,ImagePath = "\\Images\\HomeServices\\31h.jpg", BasePrice  = 2000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 32 , Title = "کارگر ساده" ,ImagePath = "\\Images\\HomeServices\\32h.jpg", BasePrice  = 1000 , Description = "" , CategoryId = 14 },
                new HouseWork { Id = 33 , Title = "نظافت راه پله" , ImagePath = "\\Images\\HomeServices\\33h.jpg", BasePrice  = 3500 , Description = "" , CategoryId = 14 },

                //شستشو
                new HouseWork { Id = 34 , Title = "شستشو در منزل" ,ImagePath = "", BasePrice  = 1000 , Description = "(فرش ، موکت ، مبل)" , CategoryId = 15 },
                new HouseWork { Id = 35 , Title = "قالیشویی" , ImagePath = "",BasePrice  = 3500 , Description = "" , CategoryId = 15 },
                new HouseWork { Id = 36 , Title = "خشکشویی" , ImagePath = "",BasePrice  = 2000 , Description = "" , CategoryId = 15 },
                new HouseWork { Id = 37 , Title = "پرده شویی" ,ImagePath = "", BasePrice  = 1000 , Description = "" , CategoryId = 15 },

                //کارواش و دیتیلینگ
                new HouseWork { Id = 38 , Title = "کارواش" ,ImagePath = "", BasePrice  = 1000 , Description = "(آب ، نانو)" , CategoryId = 16 },
                new HouseWork { Id = 39 , Title = "صفرشویی خودرو" ,ImagePath = "", BasePrice  = 3500 , Description = "" , CategoryId = 16 },
                new HouseWork { Id = 40 , Title = "سرامیک حودرو" ,ImagePath = "", BasePrice  = 2000 , Description = "جدید" , CategoryId = 16 },
                new HouseWork { Id = 41 , Title = "واکس و پولیش" ,ImagePath = "", BasePrice  = 1000 , Description = "" , CategoryId = 16 },
                new HouseWork { Id = 42 , Title = "صافکاری و نقاشی" ,ImagePath = "", BasePrice  = 3500 , Description = "به صورت تخصصی" , CategoryId = 16 },

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

         public static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<ExpertHouseWork>().HasData
            (
            new { ExpertId = 1, HouseWorkId = 1 },
            new { ExpertId = 1, HouseWorkId = 3 }
            );
        }
    }
}
