using DvdLibrary2.Data;
using DvdLibrary2.Data.Interfaces;
using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DvdLibrary2.UI.Controllers
{
    public class DvdController : ApiController
    {
        IDvdRepository Repo = DvdRepositoryFactory.ChooseRepo();
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(Repo.ReadAllDvd());
        }

        [Route("dvd/{DvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int DvdId)
        {
            Dvd dvd = Repo.ReadDvdById(DvdId);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTitle(string title)
        {
            List<Dvd> dvd = Repo.ReadDvdByTitle(title);
         
            foreach (Dvd currentDvd in dvd)
            {
                if (currentDvd == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dvd);
                }
            }
            return NotFound();

        }

        [Route("dvd/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetYear(string releaseYear)
        {
            List<Dvd> dvd = Repo.ReadDvdByReleaseYear(releaseYear);

            foreach (Dvd currentDvd in dvd)
            {
                if (currentDvd == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dvd);
                }
            }
            return NotFound();

        }

        [Route("dvd/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDirector(string directorName)
        {
            List<Dvd> dvd = Repo.ReadDvdByDirector(directorName);

            foreach (Dvd currentDvd in dvd)
            {
                if (currentDvd == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dvd);
                }
            }
            return NotFound();

        }

        [Route("dvd/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetRating(string rating)
        {
            List<Dvd> dvd = Repo.ReadDvdByRating(rating);

            foreach (Dvd currentDvd in dvd)
            {
                if (currentDvd == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dvd);
                }
            }
            return NotFound();

        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = new Dvd()
            {
                Title = request.Title,
                ReleaseYear = request.ReleaseYear,
                Director = request.Director,
                Rating = request.Rating,
                Notes = request.Notes

            };

            Repo.CreateDvd(dvd);
            return Created($"dvd/get/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{DvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(int DvdId, Dvd request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = Repo.ReadDvdById(DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Director = request.Director;
            dvd.Rating = request.Rating;
            dvd.Notes = request.Notes;

            Repo.UpdateDvd(dvd);
            return Ok(dvd);
        }

        [Route("dvd/{DvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            Dvd dvd = Repo.ReadDvdById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            Repo.DeleteDvd(dvd);
            return Ok();
        }
    }
}