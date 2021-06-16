using AutoMapper;
using DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using ViewModels;
using ViewModels.CreateHotspot;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Strijp_T_Hotspots.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotspotController : ControllerBase
    {
        private IHotspotService hotspotService;
        private IMapper mapper;
        public HotspotController(IMapper mapper, IHotspotService hotspotService)
        {
            this.hotspotService = hotspotService;
            this.mapper = mapper;
        }

        // GET: api/<HotspotController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IReadOnlyList<Hotspot> hotspots = hotspotService.GetAll();
                return Ok(hotspots);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<HotspotController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Hotspot hotspot = hotspotService.FindById(id);
                return Ok(hotspot);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<HotspotController>
        [Authorize]
        [HttpPost]
        public IActionResult CreateHotspot([FromBody] CreateHotspotVM hotspotVM)
        {
            try
            {
                Hotspot createdHotspot = hotspotService.Create(mapper.Map<CreateHotspotDTO>(hotspotVM));
                return Ok(createdHotspot);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize]
        [HttpPost("/{id}/add-businesses")]
        public IActionResult AddBusinesses([FromBody] List<BusinessVM> hotspotVM, int id)
        {
            try
            {
                hotspotService.AddBusinesses(id, mapper.Map<List<BusinessDTO>>(hotspotVM));
                return Ok();
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<HotspotController>/5
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateHotspotVM hotspotVM)
        {
            try
            {
                Hotspot updatedHotspot = hotspotService.Update(mapper.Map<UpdateHotspotDTO>(hotspotVM));
                return Ok(updatedHotspot);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/<HotspotController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                hotspotService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
