using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdopt.Web.Infrastructure.Caching
{
    public interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback, TimeSpan? duration = null) where T : class;

        void Clear(string cacheId);
    }
}
