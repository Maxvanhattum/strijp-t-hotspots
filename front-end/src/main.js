import Vue from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import router from "./router";
import store from "./store/index";
import VueSlideoutPanel from "vue2-slideout-panel";
import AsyncComputed from "vue-async-computed";
Vue.use(VueSlideoutPanel);
Vue.use(AsyncComputed);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
