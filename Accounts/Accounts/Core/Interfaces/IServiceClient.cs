using Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Core.Interfaces
{
    public interface IServiceClient
    {
        Task<IEnumerable<Account>> GetListOfAccountsAsync();
        
    }
}
