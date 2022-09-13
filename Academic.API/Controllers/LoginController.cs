using Authentication.ViewModel;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using Wrapper;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Footage.API.Controllers
{
    [RoutePrefix("api/v1/login")]
   // [ApiController]
    public class LoginController : ApiController
    {
        private readonly IWrapperRepository _wrapper;
        int myRandomNo = 0;

        public LoginController(IWrapperRepository wrapper
            )
        {
            _wrapper = wrapper;

        }


        [HttpPost]
        [Route("password-reset")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PasswordReset([FromBody] UserLoginVm model)
        {
            try
            {
                var result = await _wrapper.SecurityManager.PasswordRet(model);

                return Ok(new { response = result, success = true });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
            }
            return Ok(new { response = "Record not found", success = false });
        }



        
        //[HttpPost]
        //[Route("forgot-password")]
        //[AllowAnonymous]
        //public async Task<IHttpActionResult> ForgotPassword([FromBody] UserLoginVm model)
        //{
        //    try
        //    {
        //        model.confirmationId = Guid.NewGuid().ToString();
        //        var result = await _wrapper.SecurityManager.ForgotPassword(model);

        //        if (result == "")
        //        {
        //            model.link = model.link + model.confirmationId;
        //            EmailSender email = new EmailSender();
        //            email.SendEmail(model.userName, "Password Reset Link", model.link);

        //            return Ok(new { response = result, success = true });

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { success = false, error = ex.Message, response = "Error has accoured trying to process your request" });
        //    }
        //    return Ok(new { response = "Record not found", success = false });
        //}

        [HttpGet]
        [Route("activities/{roleId}/roleId")]
        public IHttpActionResult GetActivities(int roleId)
        {
            try
            {
                var result =  _wrapper.SecurityManager.GetUserActivites(roleId);

                if (result != null)
                {
                    //claims
                    return Ok(new { response = result, success = true });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { response = false, success = false, message = ex.Message, error = "Error has accoured trying to process your request" });
            }
            return Ok(new { response = "Record not found", success = false });
        }
    }
}
