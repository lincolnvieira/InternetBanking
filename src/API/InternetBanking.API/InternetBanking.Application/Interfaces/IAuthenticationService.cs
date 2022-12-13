using InternetBanking.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task AddUser(AddUserRequest addUserRequest);
        void AuthenticateUser();
    }
}
