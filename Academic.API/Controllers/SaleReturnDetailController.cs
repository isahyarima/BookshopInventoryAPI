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
    [RoutePrefix("api/v1/saleReturnDetail")]
    [Authorize]
    public class SaleReturnDetailController : ApiController
    {
        private readonly IWrapperRepository _wrapper;
        public SaleReturnDetailController(IWrapperRepository wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]SaleReturnDetailVM model)
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

                var result = await _wrapper.SaleReturnDetail.CreateSaleReturnDetailAsync(model);

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

                var result = await _wrapper.SaleReturnDetail.GetSaleReturnDetail(tenantId);

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
        [Route("{saleReturnDetailId}/saleReturnDetailId")]
        public async  Task<IHttpActionResult> GetById(int saleReturnDetailId)
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

                var result = await _wrapper.SaleReturnDetail.GetSaleReturnDetailById(saleReturnDetailId,tenantId);

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
        [Route("{saleReturnDetailId}/saleReturnDetailId")]
        public async Task<IHttpActionResult> Get(int saleReturnDetailId)
        {
            try
            {   
                                   var tokenIdentity = new ClaimsIdentity(HttpContext.Current.User.Identity);
                var decryptedToken = tokenIdentity.Claims;

                var tenant = decryptedToken.FirstOrDefault(st => st.Type == "tenantId").Value;

                int tenantId = 0;

                if (tenant != null)
                    tenantId = Convert.ToInt32(tenant);

                var result = await _wrapper.SaleReturnDetail.GetSaleReturnDetail(saleReturnDetailId, tenantId);

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
		[Route("{saleReturnDetailId}/saleReturnDetailId")]
        public async Task<IHttpActionResult> Update([FromBody]SaleReturnDetailVM model, int saleReturnDetailId)
        {
            try
            {
                var result = await _wrapper.SaleReturnDetail.UpdateSaleReturnDetail(saleReturnDetailId, model);

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
		[Route("{saleReturnDetailId}/saleReturnDetailId")]
        public async Task<IHttpActionResult> Delete(int saleReturnDetailId)
        {
            try
            {
                var result = await _wrapper.SaleReturnDetail.DeleteSaleReturnDetail(saleReturnDetailId);

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


     
