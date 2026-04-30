using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.PatientService
{
    public interface IStatementFileService
    {
        string GetXmlFile(IPatientChargeStatementDTO patientChargeStatementDTO, string fileName);
        string CombineXmlFiles(List<IFileResultDTO> files, string saveFilePath);
    }
}
