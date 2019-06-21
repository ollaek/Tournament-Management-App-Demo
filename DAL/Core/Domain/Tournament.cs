using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core.Domain
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Index(IsUnique = true)]
        public string Tag { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }
        public bool IsSiglePlayer { get; set; }
        public int MaxPlayersPerTour { get; set; }
        public int MaxTeamsPerTour { get; set; }
        public int PlayersPerTeam { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}
