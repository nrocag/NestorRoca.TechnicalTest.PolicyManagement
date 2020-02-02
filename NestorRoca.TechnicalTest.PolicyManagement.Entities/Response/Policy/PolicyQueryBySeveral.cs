namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Response.Policy
{
    using System.Collections.Generic;
    using System.Linq;

    public class PolicyQueryBySeveral : Response
    {
        public PolicyQueryBySeveral(IEnumerable<Model.Policy> policies)
        {
            bool success = policies != null && policies.Any();
            Message message = success ? Message.SuccessGeneral : Message.NoFound;

            base.ActionResponse = new ActionResponse(message, success);
            this.Policies = policies;
        }

        public IEnumerable<Model.Policy> Policies { get; private set; }
    }
}
