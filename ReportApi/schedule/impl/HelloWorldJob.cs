using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;
using System;
using REPORT.service;
using REPORT.service.impl;

namespace ReportSoftWare.schedule
{
    [DisallowConcurrentExecution]
    public class HelloWorldJob : IJob
    {
        //public IReport m_report;
        //public HelloWorldJob(IReport report)
        //{
        //    m_report = report;
        //}

        public void Execute(IJobExecutionContext context)
        {
            ReportImpl x = new ReportImpl();
            ModelClass.WS_800126.AuthHeader auth = new ModelClass.WS_800126.AuthHeader();
            auth.Username = "hampn";
            auth.Password = "vnpt@20190723";
            string noidung = ""; //x.execureQuery();
            //string noidung =  "khong chay";
            string phonenumber = "0833383352";
            ModelClass.WS_800126.Service1 smsend = new ModelClass.WS_800126.Service1();
            smsend.AuthHeaderValue = auth;
            //string result = smsend.sendsms(phonenumber, noidung);
        }
    }
}
