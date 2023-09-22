using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfpatients
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            Hospital hospital = new Hospital();

            while (isWork)
            {
                Console.WriteLine("\n1 - пациенты по фамилии\n2 - пациенты по возрасту\n3 - найти пациента по заболеванию\n4 - выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        hospital.SortFullName();
                        break;

                    case "2":
                        hospital.SortAge();
                        break;

                    case "3":
                        hospital.SearchDiagnosis();
                        break;

                    case "4":
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка. Введены не коректные данные");
                        break;
                }
            }
        }
    }

    class Patient
    {
        public Patient(string surname, string firstName, string patronymic, string disease, int age)
        {
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
            Diagnosis = disease;
            Age = age;
        }

        public string Surname { get; private set; }
        public string FirstName { get; private set; }
        public string Patronymic { get; private set; }
        public string Diagnosis { get; private set; }

        public int Age { get; private set; }
    }

    class Hospital
    {
        List<Patient> patients = new List<Patient>
        {   new Patient("Иванов","Иван","Иванович","Диабет",15),
            new Patient("Петров","Петор","Петрович","Ожирение",25),
            new Patient("Сидоров","Владимир","Сергеевич","Кашель",25),
             new Patient("Козлов","Олег","Михайлович","Кашель",30),
              new Patient("Воробьёв","Сергей","Владимирович","Грипп",18),
               new Patient("Андреева","Татьяна","Ивановна","Температура",45),
                new Patient("Федорова","Юлия","Михаиловна","Метеоризм",90),
                 new Patient("Иванова","Екатерина","Андреевна","Неовный тик",50),
                  new Patient("Сидорова","Мария","Яковлевна","Грипп",37),
                   new Patient("Андреев","Андрей","Андреевич","Метеоризм",40)
        };

        public void SortFullName()
        {
            var fullNames = patients.OrderBy(_patients => _patients.Surname);

            foreach (var fullName in fullNames)
            {
                Console.WriteLine($"{fullName.Surname} {fullName.FirstName} {fullName.Patronymic}");
            }
        }

        public void SortAge()
        {
            var ages = patients.OrderBy(patient => patient.Age);

            foreach (var age in ages)
            {
                Console.WriteLine($"{age.Surname} {age.FirstName} {age.Patronymic} {age.Age}");
            }
        }

        public void SearchDiagnosis()
        {
            Console.WriteLine("Введите диагноз больного");
            string userInput = Console.ReadLine();

            var diagnoses = patients.Where(patient => patient.Diagnosis == userInput);

            foreach (var diagnosis in diagnoses)
            {
                Console.WriteLine($"{diagnosis.Surname} {diagnosis.FirstName} {diagnosis.Patronymic} {diagnosis.Diagnosis}");
            }
        }
    }
}
