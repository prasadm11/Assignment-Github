using System;

namespace A3t2
{
    class Person
    {
        private int id;
        private string name;
        private string address;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Person(int id, string name, string address)
        {
            this.ID = id;
            this.Name = name;
            this.Address = address;
        }


        public Person()
        {
            ID = 1;
            Name = "Prasad";
            Address = "Airoli, Navi Mumbai";
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
        }
    }
}
