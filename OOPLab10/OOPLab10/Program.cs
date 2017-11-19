using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace OOPLab10
{
    
    class Program
    {
        static void Main(string[] args)
        {

            MyEvent<int> Event = new MyEvent<int>();
            ///////////////////////1///////////////////////////////////////
            MyArrayList list = new MyArrayList();
            Random rand = new Random();
            list.Add=rand.Next();
            list.Add = 2;
            list.Add = rand.Next();
            list.Add = rand.Next();
            list.Add = rand.Next();
            list.Add = rand.Next();
            list.Add = "string";
            list.Add = 2;
            list.Add = "string";

            Event.EventHandler3 += list.Delete;
            Event.EventHandler4 += list.Show;
            Event.DeleteArr("string");
            Event.DeleteArr(2);
            Console.WriteLine("----------------------------------------------------");

            ////////////////////////2/////////////////////////////////////
            MySortedSet<int> Col1= new MySortedSet<int>();
            Col1.Add = rand.Next();
            Col1.Add = rand.Next();
            Col1.Add = rand.Next();
            Col1.Add = rand.Next();
            Col1.Add = rand.Next();
            Col1.Add = rand.Next();
            Col1.Add = 32;
            Col1.Add = 49;
            Col1.Add = 111;

            Event.EventHandler  += Col1.Delete;
            Event.EventHandler2 += Col1.Show;           

            Event.Delete(32);

            Console.WriteLine("----------------------------------------------------");
            ///////////////////////////////////////////////////////2.2///////////////////////

            MyDictionary<int, int> dictionaty = new MyDictionary<int, int>();
            Event.EventHandler5 += dictionaty.Show;
            Event.Transform(Col1, dictionaty);            
            dictionaty.Search(1);
            Console.WriteLine("----------------------------------------------------");

            /////////////////////////////////////////////////3////////////////////////////////
            Employee Employee1 = new Employee("Maxim1", "Svirid", 26, "Hight", "AutoCardan", 700);
            Turner Turner2 = new Turner("Maxim2", "Svirid", 25, "machine operator of wide profile", "AutoCardan", 34000);
            Programmer Programmer1 = new Programmer("Maxim3", "Svirid", 28, "JS, AspectJ, PL/M, REXX", "EPAM", 44000);
            MyEvent<Person> EventPerson = new MyEvent<Person>();

            MyClassSortedSet<Person> n = new MyClassSortedSet<Person>();

            EventPerson.EventHandler += n.Add;
            EventPerson.EventHandler2 += n.Show;

            EventPerson.ADD(Employee1);
            EventPerson.ADD(Programmer1);
            EventPerson.ADD(Turner2);
            EventPerson.Show();





            Console.ReadKey();
        }


        class MyClassSortedSet<T> 
        {
         SortedSet<T> Sort= new SortedSet<T>();
         public void Add(T n)
            {
                Sort.Add(n);
            }
         public void Show()
            {
                foreach(object i in Sort)
                {
                    Console.WriteLine(i);
                    Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                }
            }

        
        }





        abstract class Person: IComparable<Person>
        {

            string name;
            string family;
            int age;
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public string Family
            {
                get { return family; }
                set { family = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public Person(string name, string family, int age)
            {
                this.name = name;
                this.family = family;
                this.age = age;
            }

            public virtual string Information()
            {
                //Console.WriteLine("Name: "+ Name + "\nFamily: "+ Family+ "\nAge: " + Age);
                return ("Name: " + Name + "\nFamily: " + Family + "\nAge: " + Age);
            }
            public override string ToString()
            {
                return String.Format("Тип объекта: Person") + "\n" + Information();
            }

         public  int CompareTo(Person n)
            {
                if (String.Compare(name, n.Name)>0)
                    return 1;
                else if (String.Compare(name, n.Name) < 0)
                    return -1; 
                    return 0;
            }


        }
        abstract class Working : Person
        {
            string organization;
            int wage;
            public string Organization
            {
                get { return organization; }
                set { organization = value; }
            }
            public int Wage
            {
                get { return wage; }
                set { wage = value; }
            }


            public Working(string name, string family, int age, string organization, int wage) : base(name, family, age)
            {
                this.wage = wage;
                this.organization = organization;
            }

            public override string Information()
            {
                // base.Information();
                //Console.WriteLine("Organization:   {0} \nWage: {1:c} ", Organization, Wage);
                return base.Information() + String.Format("\nOrganization:   {0} \nWage: {1:c} ", Organization, Wage);
            }

            public virtual void GetStr()
            {
                Console.WriteLine("\nWorking");
            }
            public override string ToString()
            {
                return String.Format("Тип объекта: Working") + "\n" + Information();
            }

        }
        class Employee : Working
        {
            string education;
            public string Education
            {
                get { return education; }
                set { education = value; }
            }

            public Employee(string name, string family, int age, string education, string organization, int wage) : base(name, family, age, organization, wage)
            {
                this.education = education;
            }


            public override string Information()
            {
                //base.Information();
                // Console.WriteLine("Education: " + Education);
                return base.Information() + ("\nEducation: " + Education);
            }

            public override string ToString()
            {
                return String.Format("Тип объекта: Employee") + "\n" + Information();
            }


          
            public override void GetStr()
            {
                Console.WriteLine("Employee");
            }


        }
        class Turner : Working
        {
            string specialty;
            public string Specialty
            {
                get { return specialty; }
                set { specialty = value; }
            }

            public Turner(string name, string family, int age, string specialty, string organization, int wage) : base(name, family, age, organization, wage)
            {
                this.specialty = specialty;
            }

            public new string Information()
            {
                return base.Information() + ("\nSpecialty: " + Specialty);
            }

            public override string ToString()
            {
                return String.Format("Тип объекта: Turner") + "\n" + Information();
            }
           

        }
        class Programmer : Working
        {
            string programmingLanguages;
            public string ProgrammingLanguages
            {
                get { return programmingLanguages; }
                set { programmingLanguages = value; }
            }

            public Programmer(string name, string family, int age, string programmingLanguages, string organization, int wage) : base(name, family, age, organization, wage)
            {
                this.programmingLanguages = programmingLanguages;
            }

            public override string Information()
            {
                // base.Information();
                //Console.WriteLine("\nProgrammingLanguages: " + ProgrammingLanguages);
                return base.Information() + ("\nProgramming Languages: " + programmingLanguages);

            }

            public override string ToString()
            {
                return String.Format("Тип объекта: Programmer") + "\n" + Information();
            }

        }




        







        delegate void MyEventHandler<T>(T i);
        delegate void MyEventHandler2<T>();
        delegate void MyEventHandler3(object i);
        class MyEvent<T>
        {
        int key = 0;
        public event MyEventHandler<T>  EventHandler=null;
        public event MyEventHandler2<T> EventHandler2 = null;

        public event MyEventHandler3    EventHandler3 = null;
        public event MyEventHandler2<T> EventHandler4 = null;
        public event MyEventHandler2<T> EventHandler5 = null;


            public void Delete(T i)
            {
                if(EventHandler!=null)
                    EventHandler(i);
                if (EventHandler2 != null)
                    EventHandler2();
            }

            public void DeleteArr(object i)
            {
                if (EventHandler3 != null)
                    EventHandler3(i);
                if (EventHandler4 != null)
                    EventHandler4();
            }

            public void Transform(MySortedSet<T> s, MyDictionary<int,T > d)
            {

                foreach(T i in s)
                {
                    d.Add(key,i);
                    key++;
                }
                if (EventHandler5 != null)
                    EventHandler5();
            }

            public void ADD(T m)
            {
                if (EventHandler != null)
                    EventHandler(m);

            }

            public void Show()
            {
                if(EventHandler2!=null)
                    EventHandler2();
            }

        }
        class MyArrayList
        {
            ArrayList collection = new ArrayList();

            public object Add
            {
                set { collection.Add(value); }

            }



            public void Show()
            {
                Console.WriteLine("+++++++++++++++++++++");
                foreach (object i in collection)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("+++++++++++++++++++++");
            }
            public void Delete(object del)
            {
                collection.Remove(del);
            }       
        }
        class MySortedSet<T> : IEnumerable, IEnumerator
        {
            SortedSet<T> collection = new SortedSet<T>();
            int index = -1;
         

            public T Add
            {
                set { collection.Add(value); }
                
            }
            public IEnumerator GetEnumerator()
            {
                return this;
            }
            public bool MoveNext()
            {
                if (index == collection.Count-1)
                {
                    Reset();
                    return false;
                }

                index++;
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            public object Current
            {
                get
                {
                    return collection.ElementAt(index);
                }
            }

            public void Show()
            {
                foreach (T i in collection)
                {
                    Console.WriteLine(i);
                }
            }
            public void Delete(T del)
            {
                collection.Remove(del);
            }

        }
        class MyDictionary<Tkey, TValue>
        {
            Dictionary<Tkey, TValue> Dic = new Dictionary<Tkey, TValue>();

            public void Add(Tkey key, TValue value)
            {
                Dic.Add(key, value);
            }

            public void Show()
            {
                Console.WriteLine("+++++++++++++++++++++");
                foreach (object i in Dic)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("+++++++++++++++++++++");
            }

            public void Search(Tkey key)
            {
                Console.WriteLine("Search");
                TValue val;
                 if (Dic.TryGetValue(key, out val))
                {
                    Console.WriteLine("<<"+val+">>");
                }
                else Console.WriteLine("Not found");
              
            }

        }
    }
}
