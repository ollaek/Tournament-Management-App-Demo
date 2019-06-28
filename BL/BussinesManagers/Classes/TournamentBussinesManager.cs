using BL.BussinesManagers.Interfaces;
using BL.Helpers;
using BL.Validators;
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
        public TournamentBussinesManager(IUnitOfWork _uow) : base(_uow)
        {
        }

        public new void Add(Tournament tournament)
        {
            GeneralValidator Validator = new GeneralValidator(this); 
            tournament.Tag = Validator.ValidateTag(6);
            tournament.CreationDate = DateTime.Now;
            Repository.Add(tournament);
            UnitOfWork.Complete();
        }


    }
}
