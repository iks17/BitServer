using Microsoft.AspNetCore.Http;
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

        [Route("SignUp")]
        [HttpPost]

        public bool SignUp([FromBody] User user)
        {
            bool isSuccess = context.SignUp(user);

            if (isSuccess)//the sign up worked
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return isSuccess;
            }
            else//the sign up failed
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return isSuccess;
            }
        }


        // a function that checks that the inserted email, phone number and user name are unique


        [Route("CheckUniqueness")]
        [HttpGet]

        public bool CheckUniqueness([FromQuery] string email, [FromQuery] string userName)
        {
            bool isUnique = this.context.CheckUniqueness(email, userName);

            if (isUnique)//the email and the user name are unique
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return isUnique;
            }
            else//one or both are not unique
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return isUnique;
            }
        }
        [Route("GetTotalBalance")]
        [HttpGet]
        public double GetTotalBalance()
        {
            User u = HttpContext.Session.GetObject<User>("theUser");
            if(u == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return -1;
            }
            return context.GetTotalBalance(u.UserName);
        }
        //[Route("Get")]
        //[HttpGet]

        //public List<> Gets()
        //{
        //    User u = HttpContext.Session.GetObject<User>("theUser");
        //    if (u != null)
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
        //        return context.Get();
        //    }
        //    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        //    return null;
        //}




    }

}


