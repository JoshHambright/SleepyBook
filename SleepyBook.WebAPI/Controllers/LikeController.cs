using Microsoft.AspNet.Identity;
using SleepyBook.Models;
using SleepyBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SleepyBook.WebAPI.Controllers
{
    public class LikeController : ApiController
    {
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);


            var service = CreateLikeService();

            if (!service.CreateLike(like))

                return InternalServerError();


            return Ok();
        }
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }
    }
}
