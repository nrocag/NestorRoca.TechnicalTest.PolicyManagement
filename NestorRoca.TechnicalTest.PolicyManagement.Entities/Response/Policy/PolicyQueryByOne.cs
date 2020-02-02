namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Response.Policy
{
    public class PolicyQueryByOne : Response
    {
        public PolicyQueryByOne(Model.Policy policy)
        {
            bool success = policy != null;
            Message message = success ? Message.SuccessGeneral : Message.NoFound;

            base.ActionResponse = new ActionResponse(message, success);
            this.Policy = policy;
        }

        public Model.Policy Policy { get; private set; }
    }
}
