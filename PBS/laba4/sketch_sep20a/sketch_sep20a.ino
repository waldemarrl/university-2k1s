#define RED   11                      // 11 контакт для красного вывода RGB-светодиода

#define GREEN 10                      // 10 контакт для зеленого вывода RGB-светодиода

#define BLUE  9                      // 9 контакт для синего вывода RGB-светодиода


int rval = 0;                         // переменная для хранения значений для красного вывода RGB-светодиода

int gval = 0;                         // переменная для хранения значений для зеленого вывода RGB-светодиода

int bval = 0;                         // переменная для хранения значений для синего вывода RGB-светодиода


void setup()

{

  Serial.begin(9600);                 // Инициализация последовательного соединения на скорости 9600 бод

 

  pinMode(RED, OUTPUT);               // Устанавливаем контакт RED(т.е 11 контакт) как выход 

  pinMode(GREEN, OUTPUT);             // Устанавливаем контакт GREEN(т.е 10 контакт) как выход

  pinMode(BLUE, OUTPUT);              // Устанавливаем контакт BLUE(т.е 9 контакт) как выход

}


void loop()

{

  // Выполняем цикл, пока в буфере есть данные 

  while (Serial.available() > 0)

  {

    rval = Serial.parseInt();        // первое допустимое целое число

    gval = Serial.parseInt();        // второе допустимое целое число

    bval = Serial.parseInt();        // третье допустимое целое число


    if (Serial.read() == '\n')       // передача окончена

    {

      // устанавливаем яркость светодиода

      analogWrite(RED, rval);

      analogWrite(GREEN, gval);

      analogWrite(BLUE, bval);

    }

  }

}