<template>
  <div class="k main-form">
    <div class="k wf main-container">
      <div class="k wf card">
        <div class="k wf card-title">
          <span>{{ $t("common.OBSERVATION").toUpperCase() }}</span>
        </div>

        <div class="k wf flex-row">
          <div class="k part">
            <tr v-for="(item, index) in sum" :key="index">
              <th class="col-sum">{{ item.name }}</th>
              <th class="col-sum">{{ item.value }}</th>
            </tr>
          </div>

          <div class="k part flex-row">
            <div class="demonstration">{{ $t("home.PICK_MONTH") }}</div>
            <el-date-picker
              class="date-time-picker"
              v-model="month"
              @change="getReportSLA(month)"
              type="month"
              v-bind:placeholder="this.$i18n.t(pickMonth)"
              align="right"
            ></el-date-picker>
          </div>
        </div>

        <div class="k wf card-container">
          <table class="table">
            <tr class="table-title">
              <th class="table-title">{{ title.STT }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_KHACH_HANG) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_DO_UU_TIEN) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.GIAI_DOAN_HIEN_TAI) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_BAT_DAU) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_KET_THUC) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.SLA_CHUAN) }}</th>
              <th class="table-title">{{ title.SLA }}</th>
              <th class="table-title">{{ this.$i18n.t(title.NGUOI_THUC_HIEN) }}</th>
            </tr>
            <tr class="table-title">
              <th class="table-title"></th>

              <th class="table-title">
                <el-input
                  v-bind:placeholder="this.$i18n.t(title.TEN_KHACH_HANG)"
                  v-model="inputCustomer"
                  clearable
                ></el-input>
              </th>
              <th class="table-title"></th>
              <th class="table-title">
                <el-select
                  v-model="selectedStage"
                  filterable
                  v-bind:placeholder="this.$i18n.t(select_stage)"
                >
                  <el-option
                    v-for="item in stages"
                    :key="item.value"
                    :label="item.label"
                    :value="item.value"
                  ></el-option>
                </el-select>
              </th>
              <th class="table-title"></th>
              <th class="table-title"></th>
              <th class="table-title"></th>
              <th class="table-title"></th>
              <th class="table-title"></th>
            </tr>
            <tr v-for="(item, index) in pageOfItems" :key="index">
              <th>{{ item.id }}</th>
              <th>{{ item.TEN_KHACH_HANG }}</th>
              <th>{{ item.TEN_DO_UU_TIEN }}</th>
              <th>{{ item.GIAI_DOAN_HIEN_TAI }}</th>
              <th>{{ item.THOI_GIAN_BAT_DAU_KSYC }}</th>
              <th>{{ item.THOI_GIAN_KET_THUC_KSYC }}</th>
              <th>{{ item.THOI_GIAN_SLA_KSYC_CHITIET }}</th>
              <th>{{ item.SLA_KSYC }}</th>
            </tr>
          </table>
        </div>
        <pagination
          class="pagination"
          :items="reportList.length > 0 ? reportList : listPage"
          :pageSize="perPage"
          :maxPages="6"
          @currentPage="getCurrentPage"
        ></pagination>
      </div>
      <div class="loading"></div>
    </div>
  </div>
</template>
<script>
import Vue from "vue";
import $ from "jquery";
import moment from "moment";
import { removeSpace } from "../../utils/common";
import responsitories from "../../service/factory/reponsitoryfactory";
const reportResponsitories = responsitories.get("report");
import pagination from "../pagination/pagination";

export default {
  name: "Observation",
  data() {
    return {
      sum: [
        {
          name: "Tổng yêu cầu",
          value: 100,
          children: [],
        },
        {
          name: "Tổng hoàn tất",
          value: 90,
          children: [
            {
              name: "Đúng hạn",
              value: 85,
            },
            {
              name: "Trễ hạn",
              value: 5,
            },
          ],
        },
        {
          name: "Tổng tồn",
          value: 10,
          children: [
            {
              name: "Đúng hạn",
              value: 8,
            },
            {
              name: "Trễ hạn",
              value: 2,
            },
          ],
        },
      ],
      title: {
        STT: "STT",
        TEN_KHACH_HANG: "detail.CUSTOMER",
        TEN_DO_UU_TIEN: "detail.PRIORITY",
        GIAI_DOAN_HIEN_TAI: "detail.CURRENT_STAGE",
        THOI_GIAN_BAT_DAU: "home.START_DATE",
        THOI_GIAN_KET_THUC: "home.END_DATE",
        SLA_CHUAN: "detail.SLA_CHUAN",
        SLA: "SLA",
        NGUOI_THUC_HIEN: "detail.NGUOI_THUC_HIEN",
      },
      isHigh: true,
      month: new Date(),
      pickMonth: "home.PICK_MONTH",
      inputDate: "",
      inputCustomer: "",
      select_stage: "home.SELECT_STAGE",
      stages: [
        {
          value: "6",
          label: this.$i18n.t("home.REQUEST"),
        },
        {
          value: "7",
          label: this.$i18n.t("home.DESIGN"),
        },
        {
          value: "8",
          label: this.$i18n.t("home.BUILD_WEBSITE_TEST"),
        },
        {
          value: "9",
          label: this.$i18n.t("home.BUILD_WEBSITE_OFFICIAL"),
        },
      ],
      selectedStage: "",
      reportList: [],
      pageOfItems: [],
      rows: 10000,
      perPage: 20,
      currentPage: 1,
    };
  },
  methods: {
    // showLoading() {
    //   $(".loading").show(100);
    // },
    // hideLoading() {
    //   $(".loading").hide(100);
    // },
    async getReportSLA() {
      $(".loading").show(100);
      var self = this;
      this.reportList = [];
      var perPage = this.perPage;
      var v_ID_NHOM_GIAI_DOAN = 18;
      var v_YEAR = Number(moment(this.month).format("YYYY"));
      var v_MONTH = Number(moment(this.month).format("MM"));
      var data = {
        v_ID_NHOM_GIAI_DOAN,
        v_YEAR,
        v_MONTH,
      };
      await reportResponsitories
        .getListReportSLA(data)
        .then(function (response) {
          if (response && response.data.success) {
            self.pageOfItems = [];
            response.data.data.forEach((report, index) => {
              self.reportList.push({
                id: index + 1,
                NGAY_TAO: report.NGAY_TAO,
                TEN_KHACH_HANG: report.TEN_KHACH_HANG,
                TEN_DO_UU_TIEN: report.TEN_DO_UU_TIEN,
                GIAI_DOAN_HIEN_TAI: report.GIAI_DOAN_HIEN_TAI,
                THOI_GIAN_BAT_DAU_KSYC: report.THOI_GIAN_BAT_DAU_KSYC,
                THOI_GIAN_KET_THUC_KSYC: report.THOI_GIAN_KET_THUC_KSYC,
                SLA_KSYC: report.SLA_KSYC,
                THOI_GIAN_SLA_KSYC_CHITIET: report.THOI_GIAN_SLA_KSYC_CHITIET,
                DANH_GIA_SLA_KSYC: report.DANH_GIA_SLA_KSYC,
                THOI_GIAN_BAT_DAU_TKHD: report.THOI_GIAN_BAT_DAU_TKHD,
                THOI_GIAN_KET_THUC_TKHD: report.THOI_GIAN_KET_THUC_TKHD,
                SLA_TKHD: report.SLA_TKHD,
                THOI_GIAN_SLA_TKHD_CHITIET: report.THOI_GIAN_SLA_TKHD_CHITIET,
                DANH_GIA_SLA_TKHD: report.DANH_GIA_SLA_TKHD,
                THOI_GIAN_BAT_DAU_DWST: report.THOI_GIAN_BAT_DAU_DWST,
                THOI_GIAN_KET_THUC_DWST: report.THOI_GIAN_KET_THUC_DWST,
                SLA_DWST: report.SLA_DWST,
                DANH_GIA_SLA_DWST: report.DANH_GIA_SLA_DWST,
                THOI_GIAN_BAT_DAU_DWSCT: report.THOI_GIAN_BAT_DAU_DWSCT,
                THOI_GIAN_KET_THUC_DWSCT: report.THOI_GIAN_KET_THUC_DWSCT,
                SLA_DWSCT: report.SLA_DWSCT,
                DANH_GIA_SLA_DWSCT: report.DANH_GIA_SLA_DWSCT,
              });
              if (index < perPage) {
                self.pageOfItems.push({
                  id: index + 1,
                  NGAY_TAO: report.NGAY_TAO,
                  TEN_KHACH_HANG: report.TEN_KHACH_HANG,
                  TEN_DO_UU_TIEN: report.TEN_DO_UU_TIEN,
                  GIAI_DOAN_HIEN_TAI: report.GIAI_DOAN_HIEN_TAI,
                  THOI_GIAN_BAT_DAU_KSYC: report.THOI_GIAN_BAT_DAU_KSYC,
                  THOI_GIAN_KET_THUC_KSYC: report.THOI_GIAN_KET_THUC_KSYC,
                  SLA_KSYC: report.SLA_KSYC,
                  THOI_GIAN_SLA_KSYC_CHITIET: report.THOI_GIAN_SLA_KSYC_CHITIET,
                  DANH_GIA_SLA_KSYC: report.DANH_GIA_SLA_KSYC,
                  THOI_GIAN_BAT_DAU_TKHD: report.THOI_GIAN_BAT_DAU_TKHD,
                  THOI_GIAN_KET_THUC_TKHD: report.THOI_GIAN_KET_THUC_TKHD,
                  SLA_TKHD: report.SLA_TKHD,
                  THOI_GIAN_SLA_TKHD_CHITIET: report.THOI_GIAN_SLA_TKHD_CHITIET,
                  DANH_GIA_SLA_TKHD: report.DANH_GIA_SLA_TKHD,
                  THOI_GIAN_BAT_DAU_DWST: report.THOI_GIAN_BAT_DAU_DWST,
                  THOI_GIAN_KET_THUC_DWST: report.THOI_GIAN_KET_THUC_DWST,
                  SLA_DWST: report.SLA_DWST,
                  DANH_GIA_SLA_DWST: report.DANH_GIA_SLA_DWST,
                  THOI_GIAN_BAT_DAU_DWSCT: report.THOI_GIAN_BAT_DAU_DWSCT,
                  THOI_GIAN_KET_THUC_DWSCT: report.THOI_GIAN_KET_THUC_DWSCT,
                  SLA_DWSCT: report.SLA_DWSCT,
                  DANH_GIA_SLA_DWSCT: report.DANH_GIA_SLA_DWSCT,
                });
              }
            });
            self.rows = Math.round(response.data.data.length / perPage) + 1;
            self.listPage = response.data.data;
            $(".loading").hide(100);
          } else {
            var err = removeSpace(response.data.message.toUpperCase());
            console.log(
              this.$i18n.te(err) ? this.$i18n.t(err) : response.data.message
            );
            Vue.$toast.error(
              this.$i18n.te(err) ? this.$i18n.t(err) : response.data.message
            );
            $(".loading").hide(100);
          }
        })
        .catch((error) => {
          var err = removeSpace(error.message.toUpperCase());
          Vue.$toast.error(
            this.$i18n.te(err) ? this.$i18n.t(err) : error.message
          );
          $(".loading").hide(100);
        });
    },
    getCurrentPage(currentPage, pageOfItems) {
      // update current page
      this.currentPage = currentPage;
      this.pageOfItems = pageOfItems;
    },
  },
  created() {
    this.getReportSLA();
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
@import url(./observation.css);
</style>
