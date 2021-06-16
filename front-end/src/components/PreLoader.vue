<template>
  <div :class="{ fadeout: !isLoading }">
    <vue-splash
      :show="true"
      :logo="logo"
      title=""
      color="#001273"
      :size="125"
      :fixed="true"
      background-color="#B8BED7"
    />
  </div>
</template>

<script>
import Logo from "../assets/logo/preloader.png";

export default {
  name: "PreLoader",
  computed: {
    logo() {
      return Logo;
    }
  },
  props: ["isLoading"]
};
</script>

<style lang="css" scoped>
.fadeout {
  animation: fadeout 1s forwards;
  animation-delay: 10s;
  z-index: 100;
}

@keyframes fadeout {
  to {
    opacity: 0;
    visibility: hidden;
  }
}
</style>
