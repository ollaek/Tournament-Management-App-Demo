using BL.Enums;
using BL.Helpers;
using BL.ViewModels;
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
        private readonly IGameBussinesManager gameBussinesManager; 
       
        public TournamentsController(ITournamentBussinesManager _tournamentBussinesManager,
            IGameBussinesManager _gameBussinesManager)
        {
            tournamentBussinesManager = _tournamentBussinesManager;
            gameBussinesManager = _gameBussinesManager;
        }

        [Route("api/Tournaments/GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var tournaments = tournamentBussinesManager.GetAll().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, 
                    new CustomResponse<Tournament>()
                            {
                                ResponseCode = (int)ResponseCodeEnum.Success,
                                ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                                ReturnObjectList = tournaments
                            });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Tournament>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }

        [Route("api/Tournaments/GetAllByGameId")]
        [HttpGet]
        public HttpResponseMessage GetAllByGameId(int id)
        {
            try
            {
                var tournaments = tournamentBussinesManager.GetAll().Where(x => x.GameId == id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Success,
                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                      ReturnObjectList = tournaments
                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Error,
                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                  });
            }
        }

        [Route("api/Tournaments/GetById")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var tournament = tournamentBussinesManager.Get(id);
                tournament.Game = gameBussinesManager.Get(tournament.GameId);
                return Request.CreateResponse(HttpStatusCode.OK,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Success,
                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                      ReturnObject = tournament
                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Error,
                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                  });
            }
        }

        [Route("api/Tournaments/GetByTag")]
        [HttpGet]
        public HttpResponseMessage GetByTag(string tag)
        {
            try
            {
                var tournament = tournamentBussinesManager.GetAll().Where(x=>x.Tag == tag).FirstOrDefault();
                tournament.Game = gameBussinesManager.Get(tournament.GameId);
                return Request.CreateResponse(HttpStatusCode.OK,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Success,
                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                      ReturnObject = tournament
                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                  new CustomResponse<Tournament>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Error,
                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                  });
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
                return Request.CreateResponse(HttpStatusCode.OK,
                                  new CustomResponse<Tournament>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Success,
                                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                                      ReturnObject = tournament
                                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Tournament>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }

        [Route("api/Tournaments/Delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var tournament = tournamentBussinesManager.Get(id);
                tournamentBussinesManager.Remove(tournament);
                return Request.CreateResponse(HttpStatusCode.OK,
                                  new CustomResponse<Tournament>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Success,
                                      ResponseMessage = ResponseCodeEnum.Success.GetDescription()
                                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Tournament>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }
    }
}
