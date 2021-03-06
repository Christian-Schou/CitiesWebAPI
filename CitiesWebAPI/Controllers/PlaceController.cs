﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesWebAPI.Data;
using CitiesWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly CityDataContext _db;
        public PlaceController(CityDataContext db)
        {
            _db = db;
        }

        [Route("Places/{cityId}")]
        public IActionResult GetPlaces(int cityId)
        {
            List<Place> places = _db.Places.Where(x => x.CityId == cityId).ToList();

            return new ObjectResult(places);
        }

        [Route("City/{cityId}/place/{placeId}")]
        public IActionResult GetCity(int cityId, int placeId)
        {

            if (!_db.Places.ToList().Exists(x => x.CityId == cityId && x.Id == placeId))
            {
                return NotFound();
            }
            return new ObjectResult(_db.Places.ToList().FindAll(x => x.CityId == cityId && x.Id == placeId));

        }
    }
}
