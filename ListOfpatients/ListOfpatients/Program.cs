using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfpatients
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandByLastName = "1";
            const string CommandByAge = "2";
            const string CommandOnSickness = "3";
            const string CommandExit = "4";

            bool isWork = true;
            Hospital hospital = new Hospital();

            while (isWork)
            {
                Console.WriteLine($"\n{CommandByLastName} - пациенты по фамилии\n{CommandByAge} - пациенты по возрасту\n{CommandOnSickness} - найти пациента по заболеванию\n{CommandExit} - выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandByLastName:
                        hospital.SortFullName();
                        break;

                    case CommandByAge:
                        hospital.SortAge();
                        break;

                    case CommandOnSickness:
                        hospital.SearchDiagnosis();
                        break;

                    case CommandExit:
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

            ShowPatientsInfo(fullNames.ToList());
        }

        public void SortAge()
        {
            var ages = _patients.OrderBy(patient => patient.Age);

            ShowPatientsInfo(ages.ToList());
        }

        public void SearchDiagnosis()
        {
            Console.WriteLine("Введите диагноз больного");
            string userInput = Console.ReadLine();

            var diagnoses = _patients.Where(patient => patient.Diagnosis == userInput);

            ShowPatientsInfo(diagnoses.ToList());
        }

        private void ShowPatientsInfo(List<Patient> patients)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                patients[i].ShowInfo();
            }
        }
    }
}
