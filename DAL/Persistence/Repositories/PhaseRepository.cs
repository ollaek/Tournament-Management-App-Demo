﻿using DAL.Core.Domain;
using DAL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repositories
{
    public class PhaseRepository : Repository<Phase>, IPhaseRepository
    {
        public PhaseRepository(My_DBContext context) : base(context)
        {
        }

        public My_DBContext My_DBContext
        {
            get { return Context as My_DBContext; }
        }
    }

}
