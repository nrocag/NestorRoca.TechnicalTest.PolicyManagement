namespace NestorRoca.TechnicalTest.PolicyManagement.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NestorRoca.TechnicalTest.PolicyManagement.Bussiness;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Model;
    using NestorRoca.TechnicalTest.PolicyManagement.Entities.Response;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class PolicyController : ControllerBase
    {
        public IPolicyBussiness PolicyBussiness;

        public ILogger Instrumenter { get; set; }

        public PolicyController(IPolicyBussiness policyBussiness, ILogger<PolicyController> instrumenter)
        {
            this.Instrumenter = instrumenter;
            this.PolicyBussiness = policyBussiness;
        }

        [HttpGet]
        [Route(ApiVersion.V1 + "/GetAllPolicies")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Response>> GetAllPolicies()
        {
            ActionResult action;

            try
            {
                Response response = await this.PolicyBussiness.GetAllPolicies();
                action = response.ActionResponse.Success ? this.Ok(response) : (ActionResult)this.NotFound(response);
            }
            catch (Exception ex)
            {
                this.Instrumenter.LogError(ex, ex.Message);
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        [HttpGet]
        [Route(ApiVersion.V1 + "/GetByPolicyId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Response>> GetByPolicyId(string id)
        {
            ActionResult action;

            try
            {
                Response response = await this.PolicyBussiness.GetByIdPolicy(id);
                action = response.ActionResponse.Success ? this.Ok(response) : (ActionResult)this.NotFound(response);
            }
            catch (Exception ex)
            {
                this.Instrumenter.LogError(ex, ex.Message);
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        [HttpPost]
        [Route(ApiVersion.V1 + "/CreatePolicy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Response>> CreatePolicy(Policy policy)
        {
            ActionResult action;

            try
            {
                Response response = await this.PolicyBussiness.CreatePolicy(policy);
                action = response.ActionResponse.Success ? this.Ok(response) : (ActionResult)this.BadRequest(response);
            }
            catch (Exception ex)
            {
                this.Instrumenter.LogError(ex, ex.Message);
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        [HttpPut]
        [Route(ApiVersion.V1 + "/UpdatePolicy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Response>> UpdatePolicy(Policy policy)
        {
            ActionResult action;

            try
            {
                Response response = await this.PolicyBussiness.UpdatePolicy(policy);
                action = response.ActionResponse.Success ? this.Ok(response) : (ActionResult)this.BadRequest(response);
            }
            catch (Exception ex)
            {
                this.Instrumenter.LogError(ex, ex.Message);
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }

        [HttpDelete]
        [Route(ApiVersion.V1 + "/DeletePolicy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<Response>> DeletePolicy(string id)
        {
            ActionResult action;

            try
            {
                Response response = await this.PolicyBussiness.DeletePolicy(id);
                action = response.ActionResponse.Success ? this.Ok(response) : (ActionResult)this.BadRequest(response);
            }
            catch (Exception ex)
            {
                this.Instrumenter.LogError(ex, ex.Message);
                action = this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return action;
        }
    }
}