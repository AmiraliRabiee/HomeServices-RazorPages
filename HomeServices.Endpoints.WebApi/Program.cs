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
using App.InfraAccess.EFCore.DataAccess.Repositories.BaseEntities;
using App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices;
using App.InfraAccess.EFCore.DataAccess.Repositories.User;
using App.Infrastructure.Dapper;
using App.Infrastructure.EFCore.DataBase.Common;
using Framework;
using HomeServices.Endpoints.WebApi.WebFramework;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ApiKeyAuthenticationFilter>();


#region User Injects
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
builder.Services.AddScoped<IExpertService, ExpertService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
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

builder.Services.AddScoped<IExpertHouseWorkRepository, ExpertHouseWorkRepository>();
#endregion

#region BaseEntities Injects
builder.Services.AddScoped<IBaseDataAppService, BaseDataAppService>();
builder.Services.AddScoped<IBaseDataService, DataUserService>();

builder.Services.AddScoped<IDataService, DataWorkService>();
builder.Services.AddScoped<IDataService, DataCategoryService>();


builder.Services.AddScoped<ICityRepository, CityDapperRepository>();

builder.Services.AddScoped<IDashboardAppService, DashboardAppService>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
#endregion

#region Dapper Injects
builder.Services.AddScoped<ICategoryDapperRepository, CategoryDapperRepository>();
//builder.Services.AddScoped<ICityDapperRepository, CityDapperRepository>();
builder.Services.AddScoped<IHouseWorkDapperRepository, HouseWorkDapperRepository>();
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
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<PersianIdentityErrorDescriber>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
