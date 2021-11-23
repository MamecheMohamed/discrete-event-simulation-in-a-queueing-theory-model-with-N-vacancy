using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class Start_serviceNP : Event
    {
        public static Packet data;
        public static void PStart_ServiceNP(String chose)
        {
            SimulationNP.server.state = SimulationNP.busy;

            if (SimulationNP.is_System_saturated == 1)
            {
                SimulationNP.is_System_saturated = 0;
                SimulationNP.System_saturated_time += (SimulationNP.T_now - SimulationNP.System_saturated_start_time);

            }
            data = (Packet)SimulationNP.PQ.P2.Dequeue();

            data.start_servie_time = SimulationNP.T_now;
            switch (chose)
            {
                case "M":
                    DeparturNP s2 = new DeparturNP();
                    float a2;
                    do
                    {
                        a2 = SimulationNP.T_now + SimulationNP.dist.Exponontiel(data.service_time);
                    }
                    while (SimulationNP.FEL.E2.ContainsKey(a2));
                    s2.time = a2;
                    s2.type = 2;
                    SimulationNP.FEL.E2.Add(s2.time, s2);
                    break;
                case "G":
                    DeparturNP s1 = new DeparturNP();
                    float a;
                    do
                    {
                        a = (float)(SimulationNP.T_now + SimulationNP.dist.GE(data.service_time, SimulationNP.sigma));
                    }
                    while (SimulationNP.FEL.E2.ContainsKey(a));
                    s1.time = a;
                    s1.type = 2;
                    SimulationNP.FEL.E2.Add(s1.time, s1);
                    break;
                case "D":
                    DeparturNP s3 = new DeparturNP();
                    float a3;
                    do
                    {
                        a3 = SimulationNP.T_now + data.service_time;
                    }
                    while (SimulationNP.FEL.E2.ContainsKey(a3));
                    s3.time = a3;
                    s3.type = 2;
                    SimulationNP.FEL.E2.Add(s3.time, s3);
                    break;
                default:
                    break;

            }



        }
    }
}