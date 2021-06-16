using AutoMapper;
using DataTransferObjects;
using Models;
using Repositories.Contracts;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class HotspotService : IHotspotService
    {
        private IHotspotRepository hotspotRepository;
        private IMapper mapper;
        public HotspotService(IHotspotRepository hotspotRepository, IMapper mapper)
        {
            this.hotspotRepository = hotspotRepository;
            this.mapper = mapper;
        }

        public Hotspot Create(CreateHotspotDTO createHotspotDTO)
        {
            Hotspot hotspot = mapper.Map<Hotspot>(createHotspotDTO);

            hotspotRepository.Add(hotspot);
            hotspotRepository.Save();
            return hotspot;
        }

        public void Delete(int id)
        {
            FindById(id);
            hotspotRepository.Delete(id);
            hotspotRepository.Save();
        }

        public Hotspot FindById(int id)
        {
            Hotspot hotspot = hotspotRepository.GetById(id);
            if (hotspot == null)
            {
                throw new NotFoundException("The Hotspot does not exist");
            }
            return hotspot;
        }

        public IReadOnlyList<Hotspot> GetAll()
        {
            return hotspotRepository.GetAll().ToList().AsReadOnly();
        }

        public Hotspot Update(UpdateHotspotDTO updateHotspotDTO)
        {
            Hotspot hotspotToUpdate = FindById(updateHotspotDTO.Id);
            UpdateTitle(updateHotspotDTO, hotspotToUpdate);
            UpdateDescription(updateHotspotDTO, hotspotToUpdate);
            UpdatePublishDate(updateHotspotDTO, hotspotToUpdate);
            UpdateGeocoordinates(updateHotspotDTO, hotspotToUpdate);
            UpdateInterviewDetails(updateHotspotDTO, hotspotToUpdate);
            UpdateAR360(updateHotspotDTO, hotspotToUpdate);
            UpdateBusinesses(updateHotspotDTO, hotspotToUpdate);

            hotspotRepository.Update(hotspotToUpdate);
            hotspotRepository.Save();
            return hotspotToUpdate;
        }

        public void AddBusinesses(int id, List<BusinessDTO> businessDTOs)
        {
            Hotspot hotspot = FindById(id);
            businessDTOs.ForEach(x =>
            {
                Business businessToAdd = mapper.Map<Business>(x);
                if (!hotspot.Businesses.Contains(businessToAdd))
                {
                    hotspot.Businesses.Add(businessToAdd);
                }
            });
            hotspotRepository.Save();

        }



        private void UpdateBusinesses(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.Businesses != null || !updateHotspotDTO.Businesses.Any())
            {
                hotspotToUpdate.Businesses = mapper.Map<List<Business>>(updateHotspotDTO.Businesses);
            }
        }

        private void UpdateAR360(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.AR360 != null)
            {
                hotspotToUpdate.AR360 = mapper.Map<AR360>(updateHotspotDTO.AR360);
            }
        }

        private void UpdateInterviewDetails(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.Interview != null)
            {
                hotspotToUpdate.Interview = mapper.Map<MovieInterviewDetails>(updateHotspotDTO.Interview);
            }
        }

        private void UpdateGeocoordinates(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.Geocoordinates != null)
            {
                hotspotToUpdate.GeoCoordinates = mapper.Map<GeoCoordinates>(updateHotspotDTO.Geocoordinates);
            }
        }

        private void UpdatePublishDate(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.PublishDate != null)
            {
                hotspotToUpdate.PublishDate = updateHotspotDTO.PublishDate;
            }
        }

        private void UpdateDescription(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (!String.IsNullOrEmpty(updateHotspotDTO.Description))
            {
                hotspotToUpdate.Description = updateHotspotDTO.Description;
            }
        }

        private void UpdateTitle(UpdateHotspotDTO updateHotspotDTO, Hotspot hotspotToUpdate)
        {
            if (updateHotspotDTO.Title != null)
            {
                hotspotToUpdate.Title = updateHotspotDTO.Title;
            }
        }


    }
}
