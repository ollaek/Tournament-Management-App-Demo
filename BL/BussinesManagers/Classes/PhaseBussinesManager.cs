﻿using BL.BussinesManagers.Interfaces;
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
    public class phaseBussinesManager<TRepository> : BaseBussinesManager<Phase, TRepository>,
         IPhaseBussinesManager where TRepository : IPhaseRepository
    {
        public phaseBussinesManager(IUnitOfWork _uow) : base(_uow)
        {
        }
    }
}
