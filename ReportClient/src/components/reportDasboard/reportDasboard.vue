<template>
  <div class="k main-form">
    <div class="k tab-head">
      <span class="k text-header">{{ $t("home.REQUEST_LIST") }}</span>
    </div>

    <div class="k wf main-container">
      <div class="k wf card">
        <div class="k wf card-title">
          <span>{{ $t("home.REQUEST_LIST").toUpperCase() }}</span>
        </div>

        <div class="k wf flex-row">
          <div class="k part">
            <tr v-for="(item, index) in sum" :key="index">
              <th class="col-sum">{{ item.name }}</th>
              <th class="col-sum">{{ item.value }}</th>
            </tr>
          </div>

          <div class="k part">
            <div class="demonstration">{{ $t("home.DATE_TO_DATE") }}</div>
            <el-date-picker
              class="date-time-picker"
              v-model="rangeDate"
              @change="getDasboard(rangeDate)"
              type="datetimerange"
              :picker-options="pickerOptions"
              range-separator="-"
              v-bind:start-placeholder="this.$i18n.t(startDate)"
              v-bind:end-placeholder="this.$i18n.t(endDate)"
              align="right"
            ></el-date-picker>
          </div>
        </div>

        <div class="k wf card-container">
          <table class="table">
            <tr class="table-title">
              <th class="table-title">{{ this.$i18n.t(title.NGAY_BAT_DAU) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_KHACH_HANG) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.TEN_DO_UU_TIEN) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.THUC_HIEN) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.GIAI_DOAN_HIEN_TAI) }}</th>
              <th class="table-title">{{ this.$i18n.t(title.DON_VI_THUC_HIEN) }}</th>
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
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.NGAY_BAT_DAU }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.NGAY_BAT_DAU }}</th>
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.TEN_KHACH_HANG }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.TEN_KHACH_HANG }}</th>
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.TEN_DO_UU_TIEN }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.TEN_DO_UU_TIEN }}</th>
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.THUC_HIEN }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.THUC_HIEN }}</th>
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.GIAI_DOAN_HIEN_TAI }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.GIAI_DOAN_HIEN_TAI }}</th>
              <th
                v-if="item.TEN_DO_UU_TIEN === 'cao'"
                v-bind:class="{ high: isHigh }"
              >{{ item.DON_VI_THUC_HIEN }}</th>
              <th v-else-if="item.TEN_DO_UU_TIEN !== 'cao'">{{ item.DON_VI_THUC_HIEN }}</th>
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
    </div>
    <div class="loading"></div>
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
  name: "ReportDasboard",
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
        NGAY_BAT_DAU: "detail.DATE_CREATED",
        TEN_KHACH_HANG: "detail.CUSTOMER",
        TEN_DO_UU_TIEN: "detail.PRIORITY",
        THUC_HIEN: "detail.STATUS",
        GIAI_DOAN_HIEN_TAI: "detail.CURRENT_STAGE",
        DON_VI_THUC_HIEN: "detail.EXECUTION_UNIT",
      },
      isHigh: true,
      pickerOptions: {
        shortcuts: [
          {
            text: this.$i18n.t("home.LAST_WEEK"),
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: this.$i18n.t("home.LAST_MONTH"),
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
              picker.$emit("pick", [start, end]);
            },
          },
          {
            text: this.$i18n.t("home.LAST_3_MONTHS"),
            onClick(picker) {
              const end = new Date();
              const start = new Date();
              start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
              picker.$emit("pick", [start, end]);
            },
          },
        ],
      },
      rangeDate: "",
      startDate: "home.START_DATE",
      endDate: "home.END_DATE",
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
    getDasboard() {
      $(".loading").show(100);
      setTimeout(function () {
        $(".loading").hide(100);
      }, 30000);
      var self = this;
      this.reportList = [];
      var perPage = this.perPage;
      var endDate = new Date();
      var startDate = new Date();
      startDate.setTime(startDate.getTime() - 3600 * 1000 * 24 * 30);
      if (this.rangeDate) {
        startDate = moment(this.rangeDate[0]).format("YYYY-MM-DD");
        endDate = moment(this.rangeDate[1]).format("YYYY-MM-DD");
      } else {
        startDate = moment(startDate).format("YYYY-MM-DD");
        endDate = moment(endDate).format("YYYY-MM-DD");
      }
      var data = {
        v_FROM_DATE: startDate,
        v_TO_DATE: endDate,
      };
      reportResponsitories
        .getReportDasboard(data)
        .then(function (response) {
          if (response && response.data.success) {
            self.reportList = response.data.data;
            self.pageOfItems = [];
            response.data.data.forEach((report, index) => {
              if (index < perPage) {
                self.pageOfItems.push({
                  id: index + 1,
                  NGAY_BAT_DAU: report.NGAY_BAT_DAU,
                  TEN_KHACH_HANG: report.TEN_KHACH_HANG,
                  TEN_DO_UU_TIEN: report.TEN_DO_UU_TIEN,
                  THUC_HIEN: report.THUC_HIEN,
                  GIAI_DOAN_HIEN_TAI: report.GIAI_DOAN_HIEN_TAI,
                  DON_VI_THUC_HIEN: report.DON_VI_THUC_HIEN,
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
    this.getDasboard();
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
@import url(./reportDasboard.css);
</style>
