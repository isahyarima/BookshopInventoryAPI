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
    [RoutePrefix("api/v1/designation")]
    [Authorize]
    public class DesignationController : ApiController
    {
        private readonly IWrapperRepository _wrapper;
        public DesignationController(IWrapperRepository wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]DesignationVM model)
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

                var result = await _wrapper.Designation.CreateDesignationAsync(model);

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

                var result = await _wrapper.Designation.GetDesignation(tenantId);

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
        [Route("{designationId}/designationId")]
        public async  Task<IHttpActionResult> GetById(int designationId)
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

                var result = await _wrapper.Designation.GetDesignationById(designationId,tenantId);

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
        [Route("{designationId}/designationId")]
        public async Task<IHttpActionResult> Get(int designationId)
        {
            try
            {   
                                   var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                int tenantId = 0;

                if (tenant != null)
                    tenantId = Convert.ToInt32(tenant);

                var result = await _wrapper.Designation.GetDesignation(designationId, tenantId);

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
		[Route("{designationId}/designationId")]
        public async Task<IHttpActionResult> Update([FromBody]DesignationVM model, int designationId)
        {
            try
            {
                var result = await _wrapper.Designation.UpdateDesignation(designationId, model);

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
		[Route("{designationId}/designationId")]
        public async Task<IHttpActionResult> Delete(int designationId)
        {
            try
            {
                var result = await _wrapper.Designation.DeleteDesignation(designationId);

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


     
