using System;
using System.Collections.Generic;
using System.Text;

namespace laba10
{
    class Students
    {
        private string name;
        private string surname;
        private int age;
        private int group;
        private string speciality;
        private string faculty;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age
        {
            get => age; set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Возраст не может быть отрицательным");
                }
            }
        }
        public int Group
        {
            get => group; set
            {
                if (value > 0)
                {
                    group = value;
                }
                else
                {
                    Console.WriteLine("Группа не может быть отрицательным значением");
                }
            }
        }
        public string Speciality { get => speciality; set => speciality = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Students()
        {
            name = "Lobanov";
            surname = "Vladimir";
            age = 19;
            group = 2;
            speciality = "ISaT";
            faculty = "FIT";
        }
        public Students(string name, string surname, int age, int group, string speciality, string faculty)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.group = group;
            this.speciality = speciality;
            this.faculty = faculty;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode() ^ Age.GetHashCode() ^ Group.GetHashCode() ^ Speciality.GetHashCode() ^ Faculty.GetHashCode();
        }
        public override string ToString()
        {
            return "Name: " + Name + "Surname: " + Surname + "Age: " + Age + "Group: " + Group + "Speciality " + Speciality + "Faculty " + Faculty;
        }
    }
}
