using DvdLibrary2.Data.Interfaces;
using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary2.Data.EF
{
    public class DvdRepositoryEntity : IDvdRepository
    {
        private DvdContext dvdContext;
        public DvdRepositoryEntity()
        {
            dvdContext = new DvdContext();
        }
        public void CreateDvd(Dvd dvd)
        {
            dvdContext.Dvds.Add(dvd);
            dvdContext.SaveChanges();
        }

        public void DeleteDvd(Dvd dvd)
        {
            dvdContext.Dvds.Remove(dvd);
            dvdContext.SaveChanges();
        }

        public List<Dvd> ReadAllDvd()
        {
            return dvdContext.Dvds.ToList();
        }

        public List<Dvd> ReadDvdByDirector(string Director)
        {
            return dvdContext.Dvds.Where(a => a.Director == Director).ToList();
        }

        public Dvd ReadDvdById(int DvdId)
        {
            return dvdContext.Dvds.Where(a => a.DvdId == DvdId).FirstOrDefault();
        }

        public List<Dvd> ReadDvdByRating(string Rating)
        {
            return dvdContext.Dvds.Where(a => a.Rating == Rating).ToList();
        }

        public List<Dvd> ReadDvdByReleaseYear(string ReleaseYear)
        {
            return dvdContext.Dvds.Where(a => a.ReleaseYear == ReleaseYear).ToList();
        }

        public List<Dvd> ReadDvdByTitle(string Title)
        {
            return dvdContext.Dvds.Where(a => a.Title == Title).ToList();
        }

        public void UpdateDvd(Dvd dvd)
        {
            dvdContext.Entry(dvd).State = EntityState.Modified;
            dvdContext.SaveChanges();
        }
    }
}
