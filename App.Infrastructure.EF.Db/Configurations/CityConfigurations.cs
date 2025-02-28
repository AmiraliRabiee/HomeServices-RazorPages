using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EFCore.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasData(new List<City>()
            {
                new City() { Id = 1, Name = "تهران" },
                new City() { Id = 2, Name = "مشهد" },
                new City() { Id = 3, Name = "اصفهان" },
                new City() { Id = 4, Name = "شیراز" },
                new City() { Id = 5, Name = "تبریز" },
                new City() { Id = 6, Name = "کرج" },
                new City() { Id = 7, Name = "قم" },
                new City() { Id = 8, Name = "اهواز" },
                new City() { Id = 9, Name = "رشت" },
                new City() { Id = 10, Name = "کرمانشاه" },
                new City() { Id = 11, Name = "زاهدان" },
                new City() { Id = 12, Name = "ارومیه" },
                new City() { Id = 13, Name = "یزد" },
                new City() { Id = 14, Name = "همدان" },
                new City() { Id = 15, Name = "قزوین" },
                new City() { Id = 16, Name = "سنندج" },
                new City() { Id = 17, Name = "بندرعباس" },
                new City() { Id = 18, Name = "زنجان" },
                new City() { Id = 19, Name = "ساری" },
                new City() { Id = 20, Name = "بوشهر" },
                new City() { Id = 21, Name = "مازندران" },
                new City() { Id = 22, Name = "گرگان" },
                new City() { Id = 23, Name = "کرمان" },
                new City() { Id = 24, Name = "خرم آباد" },
                new City() { Id = 25, Name = "سمنان" },
            });
        }
    }
}
