<template>
  <div class="HotspotVideoTekst">
    <p>{{ description }}</p>
  </div>
</template>

<script>
export default {
  name: "HotspotVideoTekst",
  props: {
    description: String
  }
};
</script>

<style scoped>
.HotspotVideoTekst {
  display: flex;
  justify-content: center;
  background-color: white;
  padding: 1%;
  width: 100%;
  max-width: 765px;
  margin: 0 auto;
}

.HotspotVideoTekst p {
  text-align: left;
  font-size: 14px;
  padding: 20px;
}

@media screen and (max-width: 992px) {
  .HotspotVideoTekst {
    display: flex;
    justify-content: center;
    background-color: white;
    padding: 1%;
    width: 58%;
    max-width: 765px;
    margin: 0 auto;
  }
}

@media screen and (max-width: 600px) {
  .HotspotVideoTekst {
    width: 78%;
    max-width: 765px;
    display: flex;
    justify-content: center;
    margin: 0 auto;
  }

  .HotspotVideoTekst p {
    font-size: 11px;
  }
}
</style>
