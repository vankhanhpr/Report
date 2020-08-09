<template>
  <div class="h main-form">
    <div class="container">
      <label for="uname">
        <b>{{ $t("login.USERNAME") }}</b>
      </label>

      <input
        class="text"
        type="text"
        placeholder="Nhập tên đăng nhập"
        v-model="datalogin.username"
        name="uname"
        required
      />

      <label for="psw">
        <b>{{ $t("login.PASSWORD") }}</b>
      </label>
      <input
        type="password"
        placeholder="Nhập mật khẩu"
        v-model="datalogin.password"
        name="psw"
        required
      />

      <button type="submit" v-on:click="login()">
        {{ $t("login.LOGIN") }}
      </button>
      <label>
        <input type="checkbox" checked="checked" name="remember" />
        {{ $t("login.REMEMBER_PASS") }}
      </label>
    </div>
  </div>
</template>

<script>
import reponsitoryfactory from "../../service/factory/reponsitoryfactory";

const authreponsitory = reponsitoryfactory.get("auth");
export default {
  name: "app",
  data() {
    return {
      datalogin: {
        username: "",
        password: ""
      },
      //show name username on header
      token: "" //save token
    };
  },

  methods: {
    login() {
      //login user

      if (!this.checkUsernamePassword(this.datalogin)) {
        // this.$notify({
        //       group: "foo-success",
        //       title: "Notify",
        //       type: "error",
        //       text: "Please complete all information!"
        //     });
        //     console.log(data.password.length);
        return;
      }

      var self = this;
      authreponsitory.login(this.datalogin).then(function(response) {
        if (response) {
          if (response.data.success) {
            self.name_user = response.data.data.user.username; //show name user
            self.show_login = false; //hide bnt login
            if (typeof Storage !== "undefined") {
              var value = {
                usid: response.data.data.user.usid,
                token: response.data.data.token.access_token
              };
              var today = new Date();
              var nexthour = new Date();
              nexthour.setDate(today.getDate() + 1);
              document.cookie =
                "token_session=" +
                JSON.stringify(value) +
                ";expires =" +
                nexthour +
                "";
            } else {
              alert("Trình duyệt của bạn không được hỗ trợ!");
            }
            window.location.href = "/";
          } else {
            //bootbox.alert("Username or password is not correct. Please try again!");
          }
        }
      });
    },
    checkUsernamePassword(model) {
      return true;
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
      return false;
    },
    getCookie(cname) {
      //get cookie by local
      var name = cname + "=";
      var decodedCookie = decodeURIComponent(document.cookie);
      var ca = decodedCookie.split(";");
      for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
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
      //get user by id
      var self = this;
      await userreponsitory.getById(id).then(function(response) {
        console.log(response.data.success);
        if (response.data.success) {
          self.name_user = response.data.data.username;
          self.user = response.data.data;
          self.show_login = false;
        }
      });
    }
  }
};
</script>

@<style scoped>
@import url(./login.css);
</style>
