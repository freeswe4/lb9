using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9
{
    internal class CarParking
    {
        int numSlots;
        int numCars;
        static int count = 0; //статическая переменная для подсчёта объектов

        public int NumSlots //свойство для парковки
        {
            get => numSlots;
            set {
                if (value < 0)
                {
                    numSlots = 1;
                    Console.WriteLine("Количество мест на парковке не может быть отрицательным");
                }
                else numSlots = value;
            }
        }

        public int NumCars //свойство для автомобилей
        {
            get => numCars;
            set
            {
                if (value < 0)
                {
                    numCars = 0;
                    Console.WriteLine("Количестов машин не может быть отрицательным");
                }
                if (value > numSlots)
                {
                    numCars = numSlots;
                    Console.WriteLine("Машин не может быть больше парковочных мест");
                }
                //if (numCars == 0 & numSlots == 0)
                  // Console.WriteLine("И мест и автомобилей по нулям, деление на ноль - фу");
                else numCars = value;
            }
        }

        public CarParking() //конструктор без параметров
        {
            numSlots = 12;
            numCars = 5;
            count++;
        }

        public CarParking(int numSlots, int numCars) //конструктор с параметрами (играет роль this)
        {
            this.NumSlots = numSlots;
            this.NumCars = numCars;
            count++;
        }

        //можно ещё созать: конструктор, который будет ссылаться на другой конструктор; конструктор, который будет ссылаться по одному парметру через this;
        //в основ проге можно сделать инициализатор

        public string Show()
        {
            return $"На стоянке {NumSlots} мест и {NumCars} автомобилей"; 
        }


        public double PercentageOfCars() //процент загруженности парковки (до 0.01) (нестатическая)
        {
            return Math.Round((double)NumCars/(double)NumSlots * 100, 2);
        }

        public static double PercentageOfCars(CarParking cp)  //процент загруженности парковки (до 0.01) (статическая)
        {
            return Math.Round((double)cp.NumCars / (double)cp.NumSlots * 100, 2);
        }

        public static CarParking operator ++(CarParking cp) //перегрузка инкремента
        {
            cp.NumCars++;
            return cp;
        }

        public static CarParking operator --(CarParking cp) //перегрузка декремента
        {
            cp.NumCars--;
            return cp;
        }

        public static explicit operator int(CarParking cp) //перегрзка типа int (явно)
        {
            if (PercentageOfCars(cp) < 80)
                return cp.NumSlots * 80 / 100 - cp.NumCars + 1;
            else return 0;
        }

        public static implicit operator bool(CarParking cp)  //перегрзка типа bool (неявно)
        {
            if (cp.NumSlots == cp.NumCars) return false;
            else return true;
        }

        public static CarParking operator +(CarParking cp1, CarParking cp2) //перегрзука сложения
        {
            CarParking tempInst = new CarParking();
            tempInst.NumSlots = cp1.NumSlots + cp2.NumSlots;
            tempInst.NumCars = cp1.NumCars + cp2.NumCars;
            return tempInst;
        }

        public static bool operator >(CarParking cp1, CarParking cp2) //перегрузка операции больше
        {
            return PercentageOfCars(cp1) < PercentageOfCars(cp2) && cp1.NumSlots > cp2.NumSlots;
        }

        public static bool operator <(CarParking cp1, CarParking cp2) //перегрузка операции меньше
        {
            return PercentageOfCars(cp1) > PercentageOfCars(cp2) && cp1.NumSlots < cp2.NumSlots;
        }

        public static int GetCount => count; //подсчёт объектов
    }
}
