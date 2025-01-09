using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        //list of all
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage Get()
        {
            var data = NewsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //createing news
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO news)
        {
            NewsService.Create(news);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //update news
        [HttpPut]
        [Route("api/news/update")]
        public HttpResponseMessage Update(NewsDTO news)
        {
            try
            {
                NewsService.Update(news);
                return Request.CreateResponse(HttpStatusCode.OK, "News updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //delete
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                NewsService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "News deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // Search news by title
        [HttpGet]
        [Route("api/news/search")]
        public HttpResponseMessage Search(string title)
        {
            try
            {
                var data = NewsService.SearchByTitle(title);
                if (data == null || data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No news found with the given title.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // Search news by category
        [HttpGet]
        [Route("api/news/searchByCategory")]
        public HttpResponseMessage SearchByCategory(string category)
        {
            try
            {
                var data = NewsService.SearchByCategory(category);
                if (data == null || data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No news found in the given category.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        // Search news by date
        [HttpGet]
        [Route("api/news/searchByDate")]
        public HttpResponseMessage SearchByDate(DateTime date)
        {
            try
            {
                var data = NewsService.SearchByDate(date);
                if (data == null || data.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No news found for the given date.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        // Search news by both date and category
        [HttpGet]
        [Route("api/news/searchByDateAndCategory")]
        public HttpResponseMessage SearchByDateAndCategory(DateTime date, string category)
        {
            try
            {
                var data = NewsService.SearchByDateAndCategory(date, category);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        //date and title
        [HttpGet]
        [Route("api/news/searchByDateAndTitle")]
        public HttpResponseMessage SearchByDateAndTitle(DateTime date, string title)
        {
            try
            {
                var data = NewsService.SearchByDateAndTitle(date, title);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }





    }
}
