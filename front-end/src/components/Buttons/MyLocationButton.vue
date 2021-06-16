<template>
  <button v-on:click="center" class="button-location-arrow">
    <img id="location-arrow" :src="images.locationarrow" alt="Location Arrow" />
    <p id="location-text">IK</p>
  </button>
</template>

<script>
export default {
  name: "MyLocationButton",
  data: function() {
    return {
      images: {
        locationarrow: require("../../assets/location-arrow.png")
      }
    };
  },
  methods: {
    center: function() {
      console.log("clicked");
      this.$store.commit("setCenterToUser");
    }
  }
};
</script>

<style scoped>
.button-location-arrow {
  z-index: 1;
  display: flex;
  flex-direction: row;
  width: 70px;
  height: 43px;
  justify-content: space-evenly;
  align-items: center;
  padding: 5px;
  background: white;
  border-radius: 25px;
  border: none;
}

.button-location-arrow > #location-arrow {
  width: 17.5px;
  height: auto;
}

.button-location-arrow > #location-text {
  color: #001273;
  font-weight: 300;
}
</style>
