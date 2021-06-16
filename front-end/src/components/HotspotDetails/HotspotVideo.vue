<template>
  <div class="HotspotVideo">
    <iframe
      :src="url"
      frameborder="0"
      allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
      allowfullscreen
    ></iframe>
  </div>
</template>

<script>
export default {
  name: "HotspotVideo",
  props: {
    url: String
  }
};
</script>

<style scoped>
.HotspotVideo {
  display: flex;
  justify-content: center;
}

.HotspotVideo iframe {
  width: 100%;
  max-width: 800px;
  height: 45vh;
  margin: 0 20px;
}

@media screen and (max-width: 992px) {
  .HotspotVideo iframe {
    width: 60%;
    max-width: 800px;
    height: 20vh;
    margin: 0 20px;
  }
}

@media screen and (max-width: 600px) {
  .HotspotVideo iframe {
    width: 80%;
    height: 20vh;
    max-width: 800px;
    margin: 0 20px;
  }
}
</style>
