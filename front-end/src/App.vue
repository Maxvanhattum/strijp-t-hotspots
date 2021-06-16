<template>
  <div id="app">
    <main id="page-wrap">
      <router-view />
    </main>
  </div>
</template>

<script>
export default {
  components: {},
  data: function() {
    return {
      userPosition: Object
    };
  }
};
</script>

<style>
#app {
  font-family: "Titillium Web", Helvetica, Arial, sans-serif;
  text-rendering: optimizeLegibility;
  -webkit-font-smoothing: optimizeLegibility;
  text-align: left;
  color: #2c3e50;
}
</style>
