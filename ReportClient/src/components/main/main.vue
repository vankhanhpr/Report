<template>
  <div class="h wf main-container" id="app">
    <div class="h wf header">
      <a href>
        <div class="h header-logo"></div>
      </a>
      <span class="h header-title">{{ $t("common.CNTT_CENTER") }}</span>
      <div class="btn-login">
        <button
          v-if="!islogin"
          type="button"
          class="btn btn-primary"
          @click="modalShow = true"
          data-toggle="modal"
          data-target="#exampleModal"
        >{{ $t("login.LOGIN") }}</button>
        <div class="border-tab-user" v-if="islogin">
          <span class="k name-user">
            <i class="fa fa-user-secret"></i>
            {{ username }}
          </span>
          <div class="form-text-logout">
            <span class="k text_logout" v-on:click="signout()">
              {{
              $t("login.LOGOUT")
              }}
            </span>
            <span
              class="k text_changelanguage"
              v-on:click="showFormLanguage()"
            >{{ $t("common.select_lang") }}</span>
            <span
              class="k text_changelanguage text-logout"
              @click="modalChangePass = true"
            >{{ $t("login.CHANGE_PASS") }}</span>
          </div>
        </div>
      </div>
      <div class="h wf topnav" id="myTopnav">
        <span></span>
        <a
          href="#reportDasboard"
          @click="selectComponent = 'reportDasboardComponent'"
        >{{ $t("common.HOME") }}</a>
        <a
          href="#observation"
          @click="selectComponent = 'observationComponent'"
        >{{ $t("common.OBSERVATION") }}</a>
        <a
          href="#reportListSLA"
          @click="selectComponent = 'reportListSLAComponent'"
        >{{ $t("common.REPORT_LIST_SLA") }}</a>
        <a href="#user" @click="selectComponent = 'userComponent'">{{ $t("common.USER") }}</a>

        <a href="#" class="icon" @click="clickFunction()">
          <i class="fa fa-bars"></i>
        </a>
      </div>
    </div>
    <div class="h wf body">
      <!-- <fiberComponent></fiberComponent> -->
      <component :is="selectComponent"></component>
    </div>

    <div class="h wf footer">
      <div class="h wf footer-title">
        <div
          class="footer-copyright text-center py-3 text-white"
        >© 2020 copyright: {{ $t("common.CNTT_CENTER") }}</div>
      </div>
    </div>
    <notifications group="foo-success" position="bottom right" :speed="500" />
    <!-- login -->
    <b-modal v-model="modalShow" ref="my-modal" hide-footer title="Đăng Nhập">
      <div class="modal-dialog">
        <loginComponent></loginComponent>
      </div>
    </b-modal>
    <!-- Language -->
    <b-modal v-model="modalLanguage" ref="my-modal" hide-footer title="Select Language">
      <div class="modal-dialog">
        <button @click="setLangNew('vi')">{{ $t("common.VI") }}</button>
        <button @click="setLangNew('en')">{{ $t("common.EN") }}</button>
      </div>
    </b-modal>
  </div>
</template>

<script>
import Vue from "vue";
Vue.use(BootstrapVue);

import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import $ from "jquery";

import user from "../user/user";
import login from "../login/login";
import reportDasboard from "../reportDasboard/reportDasboard";
import reportListSLA from "../reportListSLA/reportListSLA";
import observation from "../observation/observation";
import reponsitoryfactory from "../../service/factory/reponsitoryfactory";
const userReponsitory = reponsitoryfactory.get("user");

export default {
  name: "app",
  data() {
    return {
      modalShow: false,
      modalShow1: true,
      modalLanguage: false,
      selectComponent: "reportDasboardComponent",
      isActive: false,
      user: {},
      islogin: false,
      username: "",
    };
  },
  created() {
    this.getTokenByLocal();
  },
  // dung de chuyen data
  methods: {
    clickFunction() {
      var x = document.getElementById("myTopnav");
      if (x.className === "h wf topnav") {
        x.className += " responsive";
      } else {
        x.className = "h wf topnav";
      }
    },
    showFormLanguage() {
      var self = this;
      self.modalLanguage = true;
    },
    setLangNew: function (lang) {
      this.$store.dispatch("setLangNew", lang);
    },
    getTokenByLocal() {
      var section_local = this.getCookie("token_session");
      if (section_local) {
        var tok = this.strToObj(this.getCookie("token_session"));
        this.token = tok.token;
        this.getUserById(parseInt(tok.usid));
        this.modalShow = false; //hide form login
      } else {
        this.modalShow = true; //show form login
      }
    },
    getCookie(cname) {
      var name = cname + "=";
      var decodedCookie = decodeURIComponent(document.cookie);
      for (var i = 0; i < decodedCookie.length; i++) {
        var c = decodedCookie;
        while (c.charAt(0) === " ") {
          c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
          return c.substring(name.length, c.length);
        }
      }
      return "";
    },
    strToObj(str) {
      //convert string to object
      var obj = {};
      if (str && typeof str === "string") {
        var objStr = str.match(/\{(.)+\}/g);
        eval("obj =" + objStr);
      }
      return obj;
    },
    async getUserById(id) {
      var self = this;
      await userReponsitory.getById(id).then(function (response) {
        if (response.data.success) {
          self.username = response.data.data.username;
          self.islogin = true;
        } else {
          self.islogin = false;
        }
      });
    },
    signout() {
      //logout user
      document.cookie = "token_session=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
      this.modalShow = true;
      this.islogin = false;
      //this.show_login =true;
    },
  },
  //format date
  filters: {
    moment: function (date) {
      return moment(date).format("MMMM Do YYYY, h:mm:ss a");
    },
  },
  components: {
    loginComponent: login,
    userComponent: user,
    reportDasboardComponent: reportDasboard,
    reportListSLAComponent: reportListSLA,
    observationComponent: observation,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
@import url(./main.css);
</style>
