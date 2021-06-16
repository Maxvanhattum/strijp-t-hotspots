<template>
  <div class="details">
    <TitlePage :title="hotspot.title" />

    <div class="pagebackground">
      <div v-if="hotspot.interview.url">
        <TitleHotspot :interviewDetails="hotspot.interview" />

        <HotspotVideo :url="hotspot.interview.url" />

        <HotspotVideoTekst
          :description="hotspot.interview.descriptionInterview"
        />
      </div>
      <BedrijvenDetails
        v-bind:bedrijven="hotspot.businesses"
        :id="hotspot.id"
      />
    </div>

    <footer class="footer"></footer>
  </div>
</template>

<script>
import AxiosInstance from "../services/API/API";

import TitlePage from "../components/HotspotDetails/TitlePage";

import TitleHotspot from "../components/HotspotDetails/TitleHotspot";

import HotspotVideo from "../components/HotspotDetails/HotspotVideo";

import HotspotVideoTekst from "../components/HotspotDetails/HotspotVideoTekst";

import BedrijvenDetails from "../components/BedrijvenDetails/OverviewDetails";

export default {
  name: "Details",
  components: {
    TitlePage,
    TitleHotspot,
    HotspotVideo,
    HotspotVideoTekst,
    BedrijvenDetails
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

<style scoped>
body {
  background-color: #eff1f0;
}
.pagebackground {
  display: block;
  background-color: #eff1f0;
  height: 100%;
  padding-bottom: 1%;
  width: 100%;
}

@media screen and (max-width: 992px) {
  .pagebackground {
    display: block;
    background-color: #eff1f0;
    height: 100%;
    width: 100%;
  }
}

@media screen and (max-width: 600px) {
  .pagebackground {
    display: block;
    background-color: #eff1f0;
    height: 100%;
    width: 100%;
  }
}

.footer {
  display: block;
  background-color: white;
  height: 5vh;
}
</style>
