using System;
using System.Collections.Generic;
using System.Text;

namespace DESQT
{
    class Packet : IComparable<Packet>
    {
        public float arrival_time { get; set; }
        public float start_servie_time { get; set; }
        public float service_time { get; set; }
        public float lambda { get; set; }
        public int priorite { get; set; }  //0 low 1 med 2 high
        public int id { get; set; }
        public int CompareTo(Packet other)
        {
            if (this.priorite < other.priorite) return 1;
            else if (this.priorite > other.priorite) return -1;
            else return 0;
        }

    }
}
