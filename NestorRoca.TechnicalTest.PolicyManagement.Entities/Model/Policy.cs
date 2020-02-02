namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Model
{
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Enums;

    public class Policy : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int AmountMonthsCoverage { get; set; }

        public int Price { get; set; }

        public CoveringType CoveringType { get; set; }

        public int CoveragePercentage { get; set; }

        public RiskType RiskType { get; set; }
    }
}
