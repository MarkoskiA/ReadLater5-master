using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    //Service for getting current user
    public interface ICurrenUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}
