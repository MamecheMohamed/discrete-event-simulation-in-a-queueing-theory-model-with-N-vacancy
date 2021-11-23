

using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class Departur : Event
    {

        public static  void PDeparture()
        {
            Simulation.cpt--;
            //Simulation.server.state = Simulation.idle;
            Simulation.pakserv++;
            switch (Start_service.data.priorite)
            {
                case 0:
                    Simulation.Response_TimeLow += (Simulation.T_now - Start_service.data.arrival_time);
                    Simulation.Waiting_TimeLow += (Start_service.data.start_servie_time - Start_service.data.arrival_time);
                    Simulation.packet_servedLow++;
                    break;
                case 1:
                    Simulation.Response_TimeMed += (Simulation.T_now - Start_service.data.arrival_time);
                    Simulation.Waiting_TimeMed += (Start_service.data.start_servie_time - Start_service.data.arrival_time);
                    Simulation.packet_servedMed++;

                    break;
                case 2:
                    Simulation.Response_TimeHigh += (Simulation.T_now - Start_service.data.arrival_time);
                    Simulation.Waiting_TimeHigh += (Start_service.data.start_servie_time - Start_service.data.arrival_time);
                    Simulation.packet_servedHigh++;

                    break;
            }
            if (Simulation.cpt > 0)  {

                Start_service s1 = new Start_service();
                
                      s1.time = Simulation.T_now;
                      s1.type = 1;
                      Simulation.FEL.E.Add(s1.time, s1);    
            }
            else 
            {
                Simulation.server.state = Simulation.vacn;
              
                Simulation.vacancy_start_time = Simulation.T_now;
                Simulation.cpt_vac++;

            }
        }
        }
}
