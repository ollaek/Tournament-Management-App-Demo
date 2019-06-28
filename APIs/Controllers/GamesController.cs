using BL.BussinesManagers.Interfaces;
using BL.Enums;
using BL.Helpers;
using BL.ViewModels;
using DAL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace APIs.Controllers
{
    public class GamesController : ApiController
    {
        private readonly IGameBussinesManager gameBussinesManager;
        public GamesController(IGameBussinesManager _gameBussinesManager)
        {
            gameBussinesManager = _gameBussinesManager;
        }

        [Route("api/Games/GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var games = gameBussinesManager.GetAll().ToList();
                return Request.CreateResponse(HttpStatusCode.OK,
                    new CustomResponse<Game>()
                    {
                        ResponseCode = (int)ResponseCodeEnum.Success,
                        ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                        ReturnObjectList = games
                    });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Game>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }

        [Route("api/Games/GetById")]
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var game = gameBussinesManager.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK,
                  new CustomResponse<Game>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Success,
                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                      ReturnObject = game
                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                  new CustomResponse<Game>()
                  {
                      ResponseCode = (int)ResponseCodeEnum.Error,
                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                  });
            }
        }

        [Route("api/Games/Save")]
        [ResponseType(typeof(CustomResponse<Tournament>))]
        [HttpPost]
        public HttpResponseMessage Save(Game game)
        {
            try
            {
                gameBussinesManager.Add(game);
                return Request.CreateResponse(HttpStatusCode.OK,
                                  new CustomResponse<Game>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Success,
                                      ResponseMessage = ResponseCodeEnum.Success.GetDescription(),
                                      ReturnObject = game
                                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Game>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }

        [Route("api/Games/Delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var game = gameBussinesManager.Get(id);
                gameBussinesManager.Remove(game);
                return Request.CreateResponse(HttpStatusCode.OK,
                                  new CustomResponse<Game>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Success,
                                      ResponseMessage = ResponseCodeEnum.Success.GetDescription()
                                  });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                                  new CustomResponse<Game>()
                                  {
                                      ResponseCode = (int)ResponseCodeEnum.Error,
                                      ResponseMessage = ResponseCodeEnum.Error.GetDescription()
                                  });
            }
        }
    }
}
