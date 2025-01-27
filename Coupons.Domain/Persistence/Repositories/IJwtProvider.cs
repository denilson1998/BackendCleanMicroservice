using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupons.Domain.Persistence.Repositories
{
    public interface IJwtProvider
    {
        string GenerateJwt(string email, string password);
    }
}
