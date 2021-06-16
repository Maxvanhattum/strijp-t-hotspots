<template>
  <div class="TitleHotspot">
    <img :src="images.sample" class="hotspot" />
    <h3>{{ interviewDetails.titleInterview }}</h3>
  </div>
</template>

<script>
export default {
  name: "TitleHotspot",
  data() {
    return {
      images: {
        sample: require("../../assets/Hotspot icon-06.png")
      }
    };
  },
  props: {
    interviewDetails: Object
  }
};
</script>

<style scoped>
.TitleHotspot {
  display: flex;
  align-items: center;
  justify-content: center;
}

.hotspot {
  height: 4vh;
}

.TitleHotspot h3 {
  color: #04216a;
  font-size: 16pt;
  padding-left: 1vh;
}

@media screen and (max-width: 600px) {
  .TitleHotspot h3 {
    color: #04216a;
    font-size: 14pt;
    padding-left: 1vh;
  }
}
</style>
