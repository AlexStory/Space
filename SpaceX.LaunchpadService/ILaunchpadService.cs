using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceX.Models;

namespace SpaceX.LaunchpadService
{
    public interface ILaunchpadService
    {
        Task<List<Launchpad>> Get(int limit, int offset);
        Task<Launchpad> Get(string id);
    }
}
