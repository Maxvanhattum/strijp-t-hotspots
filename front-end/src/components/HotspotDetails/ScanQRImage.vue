<template>
  <div class="ScanQRImage">
    <img class="lock" :src="image.lock" />
    <h1>
      Scan de QR code op de hotspot om de panorama foto van deze locatie te
      bekijken
    </h1>
    <img class="panorama" :src="images.sample" />
  </div>
</template>

<script>
export default {
  name: "ScanQRImage",
  data() {
    return {
      image: {
        lock: require("../../assets/Lock-07.png")
      },
      images: {
        sample: require("../../assets/Scanned foto's-06.png")
      }
    };
  }
};
</script>

<style scoped>
.ScanQRImage {
  margin-top: 4.5vh;
  position: relative;
  text-align: center;
}

.panorama {
  width: 100%;
  max-width: 800px;
}

.ScanQRImage h1 {
  position: absolute;
  top: 59%;
  left: 50%;
  transform: translate(-50%, -50%);
  color: white;
  font-size: 12pt;
  padding: 20vh;
}

@media screen and (max-width: 960px) {
  .ScanQRImage h1 {
    position: absolute;
    top: 59%;
    left: 50%;
    transform: translate(-50%, -50%);
    color: white;
    font-size: 12pt;
    padding: 5vh;
  }
}

@media screen and (max-width: 600px) {
  .ScanQRImage h1 {
    position: absolute;
    top: 59%;
    left: 50%;
    transform: translate(-50%, -50%);
    color: white;
    font-size: 9pt;
    padding: 1vh;
  }
}

.lock {
  width: 6vw;
  position: absolute;
  top: 35%;
  left: 50%;
  transform: translate(-50%, -50%);
}

@media screen and (max-width: 960px) {
  .lock {
    width: 9vw;
    position: absolute;
    top: 40%;
    left: 50%;
    transform: translate(-50%, -50%);
  }
}

@media screen and (max-width: 600px) {
  .lock {
    width: 13vw;
    position: absolute;
    top: 40%;
    left: 50%;
    transform: translate(-50%, -50%);
  }
}
</style>
