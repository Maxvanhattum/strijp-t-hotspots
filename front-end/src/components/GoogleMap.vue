<template>
  <div id="GoogleMap" />
</template>

<script>
import gmapsInit from "../utils/googlemap";
export default {
  name: "GoogleMap",
  props: {
    markers: Array
  },
  data: function() {
    return {
      google: Object,
      map: Object,
      directionsRenderer: Object,
      markersArr: [],
      userMarker: null,
      iconUser: require("../assets/MarkerGreen.svg"),
      iconHotspot: require("../assets/MarkerBlue.svg")
    };
  },
  computed: {
    route: function() {
      return this.$store.state.route;
    },
    userPosition: function() {
      return this.$store.state.userPosition;
    },
    centerToUser: function() {
      return this.$store.state.centerToUser;
    },
    removeRoute: function() {
      return this.$store.state.removeRoute;
    }
  },
  async mounted() {
    try {
      this.google = await gmapsInit();
      this.map = new this.google.maps.Map(this.$el, mapOptions);
      this.$props.markers.map(m => {
        this.AddMarker(this.google, this.map, m);
      });
      var rendererOptions = {
        map: this.map,
        suppressMarkers: true
      };

      this.directionsRenderer = new this.google.maps.DirectionsRenderer(
        rendererOptions
      );
      this.directionsRenderer.setMap(this.map);

      trackLocation({
        onSuccess: ({ coords: { latitude: lat, longitude: lng } }) => {
          let userPosition = { lat: lat, lng: lng };
          this.$store.commit("adjustPosition", userPosition);
        },
        onError: () => (this.userPosition = "error")
      });

      if (this.userPosition != null) {
        this.AddUserMarker(this.userPosition);
      }
    } catch (error) {
      console.error(error);
    }
  },
  methods: {
    AddMarker: function(google, map, m) {
      let marker = new google.maps.Marker({
        map,
        position: {
          lat: Number(m.geoCoordinates.latitude),
          lng: Number(m.geoCoordinates.longitude)
        },
        title: m.title,
        label: {
          text: m.title.split(" ")[1],
          color: "lightseagreen"
        },
        icon: {
          url: this.iconHotspot,
          labelOrigin: new this.google.maps.Point(15, 24)
        }
      });
      marker.addListener("click", () => {
        this.$router.push("/details/" + m.id);
      });
      this.markersArr.push(marker);
    },
    AddUserMarker: function(newVal) {
      if (this.userMarker == null) {
        this.userMarker = new this.google.maps.Marker({
          map: this.map,
          position: newVal,
          title: "Gebruiker persoon",
          label: {
            text: "Ik",
            color: "black"
          },
          icon: {
            url: this.iconUser,
            labelOrigin: new this.google.maps.Point(15, 24)
          }
        });
      } else {
        this.userMarker.setPosition(newVal);
      }
      let distanceBetween = this.google.maps.geometry.spherical.computeDistanceBetween(
        new this.google.maps.LatLng(newVal.lat, newVal.lng),
        new this.google.maps.LatLng(51.451012, 5.453084)
      );

      if (distanceBetween < 500) {
        this.map.panTo(newVal);
      }
    }
  },
  watch: {
    markers: function(newVal, oldVal) {
      newVal.some(coords => {
        if (!oldVal.includes(coords)) {
          this.AddMarker(this.google, this.map, coords);
        }
      });
    },
    route: function(newVal) {
      if (newVal != null) {
        this.directionsRenderer.setMap(this.map);
        this.directionsRenderer.setDirections(newVal);
      }
    },
    userPosition: function(newVal) {
      if (newVal != null) {
        this.AddUserMarker(newVal);
      }
    },
    removeRoute: function(newVal) {
      console.log("Route removal");
      if (newVal) {
        console.log("Route removal in if check");
        this.directionsRenderer.setMap(null);
        this.$store.commit("routeRemoved");
      }
    },
    centerToUser: function(newVal) {
      if (newVal) {
        console.log("center user");
        this.map.panTo(this.userPosition);
        this.$store.commit("userCentered");
      }
    }
  }
};

const trackLocation = ({ onSuccess, onError = () => {} }) => {
  if ("geolocation" in navigator === false) {
    return onError(new Error("Geolocation is not supported by your browser."));
  }

  return navigator.geolocation.watchPosition(onSuccess, onError, {
    timeout: 10000
  });
};

const mapOptions = {
  center: { lat: 51.451012, lng: 5.453084 },
  zoom: 18,
  disableDefaultUI: true,
  styles: [
    {
      featureType: "administrative.land_parcel",
      elementType: "labels",
      stylers: [
        {
          visibility: "off"
        }
      ]
    },
    {
      featureType: "poi",
      elementType: "labels.text",
      stylers: [
        {
          visibility: "off"
        }
      ]
    },
    {
      featureType: "poi.business",
      stylers: [
        {
          visibility: "off"
        }
      ]
    },
    {
      featureType: "road",
      elementType: "labels.icon",
      stylers: [
        {
          visibility: "off"
        }
      ]
    },
    {
      featureType: "road.local",
      elementType: "labels",
      stylers: [
        {
          visibility: "off"
        }
      ]
    },
    {
      featureType: "transit",
      stylers: [
        {
          visibility: "off"
        }
      ]
    }
  ]
};
</script>

<style>
html,
body {
  margin: 0;
  padding: 0;
}

#GoogleMap {
  width: 100vw;
  height: 100vh;
}
</style>
