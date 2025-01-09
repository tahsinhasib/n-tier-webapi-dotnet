using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }

        public static List<NewsDTO> Get()
        {
            var repo = new NewsRepo();
            var data = repo.Get();

            var ret = GetMapper().Map<List<NewsDTO>>(data);
            return ret;
        }

        public static void Create(NewsDTO news)
        {
            //convert to EF model

            var ret = GetMapper().Map<News>(news);
            var repo = new NewsRepo();
            repo.Create(ret);
        }


        public static void Update(NewsDTO news)
        {
            // Convert NewsDTO to News (EF model)
            var entity = GetMapper().Map<News>(news);

            // Create an instance of the repository
            var repo = new NewsRepo();

            // Call the repository's Update method
            repo.Update(entity);
        }


        public static void Delete(int id)
        {
            var repo = new NewsRepo();
            repo.Delete(id);
        }



        public static List<NewsDTO> SearchByTitle(string title)
        {
            var repo = new NewsRepo();
            var data = repo.SearchByTitle(title);

            // Convert the result to a list of NewsDTO using AutoMapper
            return GetMapper().Map<List<NewsDTO>>(data);
        }



        public static List<NewsDTO> SearchByCategory(string category)
        {
            var repo = new NewsRepo();
            var data = repo.SearchByCategory(category);

            // Convert the result to a list of NewsDTO using AutoMapper
            return GetMapper().Map<List<NewsDTO>>(data);
        }


        public static List<NewsDTO> SearchByDate(DateTime date)
        {
            var repo = new NewsRepo();
            var data = repo.SearchByDate(date);

            // Convert the result to a list of NewsDTO using AutoMapper
            return GetMapper().Map<List<NewsDTO>>(data);
        }



        public static List<NewsDTO> SearchByDateAndCategory(DateTime date, string category)
        {
            var repo = new NewsRepo();
            var data = repo.SearchByDateAndCategory(date, category);

            // Convert the result to a list of NewsDTO using AutoMapper
            return GetMapper().Map<List<NewsDTO>>(data);
        }



        public static List<NewsDTO> SearchByDateAndTitle(DateTime date, string title)
        {
            var repo = new NewsRepo();
            var data = repo.SearchByDateAndTitle(date, title);

            // Convert the result to a list of NewsDTO using AutoMapper
            return GetMapper().Map<List<NewsDTO>>(data);
        }




    }
}
