<template>
  <button id="button1">{{ distanceFromUser }}</button>
</template>

<script>
import gmapsInit from "../../../utils/googlemap";

export default {
  name: "HotspotDistanceButton",
  props: {
    markerPosition: Object
  },
  data: function() {
    return {
      google: Object,
      distanceFromUser: "Loading"
    };
  },
  computed: {
    userPosition() {
      return this.$store.state.userPosition;
    }
  },
  async created() {
    this.google = await gmapsInit();
    this.distanceFromUser =
      this.calculateDistanceFromUser(this.userPosition) + " m";
  },
  methods: {
    calculateDistanceFromUser: function(userPosition) {
      return Math.ceil(
        this.google.maps.geometry.spherical.computeDistanceBetween(
          new this.google.maps.LatLng(
            Number(userPosition.lat),
            Number(userPosition.lng)
          ),
          new this.google.maps.LatLng(
            Number(this.markerPosition.latitude),
            Number(this.markerPosition.longitude)
          )
        )
      );
    }
  },
  watch: {
    userPosition: function(newVal) {
      this.distanceFromUser = this.calculateDistanceFromUser(newVal) + " m";
    }
  }
};
</script>

<style scoped>
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
</style>
