using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DESQT
{
    class Packet_queue
    {
        
        public PriorityQueue<Packet> P { get; set; }
        public Queue<Packet> P2;
        public  int k { get; set; }

        public Packet_queue()
        {
            P = new PriorityQueue<Packet>();
            P2 = new Queue<Packet>();

        }

        public Boolean Isfull()
        {
            if(Simulation.cpt < Simulation.PQ.k)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean IsfullNP()
        {
            if (SimulationNP.cpt < SimulationNP.PQ.k)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
