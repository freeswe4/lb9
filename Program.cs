namespace lb9
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            int tempChooseNumHead;
            do
            {

                Console.WriteLine(@"Выберите действие:
1. Работа с классом одинарных парковок
2. Работа с коллекцией
3. Выход");
                Console.WriteLine();
                tempChooseNumHead = InputData.InputAndValidateIntBord("Введите номер команды", 1, 3);
                switch (tempChooseNumHead)
                {
                    case 1:
                        CarParking cp1 = new CarParking(); //экземпляр конструктора без параметров
                        Console.WriteLine(cp1.Show());

                        CarParking cp3 = new CarParking(12, 7); //экземпляр конструктора с параметрами
                        Console.WriteLine(cp3.Show());

                        CarParking cp2 = new CarParking(InputData.InputAndValidateInt("Введите количество парковочных мест", 0), InputData.InputAndValidateInt("Введите количестов автомобилей на парковке", 0)); //экземпляр конструктора с параметрам
                                                                                                                                                                                                                  // вводим значения сами
                        Console.WriteLine(cp2.Show());

                        double percentage1, percentage2, percentage3;

                        percentage1 = CarParking.PercentageOfCars(cp1); //статическая функция
                        Console.WriteLine($"Занято {percentage1}% парковки\n");

                        percentage2 = cp2.PercentageOfCars(); //нестатическая функция
                        Console.WriteLine($"Занято {percentage2}% парковки\n");

                        percentage3 = cp3.PercentageOfCars(); //нестатическая функция
                        Console.WriteLine($"Занято {percentage3}% парковки\n");

                        CarParking cp4 = new CarParking(12, 5); //экземпляр класса для прегрузки операции
                        Console.WriteLine(cp4.Show());

                        cp4++; //перегрузка операции инкремента
                        Console.WriteLine("После прибалвения одного автомобиля");
                        Console.WriteLine(cp4.Show());

                        cp4--; //перегрузка операции декремента
                        Console.WriteLine("После убавления одного автомобиля\n");
                        Console.WriteLine(cp4.Show());

                        CarParking cp5 = new CarParking(10, 4);
                        Console.WriteLine(cp5.Show());
                        int overLoad1 = (int)cp5; //перегрзука явно
                        Console.WriteLine($"Необходимо {overLoad1} автомобилей до загруженности парковки на 80%\n");

                        CarParking cp6 = new CarParking(19, 9);
                        Console.WriteLine(cp6.Show());
                        bool overLoad2 = cp6; //перегрузка неявно
                        if (overLoad2 == true)
                            Console.WriteLine("На парквоке есть свободные места\n");
                        else Console.WriteLine("Парковка полностью заполнена\n");

                        CarParking cp7 = new CarParking(367, 235);
                        CarParking cp8 = new CarParking(435, 200);
                        Console.WriteLine(cp7.Show());
                        Console.WriteLine(cp8.Show());
                        CarParking cp9 = cp7 + cp8; //перегрзука операции сложения
                        Console.WriteLine($"Объединяя две парковки получаем: {cp9.NumSlots} парковочных мест и {cp9.NumCars} автомобилей\n");
                        if (cp7 > cp8) //перегрузка операции больше
                            Console.WriteLine("На парковке cp1 загруженность ниже и общее количество мест больше, чем на парковке cp2\n");
                        if (cp7 < cp8) //перегрузка операции меньше
                            Console.WriteLine("На парковке cp1 загруженность выше и общее количество мест меньше, чем на парковке cp2\n");
                        break;

                    case 2:
                        CarParkingArray cpArr1 = new CarParkingArray(); //конструктор коллекции без параметров
                        Console.WriteLine("В первом массиве парковок");
                        for (int i = 0; i < cpArr1.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(cpArr1[i].Show());
                        Console.WriteLine();

                        CarParkingArray cpArr2 = new CarParkingArray(5); //конструктор коллекции с параметром (длина)
                        Console.WriteLine("Во втором массиве парковок");
                        for (int i = 0; i < cpArr2.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(cpArr2[i].Show());

                        int minParking = CarParkingMin(cpArr2); //вызов функции вычисления свободных мест на самой малозагруженной парковке
                        if (minParking == 0)
                            Console.WriteLine("Все парквоки загружены максимально\n");
                        else
                            Console.WriteLine($"Количество свободных парковочных мест на самой малозагруженной парковке равно {minParking}\n");

                        CarParkingArray cpArr3 = new CarParkingArray(cpArr2); //конструктор глубокого копирования коллекции
                        Console.WriteLine("В третьем массиве парковок(глубокое копирование)");
                        for (int i = 0; i < cpArr3.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(cpArr3[i].Show());
                        Console.WriteLine();

                        for (int i = 0; i < cpArr3.Length; i++) //ввод элементов массива с помощью ввода
                        {
                            cpArr3[i] = new(InputData.InputAndValidateInt($"Введите количество парковочных мест на {i + 1} парковке", 0), InputData.InputAndValidateInt($"Введите количество машин на {i + 1} парковке", 0));
                        }
                        for (int i = 0; i < cpArr3.Length; i++)
                            Console.WriteLine(cpArr3[i].Show());
                        Console.WriteLine();

                        Console.WriteLine($"Создано {CarParking.GetCount} объектов класса CapParking\n"); //вывод количества объектов класса Class1
                        Console.WriteLine($"Создано {CarParkingArray.GetCountArr} объектов класса CapParkingArray\n"); //вывод количества объектов класса CarParkingArray

                        try
                        {
                            cpArr2[0] = new(200, 5); //запись нового объекта по существующему индексу
                            for (int i = 0; i < cpArr2.Length; i++) //вывод элементов коллекции с перезаписанными элементами с помощю функции класса Class1 
                                Console.WriteLine(cpArr2[i].Show());
                            Console.WriteLine();
                            cpArr2[100] = new(100, 20); //запись объекта по несуществующему индексу

                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Конец работы");
                        }
                        break;

                    default: break;
                }   
            } while (tempChooseNumHead != 3);
            Console.WriteLine("До свидания");
        }

        public static int CarParkingMin(CarParkingArray cpArr) //функция вычисления свободных мест на самой малозагруженной парковке
        {
            double minNumCarParking = 100; //максимально возможная загруженность
            CarParking tempElemArr = cpArr[0]; //вспомогательная переменная для поиска минимальной загруженности
            for (int i = 0; i < cpArr.Length; i++)
            {
                if (CarParking.PercentageOfCars(cpArr[i]) < minNumCarParking) //если загруженность парковки текущей парковки меньше минимальной
                {
                    tempElemArr = cpArr[i];
                    minNumCarParking = CarParking.PercentageOfCars(tempElemArr); //минимальная загруженность становится равна загруженности текущего элемента
                }
            }
            return (tempElemArr.NumSlots - tempElemArr.NumCars); //вывод свободных мест
        }
    }
}
