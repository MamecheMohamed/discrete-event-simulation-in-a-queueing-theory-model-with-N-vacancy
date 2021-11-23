using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;



namespace DESQT
{
    class Server
    {   
        public  int state { get; set; } //0:empty /  1:transmission     /2: on vacation
        public float Mew { get; set; }// service rate
        public Server()
        {
            state = 0;//0:empty (busy) /  1:transmission(busy)     /2: on vacation(idle)
        }
       



    }
}
