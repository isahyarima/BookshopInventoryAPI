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
    [RoutePrefix("api/v1/tenant")]
   // [Authorize]
    public class TenantController : ApiController
    {
        private readonly IWrapperRepository _wrapper;
        public TenantController(IWrapperRepository wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]TenantVM model)
        {
            try
            {
               
                var result = await _wrapper.Tenant.CreateTenantAsync(model);

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
                
                var result = await _wrapper.Tenant.GetTenant();

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


		//[HttpGet]
  //      [Route("{tenantId}/tenantId")]
  //      public async  Task<IHttpActionResult> GetById(int tenantId)
  //      {
  //          try
  //          {
  //              int tenantId = 0;

  //              int createdById = 0;

  //              var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
  //              var decryptedToken = tokenIdentity.Claims;

  //              var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

  //              var createdBy = decryptedToken.FirstOrDefault(st => st.Type == "idu").Value;

  //              if (tenant != null)
  //                   tenantId = Convert.ToInt32(tenant);

  //              if (createdBy != null)
  //                  createdById = Convert.ToInt32(createdBy);

  //              var result = await _wrapper.Tenant.GetTenantById(tenantId,tenantId);

  //              if (result != null)
  //              {
  //                  return Ok(new { response = result, success = true });
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
  //          }
  //           return Ok(new { response = "Record not found", success = false });
  //      }

  //      [HttpGet]
  //      [Route("{tenantId}/tenantId")]
  //      public async Task<IHttpActionResult> Get(int tenantId)
  //      {
  //          try
  //          {   
  //                                 var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
  //              var decryptedToken = tokenIdentity.Claims;

  //              var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

  //              int tenantId = 0;

  //              if (tenant != null)
  //                  tenantId = Convert.ToInt32(tenant);

  //              var result = await _wrapper.Tenant.GetTenant(tenantId, tenantId);

  //              if (result != null)
  //              {
  //                  return Ok(new { response = result, success = true });
  //              }
  //          }
  //          catch (Exception ex)
  //          {
  //              return Ok( new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
  //          }
  //          return Ok(new { response = "Record not found", success = false });
  //      }

        [HttpPut]
		[Route("{tenantId}/tenantId")]
        public async Task<IHttpActionResult> Update([FromBody]TenantVM model, int tenantId)
        {
            try
            {
                var result = await _wrapper.Tenant.UpdateTenant(tenantId, model);

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
		[Route("{tenantId}/tenantId")]
        public async Task<IHttpActionResult> Delete(int tenantId)
        {
            try
            {
                var result = await _wrapper.Tenant.DeleteTenant(tenantId);

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


     
