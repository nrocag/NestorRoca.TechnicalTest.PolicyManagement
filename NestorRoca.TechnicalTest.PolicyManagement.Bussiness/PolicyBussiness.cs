namespace NestorRoca.TechnicalTest.PolicyManagement.Bussiness
{
    using NestorRoca.TechnicalTest.PolicyManagement.DataAccess;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Enums;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Model;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Response;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Response.Policy;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PolicyBussiness : IPolicyBussiness
    {
        public IMongoRepository<Policy> RepositoryPolicy { get; set; }

        public PolicyBussiness()
        {
            this.RepositoryPolicy = new MongoRepository<Policy>();
        }

        public async Task<Response> GetAllPolicies()
        {
            IEnumerable<Policy> policies = await this.RepositoryPolicy.GetAll();

            return new PolicyQueryBySeveral(policies);
        }

        public async Task<Response> GetByIdPolicy(string id)
        {
            Policy policy = await this.RepositoryPolicy.GetOne(id);

            return new PolicyQueryByOne(policy);
        }

        public async Task<Response> CreatePolicy(Policy policy)
        {
            if (this.IsCorrectCoveragePercentageByCoveringType(policy))
            {
                await this.RepositoryPolicy.UpdateOne(policy);
                return new Response(Message.SuccessGeneral, true);
            }
            else
            {
                return new Response(Message.CoveragePercentageByCoveringTypeIncorrect, false);
            }
        }

        public async Task<Response> UpdatePolicy(Policy policy)
        {
            if (this.IsCorrectCoveragePercentageByCoveringType(policy))
            {
                await this.RepositoryPolicy.UpdateOne(policy);
                return new Response(Message.SuccessGeneral, true);
            }
            else
            {
                return new Response(Message.CoveragePercentageByCoveringTypeIncorrect, false);
            }
        }

        public async Task<Response> DeletePolicy(string id)
        {
            await this.RepositoryPolicy.DeleteById(id);

            return new Response(Message.SuccessGeneral, true);
        }

        private bool IsCorrectCoveragePercentageByCoveringType(Policy policy)
        {
            bool isCorrect = true;

            if (policy.RiskType == RiskType.Alto && policy.CoveragePercentage > 50)
            {
                isCorrect = false;
            }

            return isCorrect;
        }
    }
}
