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
    public class TournamentBussinesManager<TRepository> : BaseBussinesManager<Tournament, TRepository>,
            ITournamentBussinesManager where TRepository : ITournamentRepository
    {
        public TournamentBussinesManager(IUnitOfWork _uow, IRepository<Tournament> _repository) : base(_uow, _repository)
        {
        }
    }
}
