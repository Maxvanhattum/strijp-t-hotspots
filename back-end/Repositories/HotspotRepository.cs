using Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories.Base;
using Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class HotspotRepository : BaseRepository<Hotspot>, IHotspotRepository
    {
        public HotspotRepository(DBContextApp dBContext) : base(dBContext)
        {
        }
        public override IEnumerable<Hotspot> GetAll()
        {
            return ts.Include(x => x.AR360)
                .Include(x => x.GeoCoordinates)
                .Include(x => x.Interview)
                .Include(x => x.Businesses)
                .ThenInclude(b => b.Address)
                .ToList();
        }

        public override Hotspot GetById(int id)
        {
            return ts.Include(x => x.AR360)
                .Include(x => x.GeoCoordinates)
                .Include(x => x.Interview)
                .Include(x => x.Businesses)
                .ThenInclude(b => b.Address)
                .FirstOrDefault(x => x.Id == id);
        }


    }
}
