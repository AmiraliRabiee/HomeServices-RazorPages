
#region
using App.Domain.AppServices.Base;
using App.Domain.AppServices.HomeService;
using App.Domain.AppServices.User;
using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Repository.BaseEntities;
using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.BaseEntities;
using App.Domain.Core.Contracts.Service.HomeServices;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Entites.User;
using App.Domain.Services.Base;
using App.Domain.Services.HomeService;
using App.Domain.Services.User;
using App.Infrastructure.EFCore.DataAccess.Repositories.BaseEntities;
using App.Infrastructure.EFCore.DataAccess.Repositories.HomeServices;
using App.Infrastructure.EFCore.DataAccess.Repositories.User;
using App.Infrastructure.EFCore.DataBase.Common;
using Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

#region User Injects
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertService, ExpertService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
#endregion

#region HomeService Injects
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();


builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();
builder.Services.AddScoped<ISuggestionService, SuggestionService>();
builder.Services.AddScoped<ISuggestionAppService, SuggestionAppService>();


builder.Services.AddScoped<IHouseWorkRepository, HouseWorkRepository>();
builder.Services.AddScoped<IHouseWorkService, HouseWorkService>();
builder.Services.AddScoped<IHouseWorkAppService, HouseWorkAppService>();
#endregion

#region BaseEntities Injects
builder.Services.AddScoped<IBaseDataAppService, BaseDataAppService>();
builder.Services.AddScoped<IBaseDataService, DataUserService>();

builder.Services.AddScoped<IDataService, DataWorkService>();
builder.Services.AddScoped<IDataService, DataCategoryService>();


builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<IDashboardAppService, DashboardAppService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
#endregion

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>(); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssests();

app.MapRazorPages();

app.Run();
