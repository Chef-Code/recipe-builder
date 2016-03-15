using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int MemberID { get; set; }
        public int MessageID { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public virtual Member Member { get; set; }
        public virtual Message Message { get; set; }
    }
}