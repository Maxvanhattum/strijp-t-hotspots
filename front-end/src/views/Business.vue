<template>
  <div class="business">
    <BedrijvenExtension :bedrijven="hotspot.businesses" />
  </div>
</template>

<script>
import BedrijvenExtension from "../components/BedrijvenExtension";

import AxiosInstance from "../services/API/API";

export default {
  name: "Business",
  components: {
    BedrijvenExtension
  },
  data: function() {
    return {
      hotspot: {
        id: 1,
        title: "Hotspot TQ1",
        description:
          "TQ is verreweg het grootste gebouw van Strijp-T, welkom bij ingang 1.",
        publishDate: "2021-04-22T20:58:23.422558",
        geoCoordinatesId: 6,
        geoCoordinates: {
          id: 6,
          longitude: "5.4522929",
          latitude: "51.4509177"
        },
        interviewId: 1,
        interview: {
          id: 1,
          source: "Youtube",
          url: "https://www.youtube.com/embed/ggtN8t9j1UQ",
          titleInterview: "Strijp Talk - Wim Troost",
          descriptionInterview:
            "Grondlegger van ASML die vanuit gebouw TQ ervoor heeft gezorgd dat vanaf 1 april 1984 de eerste huisvesting van ASML in een houten keet in de binnentuin tussen gebouw TQ 1 en TQ 2 plaats vond.",
          uploaderInterview: "Strijp-T"
        },
        aR360Id: 1,
        aR360: {
          id: 1,
          sourcePath: "path"
        },
        businesses: [
          {
            id: 4,
            name: "Antea group",
            address: {
              id: 27,
              city: "Eindhoven",
              zipcode: "5651GW",
              streetName: "Achtsteweg Zuid",
              houseNumber: "153"
            },
            url: "https://anteagroup.nl/"
          },
          {
            id: 26,
            name: "Avular B.V.",
            address: {
              id: 26,
              city: "Eindhoven",
              zipcode: "5651GW",
              streetName: "Achtsteweg Zuid",
              houseNumber: "153-G"
            },
            url: "https://avular.com/"
          },
          {
            id: 27,
            name: "Eindhoven Gym B.V",
            address: {
              id: 25,
              city: "Eindhoven",
              zipcode: "5651GW",
              streetName: "Achtsteweg Zuid",
              houseNumber: "153-A"
            },
            url: "https://eindhovengym.nl/"
          },
          {
            id: 28,
            name: "Elstar Dynamics",
            address: {
              id: 24,
              city: "Eindhoven",
              zipcode: "5651GW",
              streetName: "Achtsteweg Zuid",
              houseNumber: "153-V"
            },
            url: "https://elstar-dynamics.com/"
          },
          {
            id: 29,
            name: "Interstep",
            address: {
              id: 10,
              city: "Eindhoven",
              zipcode: "5651GW",
              streetName: "Achtsteweg Zuid",
              houseNumber: "153"
            },
            url: "https://www.interstep.nl/"
          }
        ]
      }
    };
  },
  mounted: function() {
    let id = this.$route.params.id;
    AxiosInstance.GetById(id)
      .then(response => (this.hotspot = response.data))
      .catch(error => console.log(error));
  }
};
</script>
