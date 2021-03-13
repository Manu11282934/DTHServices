using CQRS.Api.Configurations;
using CQRS.Api.RequestModel;
using CQRS.Api.ResponseModel;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Api.Handler.QueryHandler
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdRequestModel, GetOrderByIdResponseModel>
    {
        private readonly AppSettings _appSettings;



        public GetOrderByIdQueryHandler( IOptions<AppSettings> appSettings)
        {           
            _appSettings = appSettings.Value;
        }
        public async Task<GetOrderByIdResponseModel> Handle(GetOrderByIdRequestModel request, CancellationToken cancellationToken)
        {
           string token = generateJwtToken();
            var orderDetails = new GetOrderByIdResponseModel()
            {
                Amount = 1.3,
                DateOrder = DateTime.Now,
                OrderId = Guid.NewGuid(),
                OrderName = "order",
                OrderPersonId = Guid.NewGuid(),
                OrderPersonName = "person",
                ProductId = Guid.NewGuid(),
                ProductName = "product",
                Quantity = 5
            };
            return orderDetails;
        }
        private string generateJwtToken()
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", "user.Id.ToString()") }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        
    }
}
}
