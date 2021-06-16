<template>
  <div class="home">
    <div class="burgerwrap" />
    <Slide
      :closeOnNavigation="true"
      @openMenu="handleOpenMenu"
      @closeMenu="handleCloseMenu"
    >
      <router-link to="/">Hotspots</router-link>
    </Slide>
    <GoogleMap v-bind:markers="hotspots" />
    <hotspot-overview v-bind:hotspots="hotspots" />
  </div>
</template>

<script>
import HotspotApi from "../services/API/API";

import GoogleMap from "../components/GoogleMap.vue";
import HotspotOverview from "../components/HotspotOverview/HotspotOverview";

import { Slide } from "vue-burger-menu";

export default {
  name: "Home",
  components: {
    GoogleMap,
    HotspotOverview,
    Slide
  },
  methods: {
    handleOpenMenu: function() {
      this.open = true;
    },
    handleCloseMenu: function() {
      this.open = false;
    }
  },
  data: function() {
    return {
      open: false,
      hotspots: []
    };
  },
  //functie word uitgevoerd, wanneer deze component geladen.
  mounted: function() {
    HotspotApi.GetAll()
      .then(response => {
        this.hotspots = response.data;
      })
      .catch(error => console.log(error));
  }
};
</script>
<style>
a {
  font-weight: 400;
  color: #fff;
}

a.router-link-exact-active {
  font-weight: 700;
  color: #fff;
}

.bm-burger-button {
  height: 18px;
  width: 22px;
  position: absolute;
  top: 41px;
  left: 38px;
  z-index: 2;
}

.burgerwrap {
  position: absolute;
  background-color: #001273;
  border: none;
  border-radius: 100px;
  width: 48px;
  height: 48px;
  left: 25px;
  top: 25px;
  z-index: 1;
}

.bm-burger-bars {
  background-color: #fff;
  border: none;
  border-radius: 100px;
}

.line-style {
  position: absolute;
  height: 3px;
}

.cross-style {
  display: none;
}

.bm-menu {
  background-color: #001273;
  padding-top: 80px;
}

.bm-item-list {
  margin-left: 25px;
  margin-right: 25px;
  font-size: 24px;
  min-width: 260px;
}

.bm-item-list > * {
  padding: 0 0 20px 0;
}

@media only screen and (min-width: 1128px) {
  .bm-burger-button {
    top: 76px;
    left: 73px;
  }

  .burgerwrap {
    left: 60px;
    top: 60px;
  }
}
</style>
