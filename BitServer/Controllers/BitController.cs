﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BitServerBL.Models;

namespace BitServer.Controllers
{
    [Route("BitAPI")]
    [ApiController]
    public class BitController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        BitDBContext context;
        public BitController(BitDBContext context)
        {
            this.context = context;
        }
        #endregion
        [Route("Test")]
        [HttpGet]
        [HttpGet]
        public string Test()
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return context.Test();
        }
        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string email, [FromQuery] string pass)
        {
            User user = context.Login(email, pass);

            //Check user name and password
            if (user != null)
            {
                HttpContext.Session.SetObject("theUser", user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return user;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

    }

}
