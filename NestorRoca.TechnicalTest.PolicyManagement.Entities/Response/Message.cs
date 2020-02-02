namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Response
{
    public class Message
    {
        /// <summary>
        /// Proceso realizado exitosamente
        /// </summary>
        public static Message SuccessGeneral
        {
            get
            {
                return new Message(1, "Proceso realizado exitosamente.");
            }
        }

        /// <summary>
        /// No existen registros
        /// </summary>
        public static Message NoFound
        {
            get
            {
                return new Message(2, "No existen registros.");
            }
        }

        /// <summary>
        /// Proceso no fue exitoso.
        /// </summary>
        public static Message NoSuccess
        {
            get
            {
                return new Message(3, "Proceso no fue exitoso.");
            }
        }

        /// <summary>
        /// Proceso no fue exitoso.
        /// </summary>
        public static Message CoveragePercentageByCoveringTypeIncorrect
        {
            get
            {
                return new Message(4, "Cuando es línea de riesgo alto, el porcentaje de cubrimiento no puede superar al 50%.");
            }
        }

        private Message(int code, string text) {
            this.Code = code;
            this.Text = text;
        }

        public int Code { get; set; }

        public string Text { get; set; }
    }
}