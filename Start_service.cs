using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DESQT
{
    class Start_service : Event
    {
        public static Packet data;
        public static void PStart_Service(Boolean preemp,String chose)
        {
            if (preemp == false)
            {
                Simulation.server.state = Simulation.busy;

                if (Simulation.is_System_saturated == 1)
                {
                    Simulation.is_System_saturated = 0;
                    Simulation.System_saturated_time += (Simulation.T_now - Simulation.System_saturated_start_time);

                }
                data = (Packet)Simulation.PQ.P.Dequeue();

                data.start_servie_time = Simulation.T_now;
                switch (chose)
                {
                    case "M":
                        Departur s2 = new Departur();
                        float a2;
                        do
                        {
                            a2 = Simulation.T_now + Simulation.dist.Exponontiel(data.service_time);
                        }
                        while (Simulation.FEL.E.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 2;
                        Simulation.FEL.E.Add(s2.time, s2);
                        break;
                    case "G":
                        Departur s1 = new Departur();
                        float a;
                        do
                        {
                            a = (float)(Simulation.T_now + Simulation.dist.GE(data.service_time, Simulation.sigma));
                        }
                        while (Simulation.FEL.E.ContainsKey(a));
                        s1.time = a;
                        s1.type = 2;
                        Simulation.FEL.E.Add(s1.time, s1);
                        break;
                    case "D":
                        Departur s3 = new Departur();
                        float a3;
                        do
                        {
                            a3 = Simulation.T_now + data.service_time;
                        }
                        while (Simulation.FEL.E.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 2;
                        Simulation.FEL.E.Add(s3.time, s3);
                        break;
                    default:
                        break;

                }
            }
            //************************************************************************************
            else
            {
                Simulation.server.state = Simulation.busy;

                if (Simulation.is_System_saturated == 1)
                {
                    Simulation.is_System_saturated = 0;
                    Simulation.System_saturated_time += (Simulation.T_now - Simulation.System_saturated_start_time);

                }
                Event e = Simulation.FEL.E.Last().Value;
                if (e.type == Simulation.arrivaleHIGH)
                {
                    data = (Packet)Simulation.PQ.P.Dequeue();
                    data = ArrivalHIGH.c;
                    Simulation.packet_rejected++;
                }
                else
                {
                    data = (Packet)Simulation.PQ.P.Dequeue();
                }
                data.start_servie_time = Simulation.T_now;
                switch (chose)
                {
                    case "M":
                        Departur s2 = new Departur();
                        float a2;
                        do
                        {
                            a2 = Simulation.T_now + Simulation.dist.Exponontiel(data.service_time);
                        }
                        while (Simulation.FEL.E.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 2;
                        Simulation.FEL.E.Add(s2.time, s2);
                        break;
                    case "G":
                        Departur s1 = new Departur();
                        float a;
                        do
                        {
                            a = (float)(Simulation.T_now + Simulation.dist.GENRAL(data.service_time, Simulation.sigma));
                        }
                        while (Simulation.FEL.E.ContainsKey(a));
                        s1.time = a;
                        s1.type = 2;
                        Simulation.FEL.E.Add(s1.time, s1);
                        break;
                    case "D":
                        Departur s3 = new Departur();
                        float a3;
                        do
                        {
                            a3 = Simulation.T_now + data.service_time;
                        }
                        while (Simulation.FEL.E.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 2;
                        Simulation.FEL.E.Add(s3.time, s3);
                        break;

                }


            }



        }
    }
}