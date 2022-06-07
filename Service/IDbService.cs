using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Service
{
    public interface IDbService
    {
        Task<IEnumerable<object>> GetMusician(int IdDoctor);
        Task<bool> RemoveMusician(int IdDoctor);

    }
}