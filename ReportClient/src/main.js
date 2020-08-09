// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
// import App from "./App.vue";
import i18n from "./lang/lang";
import store from "./store";
import main1 from "./components/main/main";
import router from "./router";
import BootstrapVue from "bootstrap-vue/dist/bootstrap-vue.esm";
import Notifications from "vue-notification";
import moment from "moment";
import bootbox from "bootbox";
import VueToast from "vue-toast-notification";
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
import "@fortawesome/fontawesome-free/css/fontawesome.min.css";
import "@fortawesome/fontawesome-free/css/fontawesome.css";
import "pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css";
import "moment";
import "jquery";
import "bootstrap";
Vue.use(ElementUI, {
  i18n: (key, value) => i18n.t(key, value)
});
Vue.use(bootbox);
Vue.use(BootstrapVue);
Vue.use(Notifications);
Vue.use(VueToast);
Vue.prototype.moment = moment;

/* eslint-disable no-new */
const app = new Vue({
  el: "#app",
  store,
  i18n,
  router,
  components: {
    main1,
  },
  template: "<main1/>"
});

export default app;
