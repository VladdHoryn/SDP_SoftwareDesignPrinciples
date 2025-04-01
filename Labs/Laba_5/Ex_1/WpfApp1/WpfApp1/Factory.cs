namespace WpfApp1;
using System;
using System.IO;

public class Factory
{
    private string name;
        private string location;
        private int employees;
        private int productionCapacity;
        private double efficiency;
        private bool isOperational;
        private DateTime establishedYear;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int Employees
        {
            get { return employees; }
            set { employees = value > 0 ? value : 1; }
        }

        public int ProductionCapacity
        {
            get { return productionCapacity; }
            set { productionCapacity = value > 0 ? value : 1; }
        }

        public double Efficiency
        {
            get { return efficiency; }
            set { efficiency = (value >= 0 && value <= 1) ? value : 0.5; }
        }

        public bool IsOperational
        {
            get { return isOperational; }
            set { isOperational = value; }
        }

        public DateTime EstablishedYear
        {
            get { return establishedYear; }
            set { establishedYear = value; }
        }
        
        public Factory()
        {
            Name = "Unknown";
            Location = "Unknown";
            Employees = 10;
            ProductionCapacity = 1000;
            Efficiency = 0.75;
            IsOperational = true;
            EstablishedYear = DateTime.Now;
        }
        
        public int CalculateAnnualProduction()
        {
            return (int)(ProductionCapacity * Efficiency * 365);
        }
        
        public string GetFactoryInfo()
        {
            return $"Завод: {Name}\nМісцезнаходження: {Location}\nПрацівники: {Employees}\n" +
                   $"Потужність: {ProductionCapacity} од/день\nЕфективність: {Efficiency * 100}%\n" +
                   $"Річне виробництво: {CalculateAnnualProduction()} одиниць\n" +
                   $"Рік заснування: {EstablishedYear.Year}\nПрацює: {(IsOperational ? "Так" : "Ні")}";
        }
        
        public void SaveToFile(string filePath)
        {
            string data = GetFactoryInfo();
            File.WriteAllText(filePath, data);
        }
}