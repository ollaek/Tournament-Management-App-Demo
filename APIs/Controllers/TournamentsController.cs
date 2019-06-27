using APIs.Enums;
using APIs.Helpers;
using APIs.ViewModels;
using BL.BussinesManagers.Interfaces;
using DAL.Core.Domain;
//using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

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
        public string GetAll()
        {
            try
            {
                var result = tournamentBussinesManager.GetAll().ToList();

                return ResponseCodeEnum.Success.GetDescription();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("api/Tournaments/GetById")]
        [HttpGet]
        public Tournament GetById(int id)
        {
            try
            {
                var result = tournamentBussinesManager.Get(id);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("api/Tournaments/Save")]
        [ResponseType(typeof(CustomResponse<Tournament>))]
        [HttpPost]
        public HttpResponseMessage Save(Tournament tournament)
        {
            try
            {
                tournamentBussinesManager.Add(tournament);
                //tournamentBussinesManager.AddInMemory(tournament);
                //tournamentBussinesManager.UnitOfWork.Complete();
                return Request.CreateResponse(HttpStatusCode.OK, new CustomResponse<Tournament>() { ResponseCode = (int)ResponseCodeEnum.Success ,ResponseMessage = ResponseCodeEnum.Success.GetDescription() ,ReturnObject = tournament });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new CustomResponse<Tournament>() { ResponseCode = (int)ResponseCodeEnum.Error, ResponseMessage = ResponseCodeEnum.Error.GetDescription(), ReturnObject = null });
            }
        }

        [Route("api/Tournaments/Delete")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = tournamentBussinesManager.Get(id);
                tournamentBussinesManager.Remove(result);
                return Ok("deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
