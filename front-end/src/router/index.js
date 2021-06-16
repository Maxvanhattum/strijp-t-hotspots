import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Details from "../views/Details.vue";
import Businesses from "../views/Business.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue")
  },
  {
    path: "/details/:id/businesses",
    name: "Businesses",
    component: Businesses
  },
  {
    path: "/details/:id",
    name: "Details",
    component: Details
  }
];

const router = new VueRouter({
  routes
});

export default router;
