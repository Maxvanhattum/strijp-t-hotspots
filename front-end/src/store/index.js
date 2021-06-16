import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    userPosition: { lat: 0, lng: 0 },
    route: Object,
    routeSet: false,
    removeRoute: false,
    hotspots: Array,
    centerToUser: false
  },
  mutations: {
    adjustPosition(state, latLng) {
      state.userPosition = latLng;
    },
    setRoute(state, payload) {
      state.route = payload;
      state.routeSet = true;
    },
    removeRoute(state) {
      state.removeRoute = true;
    },
    routeRemoved(state) {
      state.removeRoute = false;
      state.routeSet = false;
    },
    setHotspots(state, payload) {
      state.hotspots = payload;
    },
    setCenterToUser(state) {
      state.centerToUser = true;
    },
    userCentered(state) {
      state.centerToUser = false;
    },
    updateDistanceToHotspot(state, payload) {
      state.hotspots.forEach(hotspot => {
        if (hotspot.id == payload.id) {
          hotspot.distanceToUser = payload.distanceToUser;
        }
      });
    }
  },
  actions: {},
  modules: {}
});
