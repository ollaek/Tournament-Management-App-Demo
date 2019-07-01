using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core.Domain
{
    public class TournamentPhase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        [ForeignKey("Phase")]
        public int PhaseId { get; set; }
        public Phase Phase { get; set; }
        public int PhaseOrder { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("Leg")]
        public int LegId { get; set; }
        public Leg Leg { get; set; }
    }
}
