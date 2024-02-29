#include <math.h>
// Параметр конкретного типа термистора (из datasheet):
#define TERMIST_B 4300
#define VIN 5.0
void setup()
{
 Serial.begin(9600);
 // очищаем таблицу.
 Serial.println("CLEARSHEET");
 // передаём заголовки нашей таблицы в текстовом виде, иначе
 // говоря печатаем строку (англ. print line). 
 Serial.println("LABEL, Time, Temperature");
}
void loop()
{
 // вычисляем температуру в °С с помощью магической формулы.
 // Используем при этом не целые числа, а вещественные.
 float voltage = analogRead(A0) * VIN / 1024.0;
 float r1 = voltage / (VIN - voltage);
 float temperature = 1./( 1./(TERMIST_B)*log(r1)+1./(25. + 273.) ) - 273;
 // печатаем текущее время и температуру.
 // println переводит курсор на новую строку, а print — нет
 Serial.print("DATA,TIME,");
 Serial.println(temperature);
 delay(5000); // засыпаем на 5 секунд
}
