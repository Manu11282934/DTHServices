using CQRS.Api.Models;
using CQRS.Api.Repositories.Admin;
using CQRS.Api.RequestModel.AdminSignIn;
using CQRS.Api.ResponseModels;
using CQRS.Api.Security.AuthToken;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.CommandHandler.Admin.AdminSignInHandler
{
    public class AdminSignInHandler : IRequestHandler<AdminLogin, RegisteredUserResponse>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserAuthTokenBuilder _userAuthTokenBuilder;
        public AdminSignInHandler(IUserAuthTokenBuilder userAuthTokenBuilder, IAdminRepository adminRepository)
        {
            _userAuthTokenBuilder = userAuthTokenBuilder;
            _adminRepository = adminRepository;
        }

        public async Task<RegisteredUserResponse> Handle(AdminLogin request, CancellationToken cancellationToken)
        {
            var registeredUser = await _adminRepository.Validate();
            var userDetails = new ApplicationUser()
            {
                Email = "order",
                LastName = "person",
                FirstName = "product",
            };
           string token =_userAuthTokenBuilder.IssueToken(userDetails);
            if (registeredUser != null)
            {      
                var response = new RegisteredUserResponse { User = registeredUser,Token= token };
                return response;
            }
            return null;
        }
    }
}
