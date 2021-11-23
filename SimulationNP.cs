using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DESQT;
using System.Windows;
using System.Net.Http.Headers;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Security.Cryptography;

namespace DESQT
{
    class SimulationNP
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
        public static float T_now;
        public static int cpt;
        /// <summary>
        public static readonly int idle = 0;
        public static readonly int busy = 1;
        public static readonly int vacn = 2;
        /// </summary>
        public static float Response_Time;
        public static float Waiting_Time;
        public static int packet_served;
        public static float mean_packet_served;

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
        public static List<float> Mean_response_time = new List<float>();
        public static List<float> Mean_waiting_time = new List<float>();
        public static List<float> Debit = new List<float>();
        /// //////////////////////////////////////
        public static List<float> Loss_rate = new List<float>();
        public static List<float> Blocking_prob = new List<float>();
        public static List<float> Vacancy_prob = new List<float>();

        //*************************************************************************************************************************************************       


        //************************************************************************************************************************************************   
        public static void Simulation_mew_test(String chose, String chose2, Boolean finite, float begin, float end, float step, float lambda,
             int k, int n, float ev, float eb, float ep, float es, float si)
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
                    Simulation_fonction_finite(chose, chose2, lambda, server.Mew);
                }
            }
            else
            {
                for (server.Mew = begin; server.Mew <= end; server.Mew += (float)step)
                {
                    Simulation_fonction_Infinie(chose, chose2, lambda, server.Mew);
                }
            }



        }
        //************************************************************************************************************************************************ 
        public static void Simulation_k_test(String chose, String chose2, float begin, float end, float step,
            float lambda, float mew, int n, float ev, float eb, float ep, float es, float si)
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
                Simulation_fonction_finite(chose, chose2, lambda, mew);
            }



        }

        //************************************************************************************************************************************************ 
        public static void Simulation_n_test(String chose, String chose2, Boolean finite, float begin, float end, float step,
            float lambda,float mew, int k,  float ev, float eb, float ep, float es, float si)
        {
            ECv = ev;
            ECb = eb;
            ECtp = ep;
            ECs = es;
            sigma = si;
            //G.lmbda = lmbda;
            server.Mew = mew;
            PQ.k = k;

            if (finite == true)
            {
                v1.n = (int)begin;

                for (v1.n = (int)begin; v1.n <= end; v1.n += (int)step)
                {
                    Simulation_fonction_finite(chose, chose2, lambda, mew);
                }
            }
            else
            {
                v1.n = (int)begin;

                for (v1.n = (int)begin; v1.n <= end; v1.n += (int)step)
                {
                    Simulation_fonction_Infinie(chose, chose2, lambda ,mew);
                }
            }




        }


        public static void Simulation_ENIDLE_test(String chose, String chose2, Boolean finite,
            float begin, float end, float step, float lambda,
             float mew, int n, int k, float eb, float ep, float es, float si)
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
                    Simulation_fonction_finite(chose, chose2, lambda, mew);
                }
            }
            else
            {
                for (ECv = (int)begin; ECv <= end; ECv += (int)step)
                {
                    Simulation_fonction_Infinie(chose, chose2, lambda, mew);
                }
            }




        }
        //************************************************************************************************************************************************ 

        static void Simulation_fonction_finite(String chose, String chose2, float ma, float ms)
        {


            Initialisation();

            Event even = new Event();
            while (packet_served<=2000)
            {


                even = (Event)FEL.E2.Values[0];
                FEL.E2.RemoveAt(0);

                if (Simulation.PQ.P2.Count() > 0)
                {
                    if (!Simulation.Dict.ContainsKey(Simulation.PQ.P2.Count()))
                    {
                        Simulation.Dict[Simulation.PQ.P2.Count()] = (even.time - T_now);
                    }
                    else
                    {
                        Simulation.Dict[Simulation.PQ.P2.Count()] += (even.time - T_now);
                    }
                }

                T_now = even.time;//Advance the global clock 

                if (even.type == arrivale)
                {
                    ArrivalNP.PArrivalNP(chose, true, ma, ms);
                }
                else if (even.type == start_service)
                {

                    Start_serviceNP.PStart_ServiceNP(chose2);
                }
                else
                {
                    DeparturNP.PDepartureNP();
                }
            }
            statistics();
        }

        static void Simulation_fonction_Infinie(String chose, String chose2, float ma,float ms)
        {


            Initialisation();

            Event even = new Event();

            while (T_now <= 10000)
            {

                even = (Event)FEL.E2.Values[0];
                FEL.E2.RemoveAt(0);

                if (Simulation.PQ.P2.Count() > 0)
                {
                    if (!Simulation.Dict.ContainsKey(Simulation.PQ.P2.Count()))
                    {
                        Simulation.Dict[Simulation.PQ.P2.Count()] = (even.time - T_now);
                    }
                    else
                    {
                        Simulation.Dict[Simulation.PQ.P2.Count()] += (even.time - T_now);
                    }
                }

                T_now = even.time;//Advance the global clock 

                if (even.type == arrivale)
                {
                    ArrivalNP.PArrivalNP(chose, false, ma, ms);
                }
                else if (even.type == start_service)
                {

                    Start_serviceNP.PStart_ServiceNP(chose);
                }
                else
                {
                    DeparturNP.PDepartureNP();
                }


            }
            statistics();
        }
        //******************************************************************************************************
        static void Initialisation()
        {
            current_T_now = 0;
            Response_Time = 0;
            Waiting_Time = 0;
            packet_served = 0;
            mean_packet_served = 0;
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

            PQ.P2.Clear();
            FEL.E2.Clear();
            packet_number = 0;
            test_number = 0;
            Dict.Clear();
            Dict1.Clear();
            ArrivalNP s = new ArrivalNP();
            s.time = T_now;
            s.type = 0;
            FEL.E2.Add(s.time, s);
        }
        //*************************************************************************************************************************
        public static void clear_stat_charts_var()
        {
            EC_array.Clear();

            Loss_rate.Clear();
            Blocking_prob.Clear();
            Vacancy_prob.Clear();
            Mean_response_time.Clear();
            Mean_waiting_time.Clear();
            Debit.Clear();
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

                packet_number += (entry.Key * (entry.Value / T_now));
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
            EC = (ECv * Pvac + ECb * (1 - Pvac)) + ECs * Nc + L * ECtp;


            //---------------------------------------------------------------------------------------------------------------------------
            EC_array.Add(EC);

            //Loss_rate.Add((packet_rejected * 100) / (packet_rejected + packet_served+cpt));
            Blocking_prob.Add(P_blocaking * 100);
            Vacancy_prob.Add(Pvac * 100);
            Mean_response_time.Add(Response_Time / packet_served);
            Mean_waiting_time.Add(Waiting_Time / packet_served);
            Debit.Add(packet_served / T_now);

        }

    }
}


