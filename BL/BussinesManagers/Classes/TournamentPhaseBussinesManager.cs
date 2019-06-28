using BL.BussinesManagers.Interfaces;
using DAL.Core;
using DAL.Core.Domain;
using DAL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BussinesManagers.Classes
{
    class TournamentPhaseBussinesManager<TRepository> : BaseBussinesManager<TournamentPhase, TRepository>,
           ITournamentPhaseBussinesManager where TRepository : ITournamentPhaseRepository
    {
        public TournamentPhaseBussinesManager(IUnitOfWork _uow) : base(_uow)
        {
        }
    }
}
