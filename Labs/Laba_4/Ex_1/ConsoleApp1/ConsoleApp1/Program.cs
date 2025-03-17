using System;
using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;

class Program
{
    struct Date
    {
        public int year;
        public int mounth;
        public int day;

        public string Get()
        {
            string s = $"{year}:{mounth}:{day}";
            return s;
        }
    }

    struct Adress
    {
        public string mailIndex;
        public string country;
        public string region;
        public string area;
        public string city;
        public string street;
        public string building;
        public string flat;

        public string Get()
        {
            string s = $"mailIndex: {mailIndex} country: {country} region: {region} area: {area} city: {city}" +
                       $"street: {street} building: {building} flat: {flat}";
            return s;
        }
    }

    class Patient(
        string surName,
        string name,
        string middleName,
        string sex,
        string nationality,
        double hight,
        double weight,
        Date dateOfBirth,
        string phoneNumber,
        Adress adress,
        string hospitalNumber,
        string department,
        string numberOfMedicalRecord,
        string diagnosis,
        string bloodType)
    {
        public string surName { get; set; } = surName;
        public string name { get; set; } = name;
        public  string middleName { get; set; } = middleName;
        public  string sex { get; set; } = sex;
        public  string nationality { get; set; } = nationality;
        public double hight { get; set; } = hight;
        public double weight { get; set; } = weight;
        public Date dateOfBirth { get; set; } = dateOfBirth;
        public string phoneNumber { get; set; } = phoneNumber;
        public Adress adress { get; set; } = adress;
        public string hospitalNumber { get; set; } = hospitalNumber;
        public string department { get; set; } = department;
        public string numberOfMedicalRecord { get; set; } = numberOfMedicalRecord;
        public string diagnosis { get; set; } = diagnosis;
        public string bloodType { get; set; } = bloodType;

        public Patient() : this("", "", "", "", "", 0, 0, new Date(), "", new Adress(), "", "", "", "", "")
        {
        }

        public void Write()
        {
            Console.WriteLine($"surName: {this.surName} name: {name} middleName: {middleName} sex: {sex} nationality: {nationality}" +
                              $"hight: {hight} weight: {weight} dateOfBirth: {dateOfBirth.Get()}" +
                              $"phoneNumber: {phoneNumber} adress: {adress.Get()} hospitalNumber: {hospitalNumber}" +
                              $"department: {department} numberOfMedicalRecord: {numberOfMedicalRecord}" +
                              $"diagnosis: {diagnosis} bloodType: {bloodType}");
            
        }

        public override string ToString()
        {
            string result =
                $"surName: {this.surName} name: {name} middleName: {middleName} sex: {sex} nationality: {nationality}" +
                $"hight: {hight} weight: {weight} dateOfBirth: {dateOfBirth.Get()}" +
                $"phoneNumber: {phoneNumber} adress: {adress.Get()} hospitalNumber: {hospitalNumber}" +
                $"department: {department} numberOfMedicalRecord: {numberOfMedicalRecord}" +
                $"diagnosis: {diagnosis} bloodType: {bloodType}";
            return result;
        }
    }

    static Patient ReadFromFile(StreamReader file)
    {
        Patient patient = new Patient();
        string s = file.ReadLine();
        patient.surName = s;

        return patient;
    }
    
    static void Main()
    {
        List<Patient> patients = new List<Patient>();

        try
        {
            using (StreamReader reader = new StreamReader("InputData.txt"))
            {
                for (int i = 0; i < 18; i++)
                {
                    if (reader.EndOfStream) break;

                    Patient patient = new Patient
                    {
                        surName = reader.ReadLine(),
                        name = reader.ReadLine(),
                        middleName = reader.ReadLine(),
                        sex = reader.ReadLine(),
                        nationality = reader.ReadLine(),
                        hight = double.Parse(reader.ReadLine()),
                        weight = double.Parse(reader.ReadLine()),
                        dateOfBirth = new Date
                        {
                            year = int.Parse(reader.ReadLine()),
                            mounth = int.Parse(reader.ReadLine()),
                            day = int.Parse(reader.ReadLine())
                        },
                        phoneNumber = reader.ReadLine(),
                        adress = new Adress
                        {
                            mailIndex = reader.ReadLine(),
                            country = reader.ReadLine(),
                            region = reader.ReadLine(),
                            area = reader.ReadLine(),
                            city = reader.ReadLine(),
                            street = reader.ReadLine(),
                            building = reader.ReadLine(),
                            flat = reader.ReadLine()
                        },
                        hospitalNumber = reader.ReadLine(),
                        department = reader.ReadLine(),
                        numberOfMedicalRecord = reader.ReadLine(),
                        diagnosis = reader.ReadLine(),
                        bloodType = reader.ReadLine()
                    };

                    patients.Add(patient);
                }
            }
            
            foreach (var patient in patients)
            {
                patient.Write();
                Console.WriteLine("--------------------------------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}");
        }
        
        try
        {
            using (StreamWriter writer = new StreamWriter("OutputData.txt"))
            {
                for (int i = 0; i < 18; i++)
                {
                    writer.WriteLine(patients[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при записі файлу: {ex.Message}");
        }
        
        
    }
}


