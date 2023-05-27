using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEZAProject.Common.Dtos.Comment;

namespace TEZAProject.Common.Dtos.Post
{
     public class PostDto
     {
          public int Id { get; set; }
          public string Author { get; set; }
          public int UserProfileId { get; set; }
          public string Text { get; set; }
          public DateTime Created { get; set; }
          public ICollection<CommentDto> Comments { get; set; }
     }
}