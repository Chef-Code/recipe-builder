﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeBuilder_Version_1.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int MemberID { get; set; }
        public int TopicID { get; set; }
        public int CategoryID { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual Category Category { get; set; }
        public virtual Member Member { get; set; }
        public virtual Topic Topic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}