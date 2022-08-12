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
            ChirpRepository.Seed();    
        }
        public static void Seed()
        {
            User user = UserRepository.GetById(1);
            User user1 = UserRepository.GetById(2);
            User user2 = UserRepository.GetById(3);
            ChirpRepository.GetAll().Add(new Chirp("SalamSalam", "Salamsalamsalam", user, "BL00001", ChirpStatus.Accepted));
            ChirpRepository.GetAll().Add(new Chirp("Məşhur aktyor dünyasını dəyişdi", "Türkiyəli aktyor Semih Sergen vəfat edib.", user1, "BL00002", ChirpStatus.Accepted));
            ChirpRepository.GetAll().Add(new Chirp("Yalan Xeber", "Ordumuzun bölmələri tərəfindən Azərbaycan-Ermənistan dövlət sərhədində guya atəş açılması və nəticədə Ermənistan silahlı qüvvələrinin hərbiqulluqçusunun yaralanması barədə Ermənistan Müdafiə Nazirliyinin yaydığıməlumat yalandır.", user2, "BL00003", ChirpStatus.Accepted));

        }
       
        public static void Remove(Chirp chirp)
        {
            Delete(chirp);
            foreach(Comment comment in CommentRepository.GetCommentsByChirp(chirp))
            {
                
                CommentRepository.Remove(comment);
            }
        }
        public static List<Chirp> GetChirpsByTitle(string title)
        {
            List<Chirp> chirpList = new List<Chirp>();
            foreach(Chirp chirp in ChirpRepository.GetAll())
            {
                if(chirp.Title == title && chirp.BlogStatus == ChirpStatus.Accepted)
                {
                    chirpList.Add(chirp);
                }
            }
            return chirpList;

        }
        public static List<Chirp> GetChirpsByFirstName(string name)
        {
            List<Chirp> chirpList = new List<Chirp>();
            foreach (Chirp chirp in ChirpRepository.GetAll())
            {
                if (chirp.User.FirstName == name && chirp.BlogStatus == ChirpStatus.Accepted)
                {
                    chirpList.Add(chirp);
                }
            }
            return chirpList;

        }
        

    }
}
