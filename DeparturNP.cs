

using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class DeparturNP : Event
    {

        public static void PDepartureNP()
        {
            SimulationNP.cpt--;
            SimulationNP.server.state = SimulationNP.idle;
            SimulationNP.Response_Time += (SimulationNP.T_now - Start_serviceNP.data.arrival_time);
            SimulationNP.Waiting_Time += (Start_serviceNP.data.start_servie_time - Start_serviceNP.data.arrival_time);
            SimulationNP.packet_served++;
              
            if (SimulationNP.cpt > 0)
            {

                Start_serviceNP s1 = new Start_serviceNP();

                s1.time = SimulationNP.T_now;
                s1.type = 1;
                SimulationNP.FEL.E2.Add(s1.time, s1);
            }
            else
            {
                SimulationNP.server.state = SimulationNP.vacn;

                SimulationNP.vacancy_start_time = SimulationNP.T_now;
                SimulationNP.cpt_vac++;

            }
        }
    }
}
