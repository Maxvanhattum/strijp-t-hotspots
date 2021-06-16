<template>
  <div class="ScannedDetails">
    <TitlePage />

    <div class="pagebackground">
      <TitleHotspot />

      <HotspotVideo />

      <HotspotVideoTekst />

      <ScanQRImage />
    </div>

    <div class="scannedimage">
      <img class="panorama" :src="images.sample" />
    </div>

    <footer class="footer"></footer>
  </div>
</template>

<script>
import TitlePage from "../components/TitlePage";

import TitleHotspot from "../components/TitleHotspot";

import HotspotVideo from "../components/HotspotVideo";

import HotspotVideoTekst from "../components/HotspotVideoTekst";

export default {
  name: "ScannedDetails",
  components: {
    TitlePage,
    TitleHotspot,
    HotspotVideo,
    HotspotVideoTekst
  },
  data() {
    return {
      images: {
        sample: require("../assets/Scanned_foto's-08.png")
      }
    };
  }
};
</script>

<style scoped>
.pagebackground {
  display: block;
  background-color: #eff1f0;
  height: 135.9vh;
}

@media screen and (max-width: 992px) {
  .pagebackground {
    display: block;
    background-color: #eff1f0;
    height: 91.6vh;
  }
}

@media screen and (max-width: 600px) {
  .pagebackground {
    display: block;
    background-color: #eff1f0;
    height: 82.5vh;
  }
}
.panorama {
  width: 50vw;
}

@media screen and (max-width: 992px) {
  .panorama {
    width: 70vw;
  }
}

@media screen and (max-width: 600px) {
  .panorama {
    width: 100vw;
  }
}

.footer {
  display: block;
  background-color: white;
  height: 5vh;
}
</style>
