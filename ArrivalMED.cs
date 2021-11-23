
using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class ArrivalMED : Event
    {
        public static void PArrivalMED(String chose, Boolean finite, float ma, float ms, int p)
        {
            if (finite == true)
            {
                if (!Simulation.PQ.Isfull())
                {
                    Simulation.cpt++;
                    Packet c = new Packet();
                    c.priorite = p;
                    c.lambda = ma;
                    c.arrival_time = Simulation.T_now;
                    c.start_servie_time = 0;
                    c.service_time = ms;
                    Simulation.PQ.P.Enqueue(c);

                    if ((Simulation.server.state == Simulation.vacn) && ((Simulation.cpt >= Simulation.v1.n)))
                    {
                        Simulation.cpt_actif++;
                        Simulation.cycle_nbr++;
                        Simulation.cycle_duration += (Simulation.T_now - Simulation.cycle_duration_start);
                        Simulation.cycle_duration_start = Simulation.T_now;
                        // Simulation.server.state = Simulation.idle;
                        Start_service s = new Start_service();
                        s.time = Simulation.T_now;
                        s.type = 1;
                        Simulation.FEL.E.Add(s.time, s);
                        Simulation.vacancy_time += (Simulation.T_now - Simulation.vacancy_start_time);
                    }


                 
                }
                else
                {
                    Simulation.packet_rejected++;
                    if (Simulation.is_System_saturated == 0)
                    {
                        Simulation.is_System_saturated = 1;
                        Simulation.System_saturated_start_time = Simulation.T_now;
                    }

                }
                switch (chose)
                {
                    case "M":
                        ArrivalMED s2 = new ArrivalMED();
                        float a2;
                        do
                        {
                            a2 = Simulation.T_now + Simulation.dist.Exponontiel(ma);
                        }
                        while (Simulation.FEL.E.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 3;
                        Simulation.FEL.E.Add(s2.time, s2);
                        break;
                    case "G":
                        ArrivalMED s1 = new ArrivalMED();
                        float a;
                        do
                        {
                            a =(float)( Simulation.T_now + Simulation.dist.GE(ma, Simulation.sigma));
                        }
                        while (Simulation.FEL.E.ContainsKey(a));
                        s1.time = a;
                        s1.type = 3;
                        Simulation.FEL.E.Add(s1.time, s1);
                        break;
                    case "D":
                        ArrivalMED s3 = new ArrivalMED();
                        float a3;
                        do
                        {
                            a3 = Simulation.T_now + ma;
                        }
                        while (Simulation.FEL.E.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 3;
                        Simulation.FEL.E.Add(s3.time, s3);
                        break;
                    default:
                        break;

                }






            }
            else
            {
                Simulation.cpt++;
                Packet c = new Packet();
                c.priorite = p;
                c.lambda = ma;
                c.arrival_time = Simulation.T_now;
                c.start_servie_time = 0;
                c.service_time = ms;
                Simulation.PQ.P.Enqueue(c);
                if ((Simulation.server.state == Simulation.vacn) && ((Simulation.cpt >= Simulation.v1.n)))
                {
                    Simulation.cpt_actif++;
                    Simulation.cycle_nbr++;
                    Simulation.cycle_duration += (Simulation.T_now - Simulation.cycle_duration_start);
                    Simulation.cycle_duration_start = Simulation.T_now;
                    Simulation.server.state = Simulation.idle;

                    Simulation.vacancy_time += (Simulation.T_now - Simulation.vacancy_start_time);
                }


                if (Simulation.server.state == Simulation.idle)
                {

                    Start_service s = new Start_service();
                    s.time = Simulation.T_now;
                    s.type = 1;
                    Simulation.FEL.E.Add(s.time, s);



                }
                switch (chose)
                {
                    case "M":
                        ArrivalMED s2 = new ArrivalMED();
                        float a2;
                        do
                        {
                            a2 = Simulation.T_now + Simulation.dist.Exponontiel( ma);
                        }
                        while (Simulation.FEL.E.ContainsKey(a2));
                        s2.time = a2;
                        s2.type = 3;
                        Simulation.FEL.E.Add(s2.time, s2);
                        break;
                    case "G":
                        ArrivalMED s1 = new ArrivalMED();
                        float a;
                        do
                        {
                            a = (float)(Simulation.T_now + Simulation.dist.GE(ma, Simulation.sigma));
                        }
                        while (Simulation.FEL.E.ContainsKey(a));
                        s1.time = a;
                        s1.type = 3;
                        Simulation.FEL.E.Add(s1.time, s1);
                        break;
                    case "D":
                        ArrivalMED s3 = new ArrivalMED();
                        float a3;
                        do
                        {
                            a3 = Simulation.T_now + ma;
                        }
                        while (Simulation.FEL.E.ContainsKey(a3));
                        s3.time = a3;
                        s3.type = 3;
                        Simulation.FEL.E.Add(s3.time, s3);
                        break;


                }
            }



        }
    }
}