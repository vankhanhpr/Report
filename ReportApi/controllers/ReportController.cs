using ModelClass.area.response;
using ModelClass.model.report.request;
using REPORT.service;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace REPORT.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportController : ApiController
    {
        // private IConfiguration m_configuration;
        private IReport m_report;
        public ReportController(IReport report)
        {
            m_report = report;
        }
        public dynamic Get(int test)
        {
            return m_report.execureStoreProcedure(test);
        }

        [Route("api/report/getReportDasboard")]
        [HttpPost]
        public DataRespond GetReportDasboard(ReportRequest rq)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_report.getReportDasboard(rq);
                data.message = "susscess";
            }
            catch (Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }

        [Route("api/report/getReportTongYeuCau")]
        [HttpPost]
        public DataRespond GetReportTongYeuCau(ReportRequest rq)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_report.getReportTongYeuCau(rq);
                data.message = "susscess";
            }
            catch (Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }

        [Route("api/report/getListReportSLA")]
        [HttpPost]
        public DataRespond GetListReportSLA(ReportRequest rq)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_report.getListReportSLA(rq);
                data.message = "susscess";
            }
            catch (Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }
    }
}