namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Response
{
    public class Response
    {
        public Response(Message message, bool success)
        {
            this.ActionResponse = new ActionResponse(message, success);
        }

        public Response()
        {
        }

        public ActionResponse ActionResponse { get; protected set; }
    }
}
