using DataTransferObjects;
using Models;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IHotspotService
    {
        IReadOnlyList<Hotspot> GetAll();
        Hotspot FindById(int id);
        Hotspot Create(CreateHotspotDTO createHotspotDTO);
        Hotspot Update(UpdateHotspotDTO updateHotspotDTO);
        void Delete(int id);
        void AddBusinesses(int id, List<BusinessDTO> businessDTOs);
    }
}
