using BL.BussinesManagers.Interfaces;
using BL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators
{
    public class GeneralValidator
    {
        private readonly ITournamentBussinesManager tournamentBussinesManager;

        public GeneralValidator(ITournamentBussinesManager _tournamentBussinesManager)
        {
            tournamentBussinesManager = _tournamentBussinesManager;
        }


        public string ValidateTag(int length)
        {
            AutoGenerators generator = new AutoGenerators();
            var tag = generator.GenerateTag(length);
            var existingTag = tournamentBussinesManager.GetAll().Where(x => x.Tag == tag).FirstOrDefault();
            if (existingTag != null)
            {
                ValidateTag(length);
            }

            return tag;

        }
    }
}
