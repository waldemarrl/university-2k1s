using System;

namespace lab03
{
    public partial class Customer
    {
        private readonly int id;
        private string lastname;
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private string patronymic;
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private ulong number;
        //
        public ulong Number
        {
            get { return number; }
            set
            {
                if (value < 1000000000000000 || value > 9999999999999999)
                {
                    number = 0;
                }
                else
                {
                    number = value;
                }
            }

        }
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }


        public Customer(int i, string l, string f, string p, string a, ulong n, int b) { id = i; lastname = l; firstname = f; patronymic = p; address = a; number = n; balance = b; count++; }
        public Customer(int iii) { id = iii; lastname = "unknown"; firstname = "unknown"; patronymic = "unknown"; address = "unknown"; balance = 0; count++; }
        public Customer(int ii, string ll, string ff, string pp) { id = ii; lastname = ll; firstname = ff; patronymic = pp; address = "Belorusskaya Street"; number = 4758478378537748; balance = 485934; count++; }

        //
        static Customer() {
            Console.WriteLine("Hello");
        }
        private Customer() { }

        public const string city = "Minsk";
        //
        public void Crediting(out int Plus)
        {
            Plus = balance + 1000;
            balance = Plus;
        }

        public void Debiting(ref int Minus)
        {
            balance -= Minus;
        }
        //

        public static int count;
        public Customer(int x, string y)
        {
            count++;
            this.id = x;
            this.lastname = y;
            Customer.count++;
        }


        //
        public override int GetHashCode()
        {
            Console.WriteLine($"Hashcode of lastname: {lastname.GetHashCode()}");
            return lastname.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"{id}\t{lastname}\t{firstname}\t{patronymic}\t{address}\t{number}\t{balance}\t{city}";
        }

        public static void Array()
        {
            var Customer = new Customer[3];
            Customer[0] = new Customer(1, "Smirnova", "Olga", "Viktorovna", "Glinskogo Street", 3746287463746374, 4000);
            Customer[1] = new Customer(2, "Guk", "Daria", "Dmitrievna", "Stroitelei Street", 2948375628472847, 5600);
            Customer[2] = new Customer(3, "Karpovich", "Alexey", "Alexandrovna", "Belorusskaya Street", 6573847364736473, 34789);

            string[] words = { Customer[0].lastname, Customer[1].lastname, Customer[2].lastname };
            foreach (var item in words)
                Console.WriteLine(item);
            char[] a = words[0].ToCharArray();
            char[] b = words[1].ToCharArray();
            char[] c = words[2].ToCharArray();
            if (a[0] < b[0] & a[0] < c[0])
            {
                if (b[0] < c[0])
                {
                    Console.WriteLine(words[0] + "\t" + words[1] + "\t" + words[1]);
                }
                else { Console.WriteLine(words[0] + "\t" + words[2] + "\t" + words[1]); }
            }
            else if (b[0] < c[0] & b[0] < a[0])
            {
                if (a[0] < c[0])
                    Console.WriteLine(words[1] + "\t" + words[0] + "\t" + words[2]);
                else { Console.WriteLine(words[1] + "\t" + words[2] + "\t" + words[0]); }
            }
            else if (c[0] < a[0] & c[0] < b[0])
            {
                if (a[0] < b[0])
                    Console.WriteLine(words[2] + "\t" + words[0] + "\t" + words[1]);
                else { Console.WriteLine(words[2] + "\t" + words[1] + "\t" + words[0]); }
            }
            Console.WriteLine("Введите верх интервала(16 цифр): ");
            ulong j = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Введите низ интервала(16 цифр): ");
            ulong t = ulong.Parse(Console.ReadLine());
            Console.WriteLine("Покупатель: ");
            foreach (var d in Customer)
            {
                if (d.number < j & d.number > t)
                    Console.WriteLine(d);
            }
        }

        public void GetInfo()
        {
            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine($"Id: {id} | Lastname: {lastname} | Firstname: {firstname} | Patronymic: {patronymic} | Address: {address} | Number of credit card: {number} | Balance: {balance} | City: { city}");
            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer Sam = new Customer(1, "John", "Sam", "Tom", "Stret 3", 74789372897736777, 5020);
            Customer Tom = new Customer(2);
            Tom.Number = 6748585;
            ulong number = Tom.Number;
            Customer Kris = new Customer(3, "Shkoda", "Kristina", "Mihailovna");
            int y;
            Sam.Crediting(out y);
            Sam.GetInfo();
            Tom.GetInfo();
            int x = 3948;
            Kris.Debiting(ref x);
            Kris.GetInfo();
            Kris.GetHashCode();
            Tom.GetHashCode();
            Console.WriteLine(Tom.ToString());
            bool r = Tom.Equals(Sam);
            bool rr = Tom.Equals(Tom);
            Console.WriteLine($"Tom-Sam: {r}\tTom-Tom: {rr}");
            Console.WriteLine($"Количество: {Customer.count}");
            Customer.Array();
            var user = new { lastname = "Dorofeeva", name = "Diana" };
            Console.WriteLine(user.lastname);
        }
    }
}