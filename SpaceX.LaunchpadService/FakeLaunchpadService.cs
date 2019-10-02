using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceX.Models;
namespace SpaceX.LaunchpadService
{
    public class FakeLaunchpadService: ILaunchpadService
    {
#region dummy data
        private readonly List<Launchpad> _pads = new List<Launchpad>
        {
            new Launchpad
            {
                Id = "1",
                Name = "First Pad",
                Status = "boom"
            },
            new Launchpad
            {
                Id = "2",
                Name = "Second Pad",
                Status = "Thunderbirds"
            }
        };
#endregion

        public async Task<List<Launchpad>> Get (int limit = 0, int offset = 0)
        {
            return _pads;
        }

        public async Task<Launchpad> Get(string id)
        {
            return _pads.Find(x => x.Id == id);
        }
    }
}

