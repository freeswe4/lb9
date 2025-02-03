using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9
{
    internal class CarParkingArray
    {
        static Random rnd = new Random();

        int length = 10;

        static int count = 0;

        CarParking[] arr;

        public int Length //свойство длины
        {
            get => arr.Length;
        }

        public CarParkingArray() //конструктор без параметров
        {
            int Length = length;
            arr = new CarParking[Length];
            for (int i = 0; i < Length; i++)
                arr[i] = new CarParking(i + 12, i + 6);
            count++;
        }

        public CarParkingArray(int  Length) //конструктор с параметром
        {
            arr = new CarParking[Length];
            for (int i = 0; i < Length; i++)
                arr[i] = new CarParking(rnd.Next(1000), rnd.Next(1000));
            count++;
        }

        public CarParkingArray(CarParkingArray other) //конструктор копирования
        {
            arr = new CarParking[other.Length];
            for (int i = 0; i < Length; i++)
                arr[i] = new CarParking(other[i].NumSlots, other[i].NumCars);
            count++;
        }

        public void Show() //функция вывода элементов массива класса
        {
            for (int i = 0; i < this.Length; i++)
                arr[i].Show();
        }

        public CarParking this[int index] //индексатор с условиями
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public static int GetCountArr => count; //подсчёт объектов
    }
}
