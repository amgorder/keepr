using System;
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
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _ps;
        private readonly KeepsService _keepserv;
        private readonly VaultsService _vaultserv;

        public AccountController(ProfilesService ps, KeepsService keepserv, VaultsService vaultserv)
        {
            _ps = ps;
            _keepserv = keepserv;
            _vaultserv = vaultserv;
        }

        [HttpGet]

        public async Task<ActionResult<Profile>> Get()
        {
            try
            {

                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("keeps")]
        public async Task<ActionResult<IEnumerable<Keep>>> GetKeepsByAccountId()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_keepserv.GetKeepsByAccountId(userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [HttpGet("vaults")]
        public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByAccountId()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vaultserv.GetVaultsByAccountId(userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}