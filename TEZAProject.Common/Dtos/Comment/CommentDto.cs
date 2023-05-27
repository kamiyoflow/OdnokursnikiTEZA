using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Common.Dtos.Comment
{
     public class CommentDto
     {
          public int Id { get; set; }
          public string Author { get; set; }
          public int UserProfileId { get; set; }
          public string Text { get; set; }
          public DateTime Created { get; set; }
     }
}
