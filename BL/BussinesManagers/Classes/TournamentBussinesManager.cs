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
using QR_Code_Service;

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
            GeneralValidator validator = new GeneralValidator(this); 
            var tag = validator.ValidateTag(6);
            QR_Code_Generator generator = new QR_Code_Generator();
            tournament.QRCodePath = generator.Generate_QRCode(tag);
            tournament.Tag = tag;
            tournament.CreationDate = DateTime.Now;
            Repository.Add(tournament);
            UnitOfWork.Complete();
        }


    }
}
