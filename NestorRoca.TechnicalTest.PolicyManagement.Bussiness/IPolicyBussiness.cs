using NestorRoca.TechnicalTest.PolicyManagement.DataAccess;
using NestorRoca.TechnicalTest.PolicyManagement.Entities.Model;
using NestorRoca.TechnicalTest.PolicyManagement.Entities.Response;
using System.Threading.Tasks;

namespace NestorRoca.TechnicalTest.PolicyManagement.Bussiness
{
    public interface IPolicyBussiness
    {
        IMongoRepository<Policy> RepositoryPolicy { get; set; }

        Task<Response> CreatePolicy(Policy policy);
        Task<Response> DeletePolicy(string id);
        Task<Response> GetAllPolicies();
        Task<Response> GetByIdPolicy(string id);
        Task<Response> UpdatePolicy(Policy policy);
    }
}