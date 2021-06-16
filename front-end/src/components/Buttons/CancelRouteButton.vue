<template>
  <button v-on:click="remove" class="button-cancel-route">
    <img id="cancel-cross" :src="images.cancelcross" alt="Cancel Cross" />
    <p id="cancel-text">ROUTE</p>
  </button>
</template>

<script>
export default {
  name: "CancelRouteButton",
  data: function() {
    return {
      images: {
        cancelcross: require("../../assets/cross-icon.svg")
      }
    };
  },
  methods: {
    remove: function() {
      console.log("clicked the cancel route");
      this.$store.commit("removeRoute");
    }
  }
};
</script>

<style scoped>
.button-cancel-route {
  z-index: 1;
  display: flex;
  flex-direction: row;
  width: 100px;
  height: 43px;
  justify-content: space-evenly;
  align-items: center;
  padding: 5px;
  background: white;
  border-radius: 25px;
  border: none;
  margin-top: 10%;
}

.button-cancel-route > #cancel-cross {
  width: 12.5px;
  height: auto;
}

.button-cancel-route > #cancel-text {
  color: #001273;
  font-weight: 300;
}
</style>
