using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Object.CommonEntites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IInsuranceCompanyRepository : IBaseRepository
    {
        Task<IEnumerable<IInsuranceCompany>> Get();
        Task<IEnumerable<IDropDownDTO>> GetAll();
        Task<IEnumerable<IInsuranceCompany>> GetById(IEnumerable<int> Ids);
        Task<IInsuranceCompany> GetById(int? insuranceCompanyId);
        Task<IInsuranceCompany> GetByUId(Guid? uid);
        Task<IEnumerable<IInsuranceCompany>> GetAll(string companyName);
        Task<IEnumerable<IInsuranceCompaniesDTO>> GetForPatient(string searchKey);
        Task<IInsuranceCompany> GetByState(string state);
        Task<IInsuranceCompany> GetInsuranceCompany(string code, string name);
        Task<IInsuranceCompany> AddNew(IInsuranceCompany entity);
        Task<int> Update(IInsuranceCompany entity);
        Task<int> DeleteById(int insuranceCompanyId);
        Task ThrowError(IInsuranceCompany companyData);
        Task InsuranceCompanyIsInUse();
        Task<IEnumerable<IInsuranceCompany>> GetByUId(IEnumerable<Guid> Ids);
        Task<IInsuranceCompany> GetByUId(Guid uid);
        Task<int> DeleteByUId(Guid uid);
        Task<IInsuranceCompany> GetInsuranceCompanyForEMR(string code, string name, short? companyTypeId);
        Task<IInsuranceCompany> GetSelfPayPayer();
    }
}
