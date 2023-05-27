using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEZAProject.Common.Dtos.Comment
{
     public class CommentForUpdateDto
     {
          public string Text { get; set; }
          public string Author { get; set; }
          public int UserProfileId { get; set; }
          public int PostId { get; set; }
     }
}
