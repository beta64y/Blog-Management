using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Repository.Common;
using Blog_Management.Database.Models.Users;

namespace Blog_Management.Database.Repository
{
    internal class ChirpRepository : Repository<Chirp, string>
    {
        public static void Append(User user, string title,string text)
        {
            string id;
            while (true)
            {
                Random random = new Random();
                id = Convert.ToString(random.Next(0, 100000));
                for (int i = 0; i < 6 - id.Length; i++)
                {
                    id = "0" + id;
                }
                id = "BL" + id;
                if (GetById(id) == null)
                {
                     break;
                }
            }
            Chirp chirp = new Chirp(title ,text,user,id);
            Add(chirp);
            user.Chirps.Add(chirp);
        }
        public static void Remove(Chirp chirp)
        {
            chirp.User.Chirps.Remove(chirp);
            Delete(chirp);
            foreach(Comment comment in CommentRepository.GetChirpComments(chirp))
            {
                comment.User.Comments.Remove(comment);
            }
        }
        public static List<Chirp> GetChirpsByTitle(string title)
        {
            List<Chirp> chirpList = new List<Chirp>();
            foreach(Chirp chirp in DbContext)
            {
                if(chirp.Title == title)
                {
                    chirpList.Add(chirp);
                }
            }
            return chirpList;

        }
        public static List<Chirp> GetChirpsByFirstName(string name)
        {
            List<Chirp> chirpList = new List<Chirp>();
            foreach (Chirp chirp in DbContext)
            {
                if (chirp.User.FirstName == name)
                {
                    chirpList.Add(chirp);
                }
            }
            return chirpList;

        }

    }
}
