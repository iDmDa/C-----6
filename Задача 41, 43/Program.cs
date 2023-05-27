// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3
// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

#nullable disable

var cons_color = new Dictionary<string, int>();
for (int i = 0; i < 16; i++) cons_color.Add(((ConsoleColor)i).ToString(), i);

void msg_style (string message, string status = "Green") {
    //Black, DarkBlue, DarkGreen, DarkCyan, 
    //DarkRed, DarkMagenta, DarkYellow, Gray, 
    //DarkGray, Blue, Green, Cyan, 
    //Red, Magenta, Yellow, White

    Console.ForegroundColor = (ConsoleColor)cons_color[status];
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.Gray;
}

string enter_number (string info) {
    for(;;) {

        Console.Write(info);
        string a = Console.ReadLine();

        if(a.ToLower() == "q") return "Exit";

        if(!Double.TryParse(a, out double a_db)) {
            msg_style("Ошибка! Введено не число!", "DarkRed");
            continue;
        };
        return a;
    }
}

string intArray (string str_stream) { //фильтр ввода, создние строки вида "1, 2, 3"

    str_stream = str_stream.Replace(',', ' ');
    string[] strem_item = str_stream.Split(' ');
    string int_item = "";

    foreach(string item in strem_item) {
        if(item == "") continue;
        if(item.ToLower() == "q") return "Exit";
        if(!Int32.TryParse(item, out int item_int)) {
            msg_style("Ошибка! Введено не число!", "DarkRed");
            return "Error";
        }
        int_item += item + ", ";
    }
    int_item = int_item.Substring(0, int_item.Length-2);
    return int_item;
}

int plusCount (string str) { //подсчет значений >0
    int positiveCount = 0;
    string[] str_array = str.Split(',');
    foreach(string item in str_array) {
        if(Convert.ToInt32(item) > 0) positiveCount++;
    }
    return positiveCount;
}

void task41() { //Задача 41
    for(;;) 
    {
        msg_style("Введите список чисел через запятую или пробел (для выхода введите 'q')", "Blue");
        string str_stream = Console.ReadLine();

        if(intArray(str_stream) == "Error") continue; 
        if(intArray(str_stream) == "Exit") break; 

        str_stream = intArray(str_stream);
        msg_style($"{str_stream} -> {plusCount(str_stream)}");
        break;
    }
}

void task43() {

    msg_style("Введите параметры уравнений:", "Blue");
    msg_style("y = k1 * x + b1", "Blue");
    msg_style("y = k2 * x + b2", "Blue");
    msg_style("Для выхода из режима ввода введите 'q')", "Blue");

    string[] fncParam = {"k1", "b1", "k2", "b2"};
    double[] parametry = new double[4];
    int i = 0;
    string tmp = "";
    foreach(string item in fncParam) {
        tmp = enter_number(item + ": ");
        if(tmp == "Exit") return;
        parametry[i++] = Convert.ToDouble(tmp);
    }

    double x = (parametry[3]-parametry[1])/(parametry[0]-parametry[2]);
    double y = parametry[0] * x + parametry[1];
    msg_style($"k1 = {parametry[0]}, b1 = {parametry[1]}, k2 = {parametry[2]}, b2 = {parametry[3]} -> ({x}; {y})");
}

Console.Clear();
for(;;) {
    
    msg_style("Введите номер задачи (41 или 43, для выхода введите 'q')", "DarkMagenta");
    string task = Console.ReadLine();
    if(task.ToLower() == "q") System.Environment.Exit(0);

    switch (task)
    {
        case "41":
            Console.Clear();
            task41();
        break;

        case "43":
            Console.Clear();
            task43();
        break;

        default:
            msg_style($"Задача № {task} не входит в список задач!", "DarkRed");
        break;
    }
}
