using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DESQT
{
    class Event_queue
    {

        public SortedList<float, Event> E { get; set; }
        public SortedList<float, Event> E2 { get; set; } 

      
        public Event_queue()
        {
            E2 = new SortedList<float, Event>();
            E = new SortedList<float, Event>();
        }


    }
}
