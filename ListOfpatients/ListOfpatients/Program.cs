using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfpatients
{
    class Program
    {
        static void Main(string[] args)
        {
            const string commandByLastName = "1";
            const string commandByAge = "2";
            const string commandOnSickness = "3";
            const string commandExit = "4";

            bool isWork = true;
            Hospital hospital = new Hospital();

            while (isWork)
            {
                Console.WriteLine($"\n{commandByLastName} - пациенты по фамилии\n{commandByAge} - пациенты по возрасту\n{commandOnSickness} - найти пациента по заболеванию\n{commandExit} - выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case commandByLastName:
                        hospital.SortFullName();
                        break;

                    case commandByAge:
                        hospital.SortAge();
                        break;

                    case commandOnSickness:
                        hospital.SearchDiagnosis();
                        break;

                    case commandExit:
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

        public void ShowInfo()
        {
            Console.WriteLine($"{Surname} {FirstName} {Patronymic} {Diagnosis} {Age}");
        }
        
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>
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
            var fullNames = _patients.OrderBy(_patients => _patients.Surname);

            foreach (var fullName in fullNames)
            {
                fullName.ShowInfo();
            }
        }

        public void SortAge()
        {
            var ages = _patients.OrderBy(patient => patient.Age);

            foreach (var age in ages)
            {
                age.ShowInfo();
            }
        }

        public void SearchDiagnosis()
        {
            Console.WriteLine("Введите диагноз больного");
            string userInput = Console.ReadLine();

            var diagnoses = _patients.Where(patient => patient.Diagnosis == userInput);

            foreach (var diagnosis in diagnoses)
            {
                diagnosis.ShowInfo();
            }
        }
    }
}
