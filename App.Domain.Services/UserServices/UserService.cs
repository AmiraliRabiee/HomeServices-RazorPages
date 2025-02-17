﻿using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Contracts.Service;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken)
            => _userRepository.ChangeStatus(user, cancellationToken);

        public Task<Result> DeleteUser(AppUser user, CancellationToken cancellationToken)
            => _userRepository.DeleteUser(user, cancellationToken);

        public Task<List<Customer>> GetAllCustomers()
            => _userRepository.GetAllCustomers();

        public Task<List<Expert>> GetAllExperts()
            => _userRepository.GetAllExperts();
        public Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken)
            => _userRepository.GetUserDetails(id, cancellationToken);

        public Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken)
            => _userRepository.SoftDeleteUser(user, cancellationToken); 

        public Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken) 
            => _userRepository.UpdateBalance(user, cancellationToken);

        public Task<Result> UpdateUser(AppUser user, CancellationToken cancellationToken)
            => _userRepository.UpdateUser(user, cancellationToken); 
    }
}
