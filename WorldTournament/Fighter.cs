using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTournament
{
    public class Fighter : IFighter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public int PunchScore { get; set; }
    }
}
