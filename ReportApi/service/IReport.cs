using ModelClass.model.report.request;

namespace REPORT.service
{
    public interface IReport
    {
        dynamic execureQuery();
        dynamic execureStoreProcedure(int test);
        dynamic getReportDasboard(ReportRequest rq);
        dynamic getReportTongYeuCau(ReportRequest rq);
        dynamic getListReportSLA(ReportRequest rq);
        dynamic TestSql();
    }
}
