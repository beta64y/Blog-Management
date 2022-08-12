using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Management.Database.Models.Shares;
using Blog_Management.Database.Repository.Common;
using Blog_Management.Database.Models.Users;
using Blog_Management.Database.Enums;

namespace Blog_Management.Database.Repository
{
    internal class ChirpRepository : Repository<Chirp, string>
    {
        static ChirpRepository()
        {
            User user = UserRepository.GetById(1);
            User user1 = UserRepository.GetById(2);
            User user2 = UserRepository.GetById(3);

            Append(user, "SalamSalam", "Salamsalamsalam");
            Append(user1, "Məşhur aktyor dünyasını dəyişdi", "Türkiyəli aktyor Semih Sergen vəfat edib.");
            Append(user2, "Yalan Xeber", "Ordumuzun bölmələri tərəfindən Azərbaycan-Ermənistan dövlət sərhədində guya atəş açılması və nəticədə Ermənistan silahlı qüvvələrinin hərbiqulluqçusunun yaralanması barədə Ermənistan Müdafiə Nazirliyinin yaydığıməlumat yalandır.");
            DbContext[0].BlogStatus = BlogStatus.Accepted;
            DbContext[2].BlogStatus = BlogStatus.Accepted;
            DbContext[3].BlogStatus = BlogStatus.Accepted;
        }

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
                
                CommentRepository.Remove(comment);
            }
        }
        public static List<Chirp> GetChirpsByTitle(string title)
        {
            List<Chirp> chirpList = new List<Chirp>();
            foreach(Chirp chirp in DbContext)
            {
                if(chirp.Title == title && chirp.BlogStatus == BlogStatus.Accepted)
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
                if (chirp.User.FirstName == name && chirp.BlogStatus == BlogStatus.Accepted)
                {
                    chirpList.Add(chirp);
                }
            }
            return chirpList;

        }

    }
}
