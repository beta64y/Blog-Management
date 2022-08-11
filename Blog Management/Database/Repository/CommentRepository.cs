using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Repository.Common;
using Blog_Management.Database.Models.Shares;

namespace Blog_Management.Database.Repository
{
    internal class CommentRepository : Repository<Comment,int>
    {
      public static void Remove(Comment comment)
        {
            DbContext.Remove(comment);
            comment.User.Comments.Remove(comment);
        }
      public static List<Comment> GetChirpComments(Chirp chirp)
        {
            List<Comment> comments = new List<Comment>();
            foreach(Comment comment in DbContext)
            {
                if(comment.Chirp == chirp)
                {
                    comments.Add(comment);
                }
            }    
            return comments;
        }
    }
}
