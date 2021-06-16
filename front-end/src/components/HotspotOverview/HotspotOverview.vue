<template>
  <div>
    <hide-at breakpoint="large">
      <div>
        <div class="top-right-container">
          <MyLocationButton />
          <!-- Tonen wanneer er een route gekozen is -->
          <CancelRouteButton v-if="routeSet" />
        </div>
        <swipeable-bottom-sheet ref="swipeableBottomSheet">
          <div class="bottom-container">
            <div class="zoeken">
              <input
                v-model="search"
                type="text"
                id="zoekbalk-small"
                placeholder="zoeken"
              />
            </div>

            <h3 id="title">In de buurt</h3>
            <div v-for="component in this.hotspotsFiltered" :key="component.id">
              <hotspot-card :cardData="component" />
            </div>
          </div>
        </swipeable-bottom-sheet>
      </div>
    </hide-at>

    <show-at breakpoint="large">
      <div class="top-left-container">
        <div class="buttons-menu-left">
          <!-- Tonen wanneer er geen route gekozen is -->
          <MyLocationButton />
          <!-- Tonen wanneer er een route gekozen is -->
          <CancelRouteButton v-if="routeSet" />
        </div>

        <div class="zoeken">
          <input
            v-model="search"
            type="text"
            id="zoekbalk-big"
            placeholder="zoeken"
          />
        </div>
        <h3 id="title">Hotspots dichtbij</h3>
        <div v-for="component in this.hotspotsFiltered" :key="component.id">
          <hotspot-card :cardData="component" />
        </div>
      </div>
    </show-at>
  </div>
</template>

<script>
import HotspotCard from "./HotspotCard/HotspotCard";
import { SwipeableBottomSheet } from "vue-swipeable-bottom-sheet";
import { hideAt, showAt } from "vue-breakpoints";
import CancelRouteButton from "../Buttons/CancelRouteButton.vue";
import MyLocationButton from "../Buttons/MyLocationButton.vue";

//TEST
//testkeeee
export default {
  name: "HotspotOverview",
  components: {
    HotspotCard,
    SwipeableBottomSheet,
    hideAt,
    showAt,
    CancelRouteButton,
    MyLocationButton
  },
  //Alle hotspots in een lijst, in de datafunctie nieuwe array maken met filter hotspots. Array aanmaken Kopie van de markers maken.
  props: { hotspots: Array },
  data: function() {
    return {
      search: "",
      hotspotsFiltered: []
    };
  },
  watch: {
    hotspots: function(newValue) {
      this.hotspotsFiltered = newValue;
    },
    search: function(newValue) {
      console.log("Zoek input:");
      console.log(newValue);
      let newFilteredHotspots = [];
      if (newValue == "") {
        console.log("Reset de lijst");
        newFilteredHotspots = this.hotspots;
        this.hotspotsFiltered = newFilteredHotspots;
        return;
      }

      this.hotspots.forEach(hotspot => {
        let added = false;
        if (
          hotspot.title.toLowerCase().includes(newValue.toLowerCase()) &&
          !added
        ) {
          console.log("added because matches with title");
          newFilteredHotspots.push(hotspot);
          added = true;
        }

        hotspot.businesses.forEach(business => {
          if (
            business.name.toLowerCase().includes(newValue.toLowerCase()) &&
            !added
          ) {
            console.log("Added because business in hotspot: " + hotspot.title);
            console.log(business);
            newFilteredHotspots.push(hotspot);
            added = true;
          }
        });
      });
      console.log(newFilteredHotspots);
      this.hotspotsFiltered = newFilteredHotspots;
    }
  },
  computed: {
    routeSet: function() {
      return this.$store.state.routeSet;
    }
  },
  methods: {
    cardClicked: function(event, id) {
      console.log(id);
    }
  }
};
</script>

<style>
.contents::-webkit-scrollbar {
  display: none;
}
.contents {
  overflow-y: scroll;
  -ms-overflow-style: none; /* IE and Edge */
  scrollbar-width: none; /* Firefox */
}
</style>
<style scoped>
.bottom-container {
  border: none;
  border-radius: 28px;
}

.top-left-container {
  position: absolute;
  top: 40px;
  bottom: 40px;
  left: 40px;
  width: 375px;
  background-color: white;
  border: none;
  border-radius: 28px;
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1);
  overflow-y: scroll;
  -ms-overflow-style: none; /* IE and Edge */
  scrollbar-width: none; /* Firefox */
}

.top-left-container::-webkit-scrollbar {
  display: none;
}

.zoeken {
  color: grey;
  margin-top: 20px;
  padding: 0 20px;
}

.wrapper {
  z-index: 10;
}

#zoekbalk-small {
  padding: 10px 0;
  background-color: #f1f3f4;
  border: #f1f3f4;
  border-radius: 20px;
  width: 100%;
  font-size: 1rem;
  text-align: center;
}

#zoekbalk-big {
  padding: 10px 0;
  background-color: #f1f3f4;
  border: #f1f3f4;
  border-radius: 20px;
  width: 100%;
  font-size: 1rem;
  text-align: center;
}

#title {
  color: #001273;
  text-align: left;
  text-transform: uppercase;
  padding-left: 20px;
  margin-top: 30px;
}

#cancel-route-margin {
  margin-bottom: 10px;
}

.top-right-container {
  position: absolute;
  top: 27px;
  right: 25px;
  display: flex;
  flex-direction: column;
  align-items: flex-end;
}

.buttons-menu-left {
  position: absolute;
  top: 25px;
  right: 10px;
  display: flex;
}

@media only screen and (min-width: 1128px) {
  .zoeken {
    margin-top: 95px;
  }
}
</style>
