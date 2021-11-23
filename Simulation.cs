using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Net.Http.Headers;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Security.Cryptography;
using DESQT;

namespace DESQT
{
    class Simulation
    {
        public static Distributions dist = new Distributions();
        public static Packet_queue PQ = new Packet_queue();
        public static Event_queue FEL = new Event_queue();
        public static Server server = new Server();
        public static N_vacancy v1 = new N_vacancy();
        public static Random ra = new Random(1234);
        public static Random rand = new Random();
        public static float sigma;
        public static readonly int arrivale = 0;
        public static readonly int start_service = 1;
        public static readonly int departure = 2;
        public static readonly int arrivaleMED = 3;
        public static readonly int arrivaleHIGH = 4;

        public static float T_now;
        public static int cpt;
        /// <summary>
        public static readonly int idle = 0;
        public static readonly int busy = 1;
        public static readonly int vacn = 2;
        /// </summary>
        public static float Response_TimeLow;
        public static float Waiting_TimeLow;
        public static int packet_servedLow;
        public static float mean_packet_servedLow;

        public static float Response_TimeMed;
        public static float Waiting_TimeMed;
        public static int packet_servedMed;
        public static float mean_packet_servedMed;

        public static float Response_TimeHigh;
        public static float Waiting_TimeHigh;
        public static int packet_servedHigh;
        public static float mean_packet_servedHigh;

        public static int packet_rejected;
        public static float System_saturated_start_time;
        public static float System_saturated_time;
        public static float is_System_saturated;
        public static float P_blocaking;
        public static float vacancy_start_time;
        public static float vacancy_time;
        public static float Pvac;
        public static float L;//avrege  number of packetss in the system
        public static float B;//the avrege length of a busy period
        public static float V;//the average length of a vacation period
        public static float C;//the average duration of cycle number
        public static float Nc;//the average number of cycle
        public static int cpt_vac;
        public static int cpt_actif;
        public static int cycle_nbr;
        public static float cycle_duration_start;
        public static float cycle_duration;
        public static float current_T_now;
        public static double row = 0.000001;

        public static Dictionary<int, float> Dict = new Dictionary<int, float>();
        public static Dictionary<int, float> Dict1 = new Dictionary<int, float>();
        public static float packet_number;
        public static int test_number;
        public static float ECv;//energy consumption while the transmission unit is in idle state
        public static float ECb;//energy consumption while the transmission unitis in busy state
        public static float ECtp;// energy consumption for transmitting each packet present in the sensor node
        public static float ECs;//energy dissipated when a sensor node switchs from idle  state to busy state and inversely
        public static float EC;//total energy
        //for charts
        public static List<float> EC_array = new List<float>();
        /// /////////////////////
        public static List<float> Mean_response_timeLow = new List<float>();
        public static List<float> Mean_waiting_timeLow = new List<float>();
        public static List<float> DebitLow = new List<float>();
        /// //////////////////////////////////////
        public static List<float> Mean_response_timeMed = new List<float>();
        public static List<float> Mean_waiting_timeMed = new List<float>();
        public static List<float> DebitMed = new List<float>();
        /// /////////////////////////////////
        public static List<float> Mean_response_timeHigh = new List<float>();
        public static List<float> Mean_waiting_timeHigh = new List<float>();
        public static List<float> DebitHigh = new List<float>();
        /// ///////////////////////////////////
        public static List<float> Loss_rate = new List<float>();
        public static List<float> Blocking_prob = new List<float>();
        public static List<float> Vacancy_prob = new List<float>();
        public static int pakserv = 0;
        //*************************************************************************************************************************************************       


        //************************************************************************************************************************************************   
        public static void Simulation_mew_test(Boolean preemp,String chose, String chose2, Boolean finite, float begin, float end, float step, float lmbdalow,
            float lambdamed, float lambdahigh, int k, int n, int p,float ev, float eb, float ep, float es,float si)
        {
            ECv = ev;
            ECb = eb;
            ECtp = ep;
            ECs = es;
            sigma = si;
            PQ.k = k;
            v1.n = n;
            if (finite == true)
            {
                for (server.Mew = begin; server.Mew <= end; server.Mew += (float)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, server.Mew,p);
                }
            }
            else
            {
                for (server.Mew = begin; server.Mew <= end; server.Mew += (float)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, server.Mew,p);
                }
            }



        }
        //************************************************************************************************************************************************ 
        public static void Simulation_k_test(Boolean preemp,String chose, String chose2, float begin, float end, float step, float lmbdalow, float lambdamed,
            float lambdahigh, float mew, int n,int p, float ev, float eb, float ep, float es,float si)
        {
            ECv = ev;
            ECb = eb;
            ECtp = ep;
            ECs = es;
            sigma = si;

            server.Mew = mew;

            v1.n = n;
            for (PQ.k = (int)begin; PQ.k <= end; PQ.k += (int)step)
            {
                Simulation_fonction_finite(preemp,true, chose, chose2, lmbdalow, lambdamed, lambdahigh, mew,p);
            }

        }

        //************************************************************************************************************************************************ 
        public static void Simulation_n_test(Boolean preemp,String chose, String chose2, Boolean finite,float begin, float end, float step, float lmbdalow,
            float lambdamed,float lambdahigh,float mew, int k,int p,float ev, float eb, float ep, float es,float si)
        {
            ECv = ev; 
            ECb = eb;
            ECtp = ep;
            ECs = es;
            sigma = si;
            //G.lmbda = lmbda;
            server.Mew = mew;
            PQ.k = k;
           
            if(finite == true)
            {
                v1.n = (int)begin;

                for (v1.n = (int)begin; v1.n <= end; v1.n += (int)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, mew,p);
                }
            }
            else
            {
                v1.n = (int)begin;

                for (v1.n = (int)begin; v1.n <= end; v1.n += (int)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, mew,p);
                }
            }
                
            
           
            
        }

        //************************************************************************************************************************************************ 
        public static void Simulation_ENIDLE_test(Boolean preemp,String chose, String chose2, Boolean finite,
            float begin, float end, float step, float lmbdalow,
            float lambdamed, float lambdahigh, float mew,int n, int k, int p, float eb, float ep, float es, float si)
        {
            ECb = eb;
            ECtp = ep;
            ECs = es;
            sigma = si;
            server.Mew = mew;
            PQ.k = k;
            v1.n = n;
            if (finite == true)
            {

                for (ECv = (int)begin; ECv <= end; ECv += (int)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, mew, p);
                }
            }
            else
            {

                for (ECv = (int)begin; ECv <= end; ECv += (int)step)
                {
                    Simulation_fonction_finite(preemp,finite, chose, chose2, lmbdalow, lambdamed, lambdahigh, mew, p);
                }
            }




        }


        //*******************************************************8
        static void Simulation_fonction_finite(Boolean preemp,Boolean finite,String chose, String chose2, float malow,float mamed,float mahigh, float ms,int max_prio)
            {

             
                Initialisation();
                
                Event even = new Event();
   
                while (T_now<=10000)
                {

                    int p = rand.Next(max_prio);

                    even = (Event)FEL.E.Values[0];
                    FEL.E.RemoveAt(0);

                    if (Simulation.PQ.P.Count() > 0)
                    {
                        if (!Simulation.Dict.ContainsKey(Simulation.PQ.P.Count()))
                        {
                            Simulation.Dict[Simulation.PQ.P.Count()] = (even.time - T_now);
                        }
                        else
                        {
                            Simulation.Dict[Simulation.PQ.P.Count()] += (even.time - T_now);
                        }
                    }

                    T_now = even.time;//Advance the global clock 

                    if (even.type == arrivale)
                    {
                    Arrival.PArrival(chose, finite, malow, ms, 0);
                    }
                    else if (even.type == start_service)
                    {
                    if (preemp == false)
                    {
                        Start_service.PStart_Service(preemp,chose2);
                    }
                    else
                    {
                        Start_service.PStart_Service(preemp, chose2);
                    }
                    }
                    else if(even.type==departure)
                    {
                        Departur.PDeparture();
                    }else if (even.type == arrivaleMED)
                    {
                        ArrivalMED.PArrivalMED(chose, finite, mamed, ms, 1);
                    }else
                    {
                        ArrivalHIGH.PArrivalHIGH(chose, finite, mahigh, ms, 2);
                    }

            }
            statistics();
        }
      
        //******************************************************************************************************
        static void Initialisation()
            {

                 Response_TimeLow = 0;
                 Waiting_TimeLow=0;
                 packet_servedLow=0;
                 mean_packet_servedLow=0;
                 pakserv = 0;
                 Response_TimeMed =0;
                 Waiting_TimeMed=0;
                 packet_servedMed=0;
                 mean_packet_servedMed=0;

                 Response_TimeHigh=0;
                 Waiting_TimeHigh=0;
                 packet_servedHigh=0;
                 mean_packet_servedHigh=0;
                 P_blocaking = 0;
                cycle_duration = 0;
                cycle_duration_start = 0;
                cycle_nbr = 0;
                cpt_actif = 0;
                cpt_vac = 1;
                cpt = 0;
               
                packet_rejected = 0;
                T_now = 0;
                System_saturated_start_time = 0;
                System_saturated_time = 0;
                is_System_saturated = 0;
                vacancy_time = 0;
                vacancy_start_time = 0;
                server.state = vacn;
                
                PQ.P.Clear();
                FEL.E.Clear();
                packet_number = 0;
                test_number = 0;
                Dict.Clear();
                Dict1.Clear();
                Arrival s = new Arrival();
                s.time = T_now;
                s.type = 0;
                FEL.E.Add(s.time, s);
                ArrivalMED ss = new ArrivalMED();
                ss.time = (float)0.01;
                ss.type = 3;
                FEL.E.Add(ss.time, ss);
                ArrivalHIGH sss = new ArrivalHIGH();
                sss.time = (float)0.02;
                sss.type = 4;
                FEL.E.Add(sss.time, sss);
        }
        //*************************************************************************************************************************
        public static void clear_stat_charts_var()
        {
            EC_array.Clear();
           
            Loss_rate.Clear();
            Blocking_prob.Clear();
            Vacancy_prob.Clear();
            Mean_response_timeLow.Clear();
            Mean_response_timeMed.Clear();
            Mean_response_timeHigh.Clear();
            Mean_waiting_timeHigh.Clear();
            Mean_waiting_timeMed.Clear();
            Mean_waiting_timeLow.Clear();
            DebitLow.Clear();
            DebitMed.Clear();
            DebitHigh.Clear();
        }
            //**********************************************************************************************************************************************
        static void statistics()
            {
                if (is_System_saturated == 1) 
                {
                    System_saturated_time += (T_now - System_saturated_start_time);
                }
               if (server.state == vacn)
                {
                    vacancy_time += (T_now - vacancy_start_time);
                };
            //---------------------------------------
            
            Pvac = ((vacancy_time)) / T_now;
            P_blocaking = (System_saturated_time) / T_now;
            //-----------------------------------------

            foreach (KeyValuePair<int, float> entry in Dict)
            {
               
                 packet_number += (entry.Key * (entry.Value/T_now)); 
            }
            
            L = packet_number;
            
            //B = L / ms;
            B = (T_now - vacancy_time) / cpt_actif;   //the averege length of a busy period
            V = vacancy_time / cpt_vac;//the averege length of a vacation period       

            //C = B + V;//the average duratin of cycle
            C = cycle_duration / cycle_nbr;
            //Nc = 1 / C;//the number of cycle
            Nc = cycle_nbr / T_now;
            //the energy consumption 
            EC = (ECv * Pvac + ECb * (1 - Pvac)) + ECs * Nc+ L * ECtp;
             

            //---------------------------------------------------------------------------------------------------------------------------
            EC_array.Add(EC);
            
            //Loss_rate.Add((packet_rejected * 100) / (packet_rejected + packet_served+cpt));
            Blocking_prob.Add(P_blocaking * 100);
            Vacancy_prob.Add(Pvac*100);

            Mean_response_timeLow.Add(Response_TimeLow / packet_servedLow);
            Mean_waiting_timeLow.Add(Waiting_TimeLow / packet_servedLow);
            DebitLow.Add(packet_servedLow / T_now);

            Mean_response_timeMed.Add(Response_TimeMed / packet_servedMed);
            Mean_waiting_timeMed.Add(Waiting_TimeMed / packet_servedMed);
            DebitMed.Add(packet_servedMed / T_now);

            Mean_response_timeHigh.Add(Response_TimeHigh / packet_servedHigh);
            Mean_waiting_timeHigh.Add(Waiting_TimeHigh / packet_servedHigh);
            DebitHigh.Add(packet_servedHigh / T_now);
            

        }
       
    }
}


