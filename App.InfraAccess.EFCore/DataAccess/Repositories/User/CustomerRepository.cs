﻿using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.User
{
    public class CustomerRepository(AppDbContext _appDbContext) : ICustomerRepository
    {
        public async Task CreateCustomer(int userId, string? address, CancellationToken cancellationToken)
        {
            var customer = new Customer { Id = userId, Address = address };
            await _appDbContext.Customers.AddAsync(customer, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> DeleteCustomer(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appDbContext.Customers
                    .FirstOrDefaultAsync(e => e.Id == customerId, cancellationToken);
                if (customer is null)
                    return new Result { IsSuccess = false, Message = "مشتری یافت نشد" };

                _appDbContext.Customers.Remove(customer);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "مشتری حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> SoftDeleteCustomer(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appDbContext.Customers
                    .FirstOrDefaultAsync(e => e.Id == customerId, cancellationToken);
                if (customer is null)
                    return new Result { IsSuccess = false, Message = "مشتری یافت نشد" };

                customer.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "مشتری حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appDbContext.Customers
                    .FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken);
                if (customer is null)
                    return new Result { IsSuccess = false, Message = "کارشناس یافت نشد" };

                customer.User.FirstName = model.FirstName;
                customer.User.LastName = model.LastName;
                customer.User.RoleId = model.RoleId;
                customer.User.Email = model.Email;
                customer.Address = model.Address;
                customer.CityId = model.CityId;


                _appDbContext.Customers.Update(customer);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کارشناس به‌روزرسانی شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }
    }

}
