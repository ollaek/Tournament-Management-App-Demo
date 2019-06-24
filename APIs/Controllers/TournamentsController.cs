using BL.BussinesManagers.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIs.Controllers
{
    public class TournamentsController : ApiController
    {
        private readonly ITournamentBussinesManager tournamentBussinesManager;
        [Inject]
        public TournamentsController(ITournamentBussinesManager _tournamentBussinesManager)
        {
            tournamentBussinesManager = _tournamentBussinesManager;
        }
        public TournamentsController()
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllTournaments()
        {
            try
            {
                var result = tournamentBussinesManager.GetAll().ToList();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
