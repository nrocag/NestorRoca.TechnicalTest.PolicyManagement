namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Model
{
    using System.Collections.Generic;

    public class Customer : Person
    {
        public Customer()
        {
            this.Policies = new List<Policy>();
        }

        public IEnumerable<Policy> Policies { get; set; }
    }
}
