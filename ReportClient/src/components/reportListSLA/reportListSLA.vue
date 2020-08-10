<template>
  <div class="k main-form">
    <div class="k tab-head">
      <span class="k text-header">{{ $t("common.REPORT_LIST_SLA") }}</span>
    </div>

    <div class="k wf main-container">
      <div class="k wf card">
        <div class="k wf card-title">
          <span>{{ $t("common.REPORT_LIST_SLA").toUpperCase() }}</span>
        </div>

        <div class="k wf flex-row">
          <div class="k part">
            <tr v-for="(item, index) in sum" :key="index">
              <th class="col-sum">{{ item.name }}</th>
              <th class="col-sum">{{ item.value }}</th>
            </tr>
          </div>

          <div class="k part">
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
              <th class="table-title">{{ this.$i18n.t(title.NGAY_TAO) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_KHACH_HANG) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_DO_UU_TIEN) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_BAT_DAU_KSYC) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_KET_THUC_KSYC) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.SLA_KSYC) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_SLA_KSYC_CHITIET) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.DANH_GIA_SLA_KSYC) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_BAT_DAU_TKHD) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_KET_THUC_TKHD) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.SLA_TKHD) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_SLA_TKHD_CHITIET) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.DANH_GIA_SLA_TKHD) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_BAT_DAU_DWST) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_KET_THUC_DWST) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.SLA_DWST) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.DANH_GIA_SLA_DWST) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_BAT_DAU_DWSCT) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THOI_GIAN_KET_THUC_DWSCT) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.SLA_DWSCT) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.DANH_GIA_SLA_DWSCT) }}</th>
            </tr>
            <!-- <tr class="table-title">
              <th class="table-title">
                <el-input
                  v-bind:placeholder="this.$i18n.t(title.NGAY_TAO)"
                  v-model="inputDate"
                  clearable
                ></el-input>
              </th>
              <th class="table-title">
                <el-input
                  v-bind:placeholder="this.$i18n.t(title.TEN_KHACH_HANG)"
                  v-model="inputCustomer"
                  clearable
                ></el-input>
              </th>
              <th class="table-title"></th>
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
            </tr>-->
            <tr v-for="(item, index) in pageOfItems" :key="index">
              <th>{{ item.NGAY_TAO }}</th>
              <th>{{ item.TEN_KHACH_HANG }}</th>
              <th>{{ item.TEN_DO_UU_TIEN }}</th>
              <th>{{ item.THOI_GIAN_BAT_DAU_KSYC }}</th>
              <th>{{ item.THOI_GIAN_KET_THUC_KSYC }}</th>
              <th>{{ item.SLA_KSYC }}</th>
              <th>{{ item.THOI_GIAN_SLA_KSYC_CHITIET }}</th>
              <th>{{ item.DANH_GIA_SLA_KSYC }}</th>
              <th>{{ item.THOI_GIAN_BAT_DAU_TKHD }}</th>
              <th>{{ item.THOI_GIAN_KET_THUC_TKHD }}</th>
              <th>{{ item.SLA_TKHD }}</th>
              <th>{{ item.THOI_GIAN_SLA_TKHD_CHITIET }}</th>
              <th>{{ item.DANH_GIA_SLA_TKHD }}</th>
              <th>{{ item.THOI_GIAN_BAT_DAU_DWST }}</th>
              <th>{{ item.THOI_GIAN_KET_THUC_DWST }}</th>
              <th>{{ item.SLA_DWST }}</th>
              <th>{{ item.DANH_GIA_SLA_DWST }}</th>
              <th>{{ item.THOI_GIAN_BAT_DAU_DWSCT }}</th>
              <th>{{ item.THOI_GIAN_KET_THUC_DWSCT }}</th>
              <th>{{ item.SLA_DWSCT }}</th>
              <th>{{ item.DANH_GIA_SLA_DWSCT }}</th>
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
  name: "ReportSLA",
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
        NGAY_TAO: "detail.DATE_CREATED",
        TEN_KHACH_HANG: "detail.CUSTOMER",
        TEN_DO_UU_TIEN: "detail.PRIORITY",
        THOI_GIAN_BAT_DAU_KSYC: "detail.THOI_GIAN_BAT_DAU_KSYC",
        THOI_GIAN_KET_THUC_KSYC: "detail.THOI_GIAN_KET_THUC_KSYC",
        SLA_KSYC: "detail.SLA_KSYC",
        THOI_GIAN_SLA_KSYC_CHITIET: "detail.THOI_GIAN_SLA_KSYC_CHITIET",
        DANH_GIA_SLA_KSYC: "detail.DANH_GIA_SLA_KSYC",
        THOI_GIAN_BAT_DAU_TKHD: "detail.THOI_GIAN_BAT_DAU_TKHD",
        THOI_GIAN_KET_THUC_TKHD: "detail.THOI_GIAN_KET_THUC_TKHD",
        SLA_TKHD: "detail.SLA_TKHD",
        THOI_GIAN_SLA_TKHD_CHITIET: "detail.THOI_GIAN_SLA_TKHD_CHITIET",
        DANH_GIA_SLA_TKHD: "detail.DANH_GIA_SLA_TKHD",
        THOI_GIAN_BAT_DAU_DWST: "detail.THOI_GIAN_BAT_DAU_DWST",
        THOI_GIAN_KET_THUC_DWST: "detail.THOI_GIAN_KET_THUC_DWST",
        SLA_DWST: "detail.SLA_DWST",
        DANH_GIA_SLA_DWST: "detail.DANH_GIA_SLA_DWST",
        THOI_GIAN_BAT_DAU_DWSCT: "detail.THOI_GIAN_BAT_DAU_DWSCT",
        THOI_GIAN_KET_THUC_DWSCT: "detail.THOI_GIAN_KET_THUC_DWSCT",
        SLA_DWSCT: "detail.SLA_DWSCT",
        DANH_GIA_SLA_DWSCT: "detail.DANH_GIA_SLA_DWSCT",
      },
      isHigh: true,
      month: "",
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
      perPage: 10,
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
      setTimeout(function () {
        $(".loading").hide(100);
      }, 30000);
      var self = this;
      this.reportList = [];
      var perPage = this.perPage;
      var v_ID_NHOM_GIAI_DOAN = 18;
      var currentTime = new Date();
      var v_YEAR = Number(moment(currentTime).format("YYYY"));
      var v_MONTH = Number(moment(currentTime).format("MM")) - 2;
      var data = {
        v_ID_NHOM_GIAI_DOAN,
        v_YEAR,
        v_MONTH,
      };
      await reportResponsitories
        .getListReportSLA(data)
        .then(function (response) {
          if (response && response.data.success) {
            self.reportList = response.data.data;
            self.pageOfItems = [];
            response.data.data.forEach((report, index) => {
              if (index < perPage) {
                self.pageOfItems.push({
                  id: index + 1,
                  NGAY_TAO: report.NGAY_TAO,
                  TEN_KHACH_HANG: report.TEN_KHACH_HANG,
                  TEN_DO_UU_TIEN: report.TEN_DO_UU_TIEN,
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
            Vue.$toast.error(
              this.$i18n.te(err) ? this.$i18n.t(err) : response.data.message
            );
          }
        })
        .catch((error) => {
          var err = removeSpace(error.message.toUpperCase());
          Vue.$toast.error(
            this.$i18n.te(err) ? this.$i18n.t(err) : error.message
          );
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
@import url(./reportListSLA.css);
</style>
