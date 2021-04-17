using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {

        private readonly VaultKeepsService _vkserv;
        private readonly KeepsService _keepserv;

        public VaultKeepsController(VaultKeepsService vkserv, KeepsService keepserv)
        {
            _vkserv = vkserv;
            _keepserv = keepserv;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> CreateAsync([FromBody] VaultKeep newVK)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newVK.CreatorId = userInfo.Id;
                return Ok(_vkserv.Create(newVK));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }



        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _vkserv.Delete(id);
                return Ok("deleted");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}