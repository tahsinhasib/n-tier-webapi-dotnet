using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo : Repo
    {

        public News Get(int Id)
        {
            return db.Newses.Find(Id);
        }
        public void Create(News news)
        {
            db.Newses.Add(news);
            db.SaveChanges();
        }

        //public void Update(News news)
        //{
        //    var exobj = Get(news.Id);
        //    db.Entry(exobj).CurrentValues.SetValues(news);
        //    db.SaveChanges();
        //}

        public void Update(News news)
        {
            try
            {
                var exobj = Get(news.Id);
                if (exobj != null)
                {
                    db.Entry(exobj).CurrentValues.SetValues(news);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("News with the given ID does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the news.", ex);
            }
        }


        public List<News> Get()
        {
            return db.Newses.ToList();
        }

        public void Delete(int Id)
        {
            var exobj = Get(Id);
            db.Newses.Remove(exobj);
            db.SaveChanges();
        }


        public List<News> SearchByTitle(string title)
        {
            return db.Newses.Where(n => n.Title.Contains(title)).ToList();
        }


        public List<News> SearchByCategory(string category)
        {
            return db.Newses.Where(n => n.Category == category).ToList();
        }


        //public List<News> SearchByDate(DateTime date)
        //{
        //    return db.Newses.Where(n => n.Date.Date == date.Date).ToList();
        //}


        public List<News> SearchByDate(DateTime date)
        {
            // Use DbFunctions.TruncateTime to strip the time part and only compare the date
            return db.Newses
                     .Where(n => DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date))
                     .ToList();
        }

        public List<News> SearchByDateAndCategory(DateTime date, string category)
        {
            return db.Newses
                     .Where(n => DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date)
                                 && n.Category.Contains(category)) // Adjust this if category is not a string field
                     .ToList();
        }


        public List<News> SearchByDateAndTitle(DateTime date, string title)
        {
            return db.Newses
                     .Where(n => DbFunctions.TruncateTime(n.Date) == DbFunctions.TruncateTime(date)
                                 && n.Title.Contains(title)) // Adjust this if title is not a string field
                     .ToList();
        }



    }
}
