using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Domain
{
     public class Comment : BaseEntity
     {
          public string Author { get; set; }
          public UserProfile UserProfile { get; set; }
          public int UserProfileId { get; set; }
          public string Text { get; set; }
          public DateTime Created { get; set; }
          public Post Post { get; set; }
          public int PostId { get; set; }
     }
}
