using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_OOP.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_1_OOP
{
    internal class Employee
    {
        private int _id;
        private string _name;
        private HiringDate _hireDate;
        private decimal _salary;
        private Gender _gender;
        public SecurityLevel securityLevel { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID must be a positive number");
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name must be entered");
                else if (value.All(char.IsDigit))
                    throw new ArgumentException("Name must contain at least one non-digit character");
                _name = value;
            }
        }
        public HiringDate hireDate
        {
            get => _hireDate;
            set
            {
                if (value == null)
                    throw new ArgumentException("Hiring Date must be entered");
                _hireDate = value;
            }
        }
        public decimal Salary
        {
            get => _salary; 
            set => _salary = value <= 0 ? throw new ArgumentException("Salary must be Positive") : value;
        }
        public Gender Gender
        {
            get =>  _gender; 
            set
            {
                if (value == Gender.M || value == Gender.F)
                    _gender = value;
                else
                    throw new ArgumentException("Invalid Gender");
            }
        }
        public Employee(int id, string name, SecurityLevel securityLevel,
                        int salary, HiringDate hireDate, Gender gender)
        {
            _id = id;
            _name = name;
            this.securityLevel = securityLevel;
            _salary = salary;
            this.hireDate = hireDate;
            _gender = gender;
        }
        public override string ToString()
        {
            return string.Format("ID:{0}, Name:{1}, Salary: {2:C}, hireDate: {3}, Gender: {4}"
                                 , _id, _name, _salary, hireDate, _gender);
        }
    }
}
