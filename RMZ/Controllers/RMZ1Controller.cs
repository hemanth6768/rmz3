﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMZ.Context;
using RMZ.MODEL;
using RMZ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMZ1Controller : ControllerBase
    {
        private readonly RMZContext _context;
        private readonly IGetinformation _repository;
        public RMZ1Controller(RMZContext context, IGetinformation information)
        {
            _context = context;
            _repository = information; 
        }

        [HttpGet]
        [Route("REPORT INFORMATION AT LEVELS")]
        public object gethh(string facility, string data, string zoneid)
        {
            var result = _context.facility.FirstOrDefault(f=>f.Facilityname==data);

            if (zoneid == null)
            {
                if (result==null)
                {
                    var r = _repository.getbuilding(facility, data);
                    return r;
                }
                else
                {
                    var r = _repository.getfacility(facility, data);
                    return r;
                }
            }
            else
            {
                var r = _repository.getzone(facility, data, zoneid);
                return r;
            }
        }
    }
}
