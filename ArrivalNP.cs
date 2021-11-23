
using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class ArrivalNP : Event
    {
        public static void PArrivalNP(String chose, Boolean finite, float ma, float ms)
        {
            if (finite == true)
            {

                if (!SimulationNP.PQ.IsfullNP())
                {
                    SimulationNP.cpt++;
                    Packet c = new Packet();
                    //c.priorite = 0;
                    c.lambda = ma;
                    c.arrival_time = SimulationNP.T_now;
                    c.start_servie_time = 0;
                    c.service_time = ms;
                    SimulationNP.PQ.P2.Enqueue(c);

                    if ((SimulationNP.server.state == SimulationNP.vacn) && ((SimulationNP.cpt >= SimulationNP.v1.n)))
                    {
                        SimulationNP.cpt_actif++;
                        SimulationNP.cycle_nbr++;
                        SimulationNP.cycle_duration += (SimulationNP.T_now - SimulationNP.cycle_duration_start);
                        SimulationNP.cycle_duration_start = SimulationNP.T_now;
                        SimulationNP.server.state = SimulationNP.idle;

                        SimulationNP.vacancy_time += (SimulationNP.T_now - SimulationNP.vacancy_start_time);


                    }


                    if (SimulationNP.server.state == SimulationNP.idle)
                    {

                        Start_serviceNP s = new Start_serviceNP();
                        s.time = SimulationNP.T_now;
                        s.type = 1;
                        SimulationNP.FEL.E2.Add(s.time, s);



                    }
                }
                else
                {
                    SimulationNP.packet_rejected++;
                    if (SimulationNP.is_System_saturated == 0)
                    {
                        SimulationNP.is_System_saturated = 1;
                        SimulationNP.System_saturated_start_time = SimulationNP.T_now;
                    }

                }

                switch (chose)
                {
                    case "M":
                        ArrivalNP s2 = new ArrivalNP();
                        float a2;
                        do
                        {
                            a2 = SimulationNP.T_now + SimulationNP.dist.Exponontiel(ma);
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 0;
                        SimulationNP.FEL.E2.Add(s2.time, s2);
                        break;
                    case "G":
                        ArrivalNP s1 = new ArrivalNP();
                        float a;
                        do
                        {
                            a = (float)(SimulationNP.T_now + SimulationNP.dist.GE(ma, SimulationNP.sigma));
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a));
                        s1.time = a;
                        s1.type = 0;
                        SimulationNP.FEL.E2.Add(s1.time, s1);
                        break;
                    case "D":
                        ArrivalNP s3 = new ArrivalNP();
                        float a3;
                        do
                        {
                            a3 = SimulationNP.T_now + ma;
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 0;
                        SimulationNP.FEL.E2.Add(s3.time, s3);
                        break;
                    default:
                        break;

                }






            }
            else
            {
                SimulationNP.cpt++;
                Packet c = new Packet();
               // c.priorite = 0;
                c.lambda = ma;
                c.arrival_time = SimulationNP.T_now;
                c.start_servie_time = 0;
                c.service_time = ms;
                SimulationNP.PQ.P2.Enqueue(c);
                if ((SimulationNP.server.state == SimulationNP.vacn) && ((SimulationNP.cpt >= SimulationNP.v1.n)))
                {
                    SimulationNP.cpt_actif++;
                    SimulationNP.cycle_nbr++;
                    SimulationNP.cycle_duration += (SimulationNP.T_now - SimulationNP.cycle_duration_start);
                    SimulationNP.cycle_duration_start = SimulationNP.T_now;
                    SimulationNP.server.state = SimulationNP.idle;

                    SimulationNP.vacancy_time += (SimulationNP.T_now - SimulationNP.vacancy_start_time);
                }


                if (SimulationNP.server.state == SimulationNP.idle)
                {

                    Start_serviceNP s = new Start_serviceNP();
                    s.time = SimulationNP.T_now;
                    s.type = 1;
                    SimulationNP.FEL.E2.Add(s.time, s);



                }

                switch (chose)
                {
                    case "M":
                        ArrivalNP s2 = new ArrivalNP();
                        float a2;
                        do
                        {
                            a2 = SimulationNP.T_now + SimulationNP.dist.Exponontiel(ma);
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 0;
                        SimulationNP.FEL.E2.Add(s2.time, s2);
                        break;
                    case "G":
                        ArrivalNP s1 = new ArrivalNP();
                        float a;
                        do
                        {
                            a = (float)(SimulationNP.T_now + SimulationNP.dist.GENRAL(ma, SimulationNP.sigma));
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a));
                        s1.time = a;
                        s1.type = 0;
                        SimulationNP.FEL.E2.Add(s1.time, s1);
                        break;
                    case "D":
                        ArrivalNP s3 = new ArrivalNP();
                        float a3;
                        do
                        {
                            a3 = SimulationNP.T_now + ma;
                        }
                        while (SimulationNP.FEL.E2.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 0;
                        SimulationNP.FEL.E2.Add(s3.time, s3);
                        break;


                }
            }



        }
    }
}