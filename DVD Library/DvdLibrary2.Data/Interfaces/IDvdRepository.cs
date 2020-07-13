using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary2.Data.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> ReadAllDvd();
        Dvd ReadDvdById(int DvdId);
        List<Dvd> ReadDvdByTitle(string Title);
        List<Dvd> ReadDvdByReleaseYear(string ReleaseYear);
        List<Dvd> ReadDvdByDirector(string Director);
        List<Dvd> ReadDvdByRating(string Rating);
        void CreateDvd(Dvd dvd);
        void UpdateDvd(Dvd dvd);
        void DeleteDvd(Dvd dvd);
    }
}
