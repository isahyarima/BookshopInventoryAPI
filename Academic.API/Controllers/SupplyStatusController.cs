using Data.TransferObject.ViewModel;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Wrapper;


namespace careapi.Controllers
{
    [RoutePrefix("api/v1/supplyStatus")]
    [Authorize]
    public class SupplyStatusController : ApiController
    {
        private readonly IWrapperRepository _wrapper;
        public SupplyStatusController(IWrapperRepository wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]SupplyStatusVM model)
        {
            try
            {
                 var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenantId = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                var createdBy = decryptedToken.FirstOrDefault(st => st.Type == "idu").Value;

                var role = decryptedToken.FirstOrDefault(st => st.Type == "idr").Value;

                if (createdBy != null)
                    model.createdBy = Convert.ToInt32(createdBy);

                if (tenantId != null)
                    model.tenantId = Convert.ToInt32(tenantId);

                var result = await _wrapper.SupplyStatus.CreateSupplyStatusAsync(model);

                if (result != null)
                {
                     return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
             return Ok(new { response = "Record not found", success = false });
        }

        [HttpGet]
        [Route("")]
        public async  Task<IHttpActionResult> Get()
        {
            try
            {
                int tenantId = 0;

                int createdById = 0;

                var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                var createdBy = decryptedToken.FirstOrDefault(st => st.Type == "idu").Value;

                if (tenant != null)
                     tenantId = Convert.ToInt32(tenant);

                if (createdBy != null)
                    createdById = Convert.ToInt32(createdBy);

                var result = await _wrapper.SupplyStatus.GetSupplyStatus(tenantId);

                if (result != null)
                {
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
             return Ok(new { response = "Record not found", success = false });
        }


		[HttpGet]
        [Route("{supplyStatusId}/supplyStatusId")]
        public async  Task<IHttpActionResult> GetById(int supplyStatusId)
        {
            try
            {
                int tenantId = 0;

                int createdById = 0;

                var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                var createdBy = decryptedToken.FirstOrDefault(st => st.Type == "idu").Value;

                if (tenant != null)
                     tenantId = Convert.ToInt32(tenant);

                if (createdBy != null)
                    createdById = Convert.ToInt32(createdBy);

                var result = await _wrapper.SupplyStatus.GetSupplyStatusById(supplyStatusId,tenantId);

                if (result != null)
                {
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
             return Ok(new { response = "Record not found", success = false });
        }

        [HttpGet]
        [Route("{supplyStatusId}/supplyStatusId")]
        public async Task<IHttpActionResult> Get(int supplyStatusId)
        {
            try
            {   
                                   var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                int tenantId = 0;

                if (tenant != null)
                    tenantId = Convert.ToInt32(tenant);

                var result = await _wrapper.SupplyStatus.GetSupplyStatus(supplyStatusId, tenantId);

                if (result != null)
                {
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
            return Ok(new { response = "Record not found", success = false });
        }

        [HttpPut]
		[Route("{supplyStatusId}/supplyStatusId")]
        public async Task<IHttpActionResult> Update([FromBody]SupplyStatusVM model, int supplyStatusId)
        {
            try
            {
                var result = await _wrapper.SupplyStatus.UpdateSupplyStatus(supplyStatusId, model);

                if (result != false)
                {
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
             return Ok(new { response = "Record not found", success = false });
        }
        [HttpDelete]
		[Route("{supplyStatusId}/supplyStatusId")]
        public async Task<IHttpActionResult> Delete(int supplyStatusId)
        {
            try
            {
                var result = await _wrapper.SupplyStatus.DeleteSupplyStatus(supplyStatusId);

                if (result != false)
                {
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
            return Ok(new { response = "Record not found", success = false });
        }
    }
}


     
