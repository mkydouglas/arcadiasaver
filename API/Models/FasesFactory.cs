using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FasesFactory
    {
        public static List<string> CreateFases(FasesOptions fo)
        {
            List<string> fases = new List<string>();

            switch (fo)
            {
                case FasesOptions.ARCADIAQUEST:
                    fases.Add("DISTRICT OF HAMMERS");
                    fases.Add("BRIGHTSUN ARENA");
                    fases.Add("THE MOON GATE");
                    fases.Add("THE ROOKERY");
                    fases.Add("THE MANOR");
                    fases.Add("THE ORCS' HIVE");
                    fases.Add("ALHEMIST'S DISTRICT");
                    fases.Add("THE UNIVERSITY PLAZA");
                    fases.Add("RED DOWN SQUARE");
                    fases.Add("EVERSHADOW DISTRICT");
                    fases.Add("THE TEMPLE OF DAWNING TWILIGHT");
                    return fases;
                case FasesOptions.AQINFERNO:
                    fases.Add("BEYOND THE GATES OF HELL");
                    fases.Add("BARGE OF THE DEAD");
                    fases.Add("LOST IN THE DARK");
                    fases.Add("THE PRISIONER");
                    fases.Add("THE PARADE");
                    fases.Add("THE TAINTED FOUNTAIN");
                    fases.Add("THE DAMNED PONY");
                    fases.Add("HELL'S KITCHEN");
                    fases.Add("MINISTRY OF INFERNAL AFFAIRS");
                    fases.Add("WELL OF TORMENTED SOULS");
                    fases.Add("THE FALLEN TEMPLE");
                    fases.Add("HIT ROCK BOTTOM");
                    return fases;
            }

            return null;
        }
    }
}
