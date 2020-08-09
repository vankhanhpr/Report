<template>
  <div class="h main-form">
    <div class="h tab-head">
      <span class="h text-header">Tài khoản</span>
      <!-- dropdown btn setting -->
      <div class="h dropdown">
        <button class="dropbtn">
          <i class="fas fa-cog"></i>
          <span class="text-dropbtn">Chức năng</span>
        </button>
        <div class="dropdown-content">
          <a @click="modalCreateUser = true" href="#">
            <i class="far fa-plus-square"></i> Thêm
          </a>
          <a @click="getUpdateUser()" href="#">
            <i class="fas fa-edit"></i> Sửa
          </a>
          <a @click="deleteUser()" href="#">
            <i class="far fa-trash-alt"></i> Xóa
          </a>
        </div>
      </div>
      <!-- search -->
      <div class="h wrap">
        <div class="search">
          <input type="text" class="searchTerm" placeholder="Nhập thông tin cần tìm" />
          <button type="submit" class="searchButton">
            <i class="fa fa-search"></i>
          </button>
        </div>
      </div>
    </div>
    <div class="h wf">
      <!-- Table -->
      <div class="h wf table">
        <table>
          <tr class="h wf table-title">
            <th class="h wr table-title">
              <input type="checkbox" class="select-item checkbox" name="select-item" />
            </th>
            <th class="h ww table-title">{{ title.username }}</th>
            <th class="h ww table-title">{{ title.password }}</th>
            <th class="h ww table-title">{{ title.phone }}</th>
            <th class="h ww table-title">{{ title.email }}</th>
            <th class="h ww table-title">{{ title.address }}</th>
            <th class="h wr table-title">{{ title.role }}</th>
          </tr>
          <tr class="h wf table-row" v-for="user in pageOfItems" :key="user.id">
            <th class="h wr table-row">
              <input
                type="checkbox"
                v-model="user.check"
                class="select-item checkbox"
                name="select-item"
              />
            </th>
            <th class="h ww table-row">{{ user.username }}</th>
            <th class="h ww table-row">*******</th>
            <th class="h ww table-row">{{ user.phone }}</th>
            <th class="h ww table-row">{{ user.email }}</th>
            <th class="h ww table-row">{{ user.address }}</th>
            <th class="h wr table-row">{{ user.role }}</th>
          </tr>
        </table>
      </div>
      <pagination
        class="pagination"
        :items="userList.length > 0 ? userList : listPage"
        :pageSize="perPage"
        :maxPages="6"
        @currentPage="getCurrentPage"
      ></pagination>
    </div>
    <!-- create user modal -->
    <b-modal v-model="modalCreateUser" ref="my-modal" hide-footer title="Tạo mới User">
      <div class="modal-dialog">
        <div class="container">
          <label for="uname">
            <b>Tên đăng nhập</b>
          </label>
          <input
            v-model="user.username"
            class="text-create"
            type="text"
            placeholder="Nhập tên tài khoản"
            name="uname"
            required
          />

          <label for="uname">
            <b>Mật khẩu</b>
          </label>
          <input
            v-model="user.password"
            class="text-create"
            type="text"
            placeholder="Nhập mật khẩu"
            name="uname"
            required
          />

          <label for="uname">
            <b>Số điện thoại</b>
          </label>
          <input
            v-model="user.phone"
            class="text-create"
            type="text"
            placeholder="Nhập số điện thoại"
            name="uname"
            required
          />

          <label for="uname">
            <b>Email</b>
          </label>
          <input
            v-model="user.email"
            class="text-create"
            type="text"
            placeholder="Nhập email"
            name="uname"
            required
          />

          <label for="uname">
            <b>Địa chỉ</b>
          </label>
          <input
            v-model="user.address"
            class="text-create"
            type="text"
            placeholder="Nhập địa chỉ"
            name="uname"
            required
          />

          <label for="uname">
            <b>Role</b>
          </label>
          <input
            v-model="user.role"
            class="text-create"
            type="text"
            placeholder="Nhập role"
            name="uname"
            required
          />
          <button @click="createUser()" type="button" class="btn btn-primary margin-t15">Xác Nhận</button>
        </div>
      </div>
    </b-modal>
    <!-- update user modal -->
    <b-modal v-model="modalUpdateUser" ref="my-modal" hide-footer title="Chỉnh sửa User">
      <div class="modal-dialog">
        <div class="container">
          <label for="uname">
            <b>Tên đăng nhập</b>
          </label>
          <input
            v-model="user.username"
            class="text-create"
            type="text"
            placeholder="Nhập tên tài khoản"
            name="uname"
            required
          />

          <label for="uname">
            <b>Mật khẩu</b>
          </label>
          <input
            v-model="user.password"
            class="text-create"
            type="text"
            placeholder="Nhập mật khẩu"
            name="uname"
            required
          />

          <label for="uname">
            <b>Số điện thoại</b>
          </label>
          <input
            v-model="user.phone"
            class="text-create"
            type="text"
            placeholder="Nhập số điện thoại"
            name="uname"
            required
          />

          <label for="uname">
            <b>Email</b>
          </label>
          <input
            v-model="user.email"
            class="text-create"
            type="text"
            placeholder="Nhập email"
            name="uname"
            required
          />

          <label for="uname">
            <b>Địa chỉ</b>
          </label>
          <input
            v-model="user.address"
            class="text-create"
            type="text"
            placeholder="Nhập địa chỉ"
            name="uname"
            required
          />

          <label for="uname">
            <b>Role</b>
          </label>
          <input
            v-model="user.role"
            class="text-create"
            type="text"
            placeholder="Nhập role"
            name="uname"
            required
          />

          <button @click="updateUser()" type="button" class="btn btn-primary margin-t15">Xác Nhận</button>
        </div>
      </div>
    </b-modal>
  </div>
</template>
<script>
import Vue from "vue";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import "vue-toast-notification/dist/theme-sugar.css";
import { removeSpace } from "../../utils/common";
import pagination from "../pagination/pagination";
import responsitories from "../../service/factory/reponsitoryfactory";
const userResponsitories = responsitories.get("user");

export default {
  name: "users",
  data() {
    return {
      title: {
        usid: "STT",
        username: "Tài khoản",
        password: "Mật khẩu",
        phone: "Điện thoại",
        email: "Email",
        address: "Địa chỉ",
        role: "Vai trò",
      },
      userList: [],
      pageOfItems: [],
      user: {
        username: "",
        password: "",
        phone: "",
        email: "",
        address: "",
        role: 0,
      },
      modalCreateUser: false,
      modalUpdateUser: false,
      rows: 10000,
      perPage: 10,
      currentPage: 1,
    };
  },
  methods: {
    async getUserList() {
      var self = this;
      this.userList = [];
      this.pageOfItems = [];
      var perPage = this.perPage;
      await userResponsitories
        .getAllUser()
        .then(function (response) {
          if (response.data.success) {
            self.userList = [];
            self.pageOfItems = [];
            response.data.data.forEach((user, index) => {
              self.userList.push({
                id: index + 1,
                usid: user.usid,
                username: user.username,
                password: "",
                phone: user.phone,
                email: user.email,
                address: user.address,
                role: user.role,
                check: false,
              });

              if (index < perPage) {
                self.pageOfItems.push({
                  id: index + 1,
                  usid: user.usid,
                  username: user.username,
                  password: "",
                  phone: user.phone,
                  email: user.email,
                  address: user.address,
                  role: user.role,
                  check: false,
                });
              }
            });
            self.rows = Math.round(response.data.data.length / perPage) + 1;
            self.listPage = self.userList;
          }
        })
        .catch((error) => {
          var err = removeSpace(error.message.toUpperCase());
          console.log(err);
          Vue.$toast.error(
            this.$i18n.te(err) ? this.$i18n.t(err) : error.message
          );
        });
    },
    createUser() {
      var self = this;
      var userList = this.userList;
      var username = this.user.username;
      var password = this.user.password;

      if (!username && username.length <= 0) {
        Vue.$toast.error(this.$i18n.t("USERNAME_IS_NOT_BLANKED"));
        return;
      }

      if (!password && password.length <= 0) {
        Vue.$toast.error(this.$i18n.t("PASSWORD_IS_NOT_BLANKED"));
        return;
      }

      var valObj = userList.filter(function (user) {
        if (user.username == username) return user.username;
      });

      if (valObj.length > 0) {
        Vue.$toast.error(
          this.$i18n.t("USERNAME_IS_VALID") + ": " + valObj[0].username
        );
        return;
      }

      userResponsitories
        .create(this.user)
        .then(function (response) {
          if (response.data.success) {
            self.modalCreateUser = false;
            self.getUserList();
            Vue.$toast.success(response.data.message);
          } else {
            Vue.$toast.error(response.data.message);
          }
        })
        .catch((error) => {
          var err = removeSpace(error.message.toUpperCase());
          Vue.$toast.error(
            this.$i18n.te(err) ? this.$i18n.t(err) : error.message
          );
        });
    },
    getUpdateUser() {
      var self = this;
      this.user = {
        id: 0,
        usid: 0,
        username: "",
        password: "",
        phone: "",
        email: "",
        address: "",
        role: 0,
        check: false,
      };
      var count = 0;
      self.userList.forEach((user) => {
        if (user.check) {
          this.user = user;
          count = count + 1;
        }
      });
      if (count > 1) {
        Vue.$toast.error(this.$i18n.t("CHECK_ONE_TO_UPDATE"));
      } else if (count == 0) {
        Vue.$toast.error(this.$i18n.t("EMPTY_CHECK"));
      } else if (count == 1) {
        this.modalUpdateUser = true;
      }
    },
    updateUser() {
      var self = this;
      userResponsitories
        .update(self.user)
        .then(function (response) {
          if (response.data.success) {
            self.modalUpdateUser = false;
            self.getUserList();
            Vue.$toast.success(response.data.message);
          } else {
            Vue.$toast.error(response.data.message);
          }
        })
        .catch((error) => {
          var err = removeSpace(error.message.toUpperCase());
          Vue.$toast.error(
            this.$i18n.te(err) ? this.$i18n.t(err) : error.message
          );
        });
    },
    deleteUser() {
      var self = this;
      var checkAdmin = false;
      var deleteList = [];
      self.userList.forEach((user) => {
        if (user.check) {
          if (user.username.toLowerCase() !== "admin") {
            deleteList.push(user.usid);
          } else {
            checkAdmin = true;
            Vue.$toast.error(this.$i18n.t("DO_NOT_CHOOSE_ADMIN"));
          }
        }
      });
      if (checkAdmin == false) {
        if (deleteList.length > 0)
          userResponsitories
            .deleteListUser(deleteList)
            .then(function (response) {
              if (response.data.success) {
                Vue.$toast.success(response.data.message);
                self.getUserList();
              } else {
                Vue.$toast.error(response.data.message);
              }
            })
            .catch((error) => {
              var err = removeSpace(error.message.toUpperCase());
              Vue.$toast.error(
                this.$i18n.te(err) ? this.$i18n.t(err) : error.message
              );
            });
        else {
          Vue.$toast.error(this.$i18n.t("EMPTY_CHECK"));
        }
      }
    },
    getCurrentPage(currentPage, pageOfItems) {
      // update current page
      this.currentPage = currentPage;
      this.pageOfItems = pageOfItems;
    },
  },
  created() {
    this.getUserList();
  },
  components: {
    pagination,
  },
  computed: {
    listPage: {
      get: function () {
        var list = [...Array(this.rows * this.perPage).keys()].map((i) => ({
          id: i + 1,
          item: "Item" + (i + 1),
        }));
        return list;
      },
      set: function (listPage) {
        this.rows = Math.round(listPage.length / this.perPage);
      },
    },
  },
};
</script>

<style scoped>
@import url(./user.css);
</style>
