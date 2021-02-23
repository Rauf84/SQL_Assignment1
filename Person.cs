using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Assignment1
{
    class Person
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public string Födelsedatum { get; set; }
        public string Dödsdatum { get; set; }
        public int Mor { get; set; }
        public int Far { get; set; }
    }
}
