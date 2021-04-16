using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr_server.Models;
using keepr_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr_server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _service;
        private readonly KeepsService _keepserv;

        public VaultsController(VaultsService service, KeepsService keepserv)
        {
            _service = service;
            _keepserv = keepserv;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
        public ActionResult<Vault> Get(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        // NOTE ANYTIME you need to use Async/Await you will return a Task
        public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
        {
            try
            {
                // NOTE HttpContext == 'req'
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newVault.CreatorId = userInfo.Id;
                newVault.Creator = userInfo;
                return Ok(_service.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Edit([FromBody] Vault updated, int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                //NOTE attach creatorId so you can validate they are the creator of the original
                updated.CreatorId = userInfo.Id;
                updated.Creator = userInfo;
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Vault>> Delete(int id)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                //NOTE send userinfo.id so you can validate they are the creator of the original

                return Ok(_service.Delete(id, userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // //api/vaults/4/keeps

        // [HttpGet("{id}/keeps")]  // NOTE '{}' signifies a var parameter
        // public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepsByVaultId(int id)
        // {
        //     try
        //     {
        //         return Ok(_keepserv.GetKeepsByVaultId(id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

    }
}