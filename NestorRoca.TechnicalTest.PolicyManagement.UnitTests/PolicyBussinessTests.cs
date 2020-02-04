namespace NestorRoca.TechnicalTest.PolicyManagement.UnitTests
{
    using Moq;
    using NestorRoca.TechnicalTest.PolicyManagement.Bussiness;
    using NestorRoca.TechnicalTest.PolicyManagement.DataAccess;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Enums;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Model;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Response;
    using System.Threading.Tasks;
    using Xunit;

    public class PolicyBussinessTests
    {
        [Fact]
        public void IfRiskTypeIsHighAndCoveragePercentageIsLessTo50ValidateToCreatePolicyIsSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 40,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 50000,
                RiskType = RiskType.Alto
            };
            
            IPolicyBussiness policyBussiness = new PolicyBussiness();
            
            var mockRepository = new Mock<IMongoRepository<Policy>>();
            mockRepository.Setup(p => p.InsertOne(policy)).Returns(Task.CompletedTask);
            policyBussiness.RepositoryPolicy = mockRepository.Object;

            Response response = policyBussiness.CreatePolicy(policy).Result;

            Assert.True(response.ActionResponse.Success);
        }

        [Fact]
        public void IfRiskTypeIsHighAndCoveragePercentageIs50ValidateToCreatePolicyIsNotSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 51,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 50000,
                RiskType = RiskType.Alto
            };

            IPolicyBussiness policyBussiness = new PolicyBussiness();

            Response response = policyBussiness.CreatePolicy(policy).Result;

            Assert.False(response.ActionResponse.Success);
            Assert.Equal(Message.CoveragePercentageByCoveringTypeIncorrect.Text, response.ActionResponse.Message.Text);
        }

        [Fact]
        public void CreatePolicyIsSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 99,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 897456,
                RiskType = RiskType.Medio
            };

            IPolicyBussiness policyBussiness = new PolicyBussiness();

            var mockRepository = new Mock<IMongoRepository<Policy>>();
            mockRepository.Setup(p => p.InsertOne(policy)).Returns(Task.CompletedTask);

            policyBussiness.RepositoryPolicy = mockRepository.Object;

            Response response = policyBussiness.CreatePolicy(policy).Result;

            Assert.True(response.ActionResponse.Success);
        }

        [Fact]
        public void IfRiskTypeIsHighAndCoveragePercentageIsLessTo50ValidateToUpdatePolicyIsSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 40,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 50000,
                RiskType = RiskType.Alto
            };

            IPolicyBussiness policyBussiness = new PolicyBussiness();

            var mockRepository = new Mock<IMongoRepository<Policy>>();
            mockRepository.Setup(p => p.InsertOne(policy)).Returns(Task.CompletedTask);
            policyBussiness.RepositoryPolicy = mockRepository.Object;

            Response response = policyBussiness.UpdatePolicy(policy).Result;

            Assert.True(response.ActionResponse.Success);
        }

        [Fact]
        public void IfRiskTypeIsHighAndCoveragePercentageIs50ValidateToUpdatePolicyIsNotSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 51,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 50000,
                RiskType = RiskType.Alto
            };

            IPolicyBussiness policyBussiness = new PolicyBussiness();

            Response response = policyBussiness.UpdatePolicy(policy).Result;

            Assert.False(response.ActionResponse.Success);
            Assert.Equal(Message.CoveragePercentageByCoveringTypeIncorrect.Text, response.ActionResponse.Message.Text);
        }

        [Fact]
        public void UpdatePolicyIsSuccess()
        {
            Policy policy = new Policy
            {
                AmountMonthsCoverage = 12,
                CoveragePercentage = 99,
                CoveringType = CoveringType.Incendio,
                Description = "Descripcion poliza prueba unitaria",
                Name = "Poliza prueba unitaria",
                Price = 897456,
                RiskType = RiskType.Medio
            };

            IPolicyBussiness policyBussiness = new PolicyBussiness();

            var mockRepository = new Mock<IMongoRepository<Policy>>();
            mockRepository.Setup(p => p.InsertOne(policy)).Returns(Task.CompletedTask);

            policyBussiness.RepositoryPolicy = mockRepository.Object;

            Response response = policyBussiness.UpdatePolicy(policy).Result;

            Assert.True(response.ActionResponse.Success);
        }
    }
}
