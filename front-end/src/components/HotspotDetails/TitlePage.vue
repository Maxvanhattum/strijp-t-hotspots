<template>
  <div class="TitlePage">
    <h2>{{ title }}</h2>
    <p class="back" @click="hasHistory() ? $router.go(-1) : $router.push('/')">
      &lt;
    </p>
  </div>
</template>

<script>
export default {
  name: "TitlePage",
  props: {
    title: String
  },
  methods: {
    hasHistory() {
      return window.history.length > 2;
    }
  }
};
</script>

<style scoped>
.TitlePage {
  display: block;
  background-color: white;
  height: 14vh;
  text-align: center;
}

h2 {
  margin-top: 5vh;
}

.back {
  position: absolute;
  left: 100px;
  top: 35px;
  float: left;
  border: none;
  color: #eff1f0;
  text-align: center;
  text-decoration: none;
  font-size: 29px;
  cursor: pointer;
  background-color: #001273;
  border-radius: 100px;
  width: 50px;
  height: 50px;
}

@media screen and (max-width: 992px) {
  .TitlePage {
    display: block;
    background-color: white;
    height: 8vh;
  }

  .back {
    left: 20px;
    top: -5px;
  }

  h2 {
    margin-top: 1.5vh;
  }
}

@media screen and (max-width: 600px) {
  .TitlePage {
    display: block;
    background-color: white;
    height: 9.5vh;
  }
}

.TitlePage h2 {
  padding-top: 1vh;
  color: #04216a;
  font-size: 24pt;
}

@media screen and (max-width: 600px) {
  .TitlePage h2 {
    color: #04216a;
    font-size: 18pt;
    padding-top: 2vh;
  }
}
</style>
