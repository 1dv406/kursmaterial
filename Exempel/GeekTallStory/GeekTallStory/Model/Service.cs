using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GeekTallStory.Model.DAL;

namespace GeekTallStory.Model
{
    public class Service
    {
        public IEnumerable<TallStory> GetTallStories()
        {
            var dal = new TallStoryDAL();
            return dal.GetTallStories();
        }
    }
}