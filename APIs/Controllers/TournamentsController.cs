using BL.BussinesManagers.Interfaces;
using DAL.Core.Domain;
//using Ninject;
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
       
        public TournamentsController(ITournamentBussinesManager _tournamentBussinesManager)
        {
            tournamentBussinesManager = _tournamentBussinesManager;
        }

        [Route("api/Tournaments/GetAll")]
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
        [Route("api/Tournaments/Save")]
        [HttpPost]
        public IHttpActionResult SaveTournament(Tournament tournament)
        {
            try
            {
                tournamentBussinesManager.Add(tournament);
                //tournamentBussinesManager.AddInMemory(tournament);
                //tournamentBussinesManager.UnitOfWork.Complete();

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
