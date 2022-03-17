﻿using WestwindSystem.DAL; // for WestwindContext
using WestwindSystem.Entities;  // for Region

namespace WestwindSystem.BLL
{
    public class RegionServices
    {
        private readonly WestwindContext _context;

        internal RegionServices(WestwindContext context)
        {
            _context = context; 
        }

        public List<Region> Region_List()
        {
            return _context
                .Regions
                .OrderBy(currentItem => currentItem.RegionDescription)
                .ToList();
        }

        public Region? Region_GetById(int regionId)
        {
            return _context
                .Regions
                .Where(currentItem => currentItem.RegionID == regionId)
                .FirstOrDefault();
        }
    }
}
