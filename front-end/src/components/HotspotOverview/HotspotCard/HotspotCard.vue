<template>
  <div :class="first ? 'active' : ''" class="gelekaart">
    <div class="gridContainer">
      <div id="afb-container">
        <img id="afb" src="img/tq.jpg" alt="afbeelding" />
      </div>

      <div id="text-container">
        <div id="text-title">
          {{ cardData.title }}
        </div>

        <div id="text-description">
          {{ cardData.description }}
        </div>

        <div id="text-buttons">
          <hotspot-distance-button :markerPosition="cardData.geoCoordinates" />
          <button id="button2" v-on:click="getRoute">GA</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import HotspotDistanceButton from "./HotspotDistanceButton.vue";
import gmapsInit from "../../../utils/googlemap";
export default {
  components: { HotspotDistanceButton },
  name: "HotspotCard",
  props: {
    cardData: Object
  },
  async mounted() {
    this.google = await gmapsInit();
  },
  data: function() {
    return {
      first: this.cardData.id == 1,
      google: Object,
      route: Object
    };
  },
  computed: {
    userPosition() {
      return this.$store.state.userPosition;
    }
  },
  methods: {
    getRoute: async function() {
      let directionsService = new this.google.maps.DirectionsService();
      console.log("Route clicked");
      let request = {
        destination: new this.google.maps.LatLng(
          Number(this.cardData.geoCoordinates.latitude),
          Number(this.cardData.geoCoordinates.longitude)
        ),
        origin: new this.google.maps.LatLng(
          Number(this.userPosition.lat),
          Number(this.userPosition.lng)
        ),
        travelMode: "WALKING"
      };
      await directionsService.route(request, (response, status) => {
        console.log("Getting route");
        console.log(status);
        if (status == "OK") {
          this.$store.commit("setRoute", response);
        }
      });
    }
  }
};
</script>

<style scoped>
.gridContainer {
  padding: 0 20px;
  display: flex;
}

.active {
  background-color: #e5e6f1;
}

#afb-container {
  width: 100px;
  height: 100px;
  padding: 15px 0;
}

#afb {
  width: 100px;
  height: 100px;
  object-fit: cover;
}

#text-container {
  width: 100%;
}

#text-title {
  font-size: 18px;
  font-weight: 700;
  color: #001273;
  text-align: left;
  padding-left: 20px;
  margin-top: 7px;
  text-transform: uppercase;
}

#text-description {
  font-size: 14px;
  padding-left: 20px;
}

#text-buttons {
  padding-left: 20px;
}

button {
  font-family: "Titillium Web", Helvetica, Arial, sans-serif;
  font-weight: 700;
}

#button1 {
  background-color: transparent;
  color: #001273;
  border: 2px solid#001273;
  border-radius: 100px;
  padding: 5px 24px;
  margin-right: 15px;
  margin-bottom: 10px;
  margin-top: 10px;
}

#button2 {
  background-color: #001273;
  color: white;
  border: 2px solid#001273;
  border-radius: 100px;
  padding: 5px 24px;
  margin-bottom: 10px;
}

p {
  font-size: 13px;
}
</style>
