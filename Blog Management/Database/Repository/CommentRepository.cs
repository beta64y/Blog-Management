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
      public static void Remove(Comment comment)
        {
            CommentRepository.GetAll().Remove(comment);
            
        }
      public static List<Comment> GetCommentsByChirp(Chirp chirp)
        {
            List<Comment> comments = new List<Comment>();
            foreach(Comment comment in CommentRepository.GetAll())
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
