using RMZ.Context;
using RMZ.MODEL;
using System.Collections.Generic;
using System.Linq;

namespace RMZ.Repository
{
    public class Getinformation : IGetinformation
    {
        private readonly RMZContext _context;
        public Getinformation(RMZContext context)
        {
            _context=context;
        }
        public object getzone(string facility, string data,string id)
        {
            var result = _context.zones.Where(x => x.ZoneId == id).FirstOrDefault();              
            return result;
        }

        public object getbuilding(string facility, string data)
        {
            var result = _context.buildings.Where(x => x.BuildingName==data && x.Facility.Facilityname==facility).Join(_context.facility, b => b.Facility.FacilityId, f => f.FacilityId, (b, f) => new
            {
                f,
                b
            }).Join(_context.zones, z =>z.b.Bid, g => g.Building.Bid, (z, g) => new
            {
                facilityname = z.f.Facilityname,
                buildingname = z.b.BuildingName,
                zoneid = g.ZoneId,
                floornumber = g.Floornumber,
                electricmeter = g.Eletricmeter,
                watermeter = g.watermeteer,
            });

            return result;
        }

        public object getfacility(string facility, string data)
        {
            var result = _context.facility.Where(x =>x.Facilityname==facility).Join(_context.buildings, f => f.FacilityId, b => b.Facility.FacilityId, (f,b) => new
            {
                f,
                b
            }).Join(_context.zones, z => z.b.Bid, g => g.Building.Bid, (z, g) => new
            {
                facilityname = z.f.Facilityname,
                buildingname = z.b.BuildingName,
                zoneid = g.ZoneId,
                floornumber = g.Floornumber,
                electricmeter = g.Eletricmeter,
                watermeter = g.watermeteer,
            });

            return result;

        }
    }
}
