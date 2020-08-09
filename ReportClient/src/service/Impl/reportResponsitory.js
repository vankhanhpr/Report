import responsitory from '../responsitory/responsitory';

const resource = '/report'
export default {
  getReportDasboard(data) {
    return responsitory.post(`${resource}/getReportDasboard`, data)
  },

  getReportTongYeuCau(data) {
    return responsitory.post(`${resource}/getReportTongYeuCau`, data)
  },

  getListReportSLA(data) {
    return responsitory.post(`${resource}/getListReportSLA`, data)
  }
}
