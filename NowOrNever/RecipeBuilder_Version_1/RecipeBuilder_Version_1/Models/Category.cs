using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int ForumID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}