using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTournament
{
    public interface IFighter
    {
        int ID { get;}
        string Name { get;}
        int Height { get;}
        double Weight { get;}
        int PunchScore { get;}

    }
}
