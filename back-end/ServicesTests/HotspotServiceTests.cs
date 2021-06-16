using AutoMapper;
using DataTransferObjects;
using Models;
using Moq;
using Repositories.Contracts;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace ServicesTests
{
    public class HotspotServiceTests
    {
        Mock<IHotspotRepository> repoMock = new Mock<IHotspotRepository>();
        Mock<IMapper> mapMock = new Mock<IMapper>();
        private readonly IHotspotService hotspotService;

        public HotspotServiceTests()
        {
            this.hotspotService = new HotspotService(repoMock.Object, mapMock.Object);
        }

        [Fact]
        public void FindById_CorrectId_MatchingHotspot()
        {
            // Arrange
            int Id = 1;
            string expectedTitle = "CorrectHotspot";
            Hotspot hotspot = new Hotspot() { Id = 1, Title = expectedTitle };
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == Id))).Returns(hotspot);

            // Act

            Hotspot result = this.hotspotService.FindById(1);

            // Assert
            Assert.Equal(expectedTitle, result.Title);
        }

        [Fact]
        public void FindById_IncorrectId_NotFoundException()
        {
            // Arrange
            int Id = 1;
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == Id))).Returns((Hotspot)null);

            // Act & Assert
            Assert.Throws<NotFoundException>(() => this.hotspotService.FindById(1));

        }

        [Fact]
        public void Delete_CorrectId_NoExceptions()
        {
            // Arrange
            int Id = 1;
            string expectedTitle = "CorrectHotspot";
            Hotspot hotspot = new Hotspot() { Id = Id, Title = expectedTitle };
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == 1))).Returns(hotspot);
            repoMock.Setup(x => x.Delete(It.Is<int>(p => p == 1))).Verifiable();

            // Act
            this.hotspotService.Delete(1);

            // Assert
            repoMock.VerifyAll();
        }

        [Fact]
        public void Delete_InCorrectId_NotFoundException()
        {
            // Arrange
            int Id = 1;
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == Id))).Returns((Hotspot)null);

            // Act & Assert
            Assert.Throws<NotFoundException>(() => this.hotspotService.Delete(1));
        }

        [Fact]
        public void Create_CreateHotspotDTOW_CreatedHotspot()
        {
            // Arrange
            int hotspotId = 1;
            string title = "New Hotspot";
            string description = "The description";
            string latitude = "5.013";
            string longitude = "51.44";
            string titleInterview = "New Interview Title";
            string descriptionInterview = "New Interview Description";
            string uploaderInterview = "New Uploader";
            string url = "www.youtube.nl";
            string source = "youtube";
            string ar = "path";

            GeocoordinatesDTO geocoordinatesDTO = new GeocoordinatesDTO()
            { Latitude = latitude, Longitude = longitude };
            InterviewDTO interviewDTO = new InterviewDTO()
            {
                TitleInterview = titleInterview,
                DescriptionInterview = descriptionInterview,
                UploaderInterview = uploaderInterview,
                Url = url,
                Source = source
            };
            AR360DTO aR360DTO = new AR360DTO() { AR360SourcePath = ar };

            CreateHotspotDTO hotspotDTO = new CreateHotspotDTO()
            {
                AR360DTO = aR360DTO,
                InterviewDTO = interviewDTO,
                GeocoordinatesDTO = geocoordinatesDTO,
                Description = description,
                Title = title
            };

            GeoCoordinates geoCoordinates = new GeoCoordinates(1, longitude, latitude);
            MovieInterviewDetails interview = new MovieInterviewDetails(1, source, url, titleInterview, descriptionInterview, uploaderInterview);
            AR360 aR360 = new AR360(1, ar);

            Hotspot returnedHotspot = new Hotspot(hotspotId, title, description, DateTime.Now,
                1, geoCoordinates, 1, interview, 1, aR360);


            // Act
            mapMock.Setup(x => x.Map<Hotspot>(It.Is<CreateHotspotDTO>(p => p == hotspotDTO))).Returns(returnedHotspot);
            repoMock.Setup(x => x.Add(It.Is<Hotspot>(p => p.Title == title))).Returns(returnedHotspot);
            Hotspot result = this.hotspotService.Create(hotspotDTO);

            // Assert
            Assert.Equal(title, result.Title);
        }

        [Fact]
        public void AddBusinesses_NewBusiness_AddedToBusinesses()
        {
            // Arrange
            Hotspot hotspot = new Hotspot() { Id = 1, Businesses = new List<Business>() };
            string businessName = "Business1";
            string businessUrl = "www.website1.nl";
            string streetName = "New";
            string zipcode = "New";
            string houseNumber = "1";
            string city = "Eindhoven";
            BusinessDTO newBusinessDTO = new BusinessDTO()
            {
                Address = new AddressDTO()
                { StreetName = streetName, Zipcode = zipcode, HouseNumber = houseNumber, City = city },
                Name = businessName,
                Url = businessUrl
            };
            Business newBusiness = new Business(1, businessName, new Address(1, city, zipcode, streetName, houseNumber),
                businessUrl);


            List<BusinessDTO> businessesToAdd = new List<BusinessDTO>() { newBusinessDTO };

            // Act
            mapMock.Setup(x => x.Map<Business>(It.IsAny<BusinessDTO>())).Returns(newBusiness);
            repoMock.Setup(x => x.Save()).Verifiable();
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == 1))).Returns(hotspot);
            this.hotspotService.AddBusinesses(1, businessesToAdd);


            // Assert
            Assert.Single(hotspot.Businesses);
        }

        [Fact]
        public void AddBusinesses_ExistingBusiness_NotAddedToBusinesses()
        {
            // Arrange

            string businessName = "Business1";
            string businessUrl = "www.website1.nl";
            string streetName = "New";
            string zipcode = "New";
            string houseNumber = "1";
            string city = "Eindhoven";
            BusinessDTO newBusinessDTO = new BusinessDTO()
            {
                Address = new AddressDTO()
                { StreetName = streetName, Zipcode = zipcode, HouseNumber = houseNumber, City = city },
                Name = businessName,
                Url = businessUrl
            };
            Business newBusiness = new Business(1, businessName, new Address(1, city, zipcode, streetName, houseNumber),
                businessUrl);

            Hotspot hotspot = new Hotspot() { Id = 1, Businesses = new List<Business>() { newBusiness } };

            List<BusinessDTO> businessesToAdd = new List<BusinessDTO>() { newBusinessDTO };

            // Act
            mapMock.Setup(x => x.Map<Business>(It.IsAny<BusinessDTO>())).Returns(newBusiness);
            repoMock.Setup(x => x.Save()).Verifiable();
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == 1))).Returns(hotspot);
            this.hotspotService.AddBusinesses(1, businessesToAdd);


            // Assert
            Assert.Single(hotspot.Businesses);
        }

        [Fact]
        public void AddBusinesses_NoBusiness_NotAddedToBusinesses()
        {
            // Arrange

            string businessName = "Business1";
            string businessUrl = "www.website1.nl";
            string streetName = "New";
            string zipcode = "New";
            string houseNumber = "1";
            string city = "Eindhoven";
            BusinessDTO newBusinessDTO = new BusinessDTO()
            {
                Address = new AddressDTO()
                { StreetName = streetName, Zipcode = zipcode, HouseNumber = houseNumber, City = city },
                Name = businessName,
                Url = businessUrl
            };
            Business newBusiness = new Business(1, businessName, new Address(1, city, zipcode, streetName, houseNumber),
                businessUrl);

            Hotspot hotspot = new Hotspot() { Id = 1, Businesses = new List<Business>() };

            List<BusinessDTO> businessesToAdd = new List<BusinessDTO>();

            // Act
            mapMock.Setup(x => x.Map<Business>(It.IsAny<BusinessDTO>())).Returns(newBusiness);
            repoMock.Setup(x => x.Save()).Verifiable();
            repoMock.Setup(x => x.GetById(It.Is<int>(p => p == 1))).Returns(hotspot);
            this.hotspotService.AddBusinesses(1, businessesToAdd);


            // Assert
            Assert.Empty(hotspot.Businesses);
        }

    }
}
