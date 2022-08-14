using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Repository.Common;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Models.Users;

namespace Blog_Management.Database.Repository
{
    internal class CommentRepository : Repository<Comment,int>
    {
      public static void Append(User user, string commentText, Chirp chirp)
        {
            Comment comment = new Comment(user, commentText, chirp);
            CommentRepository.DbContext.Add(comment);
        }
      public static void Remove(Comment comment)
        {
            CommentRepository.DbContext.Remove(comment);
            
        }
      public static List<Comment> GetCommentsByChirp(Chirp chirp)
        {
            List<Comment> comments = new List<Comment>();
            foreach(Comment comment in CommentRepository.DbContext)
            {
                if(comment.Chirp == chirp)
                {
                    comments.Add(comment);
                }
            }    
            return comments;
        }
      public static List<Comment> GetCommentsByUser(User user)
        {
            List<Comment> comments = new List<Comment>();
            foreach (Comment comment in CommentRepository.DbContext)
            {
                if (comment.User == user)
                {
                    comments.Add(comment);
                }
            }
            return comments;
        }
         
    }
}
