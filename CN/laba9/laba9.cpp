// laba9.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <bitset>

using namespace std;

unsigned long ip, mask;

unsigned long CharToLong(char* ip_)
{
	unsigned long out = 0;//число для IP-адреса
	char* buff;
	buff = new char[3];
	//буфер для хранения одного октета
	for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
	{
		if (ip_[i] != '.') //если не точка
			buff[j] = ip_[i]; // записать символ в буфер
		if (ip_[i] == '.' || ip_[i + 1] == '\0')
		{
			// если следующий октет или последний
			out <<= 8; //сдвинуть число на 8 бит
			if (atoi(buff) > 255)
				return NULL;
			// еcли октет больше 255 – ошибка
			out += (unsigned long)atoi(buff);
			//преобразовать и добавить
			//к числу IP-адреса
			k++;
			j = -1;
			delete[]buff;
			buff = new char[3];
		}
	}
	return out;
}

bool CheckAddress(char* ip_)
{
	int points = 0, // количество точек
		numbers = 0; // значение октета
	char* buff = new char[3]; // буфер для одного октета

	for (int i = 0; ip_[i] != '\0'; i++)
	{ // для строки IP-адреса
		if (ip_[i] <= '9' && ip_[i] >= '0') // если цифра
		{
			if (numbers > 3) return false;
			//если больше трех чисел в октете – ошибка
			buff[numbers++] = ip_[i];
			//скопировать в буфер
		}
		else
			if (ip_[i] == '.') // если точка
			{
				if (atoi(buff) > 255)
					// проверить диапазон октета
					return false;
				if (numbers == 0)
					//если числа нет - ошибка
					return false;
				numbers = 0;
				points++;
				delete[]buff;
				buff = new char[3];
			}
			else return false;
	}
	if (points != 3)
		// если количество точек в IP-адресе не 3 - ошибка
		return false;
	if (numbers == 0 || numbers > 3)
		return false;
	return true;
}
bool СheckMask(char* mask_)
{
	int points = 0, // количество точек
		numbers = 0; // значение октета
	char* buff = new char[3]; // буфер для одного октета
	for (int i = 0; mask_[i] != '\0'; i++)
	{ // для строки IP-адреса
		if (mask_[i] <= '9' && mask_[i] >= '0') // если цифра
		{
			if (numbers > 3) return false;
			//если больше трех чисел в октете – ошибка
			buff[numbers++] = mask_[i];
			//скопировать в буфер
		}
		else
			if (mask_[i] == '.' || mask_[i] == '\0') // если точка
			{

				if (atoi(buff) > 255)
					// проверить диапазон октета
					return false;
				if (numbers == 0)
					//если числа нет - ошибка
					return false;
				numbers = 0;
				points++;
				delete[]buff;
				buff = new char[3];
			}
			else return false;
	}
	unsigned long mask = CharToLong(mask_);
	bitset<32> bytemask = (bitset<32>(mask));


	if (points != 3)
		// если количество точек в IP-адресе не 3 - ошибка
		return false;
	if (numbers == 0 || numbers > 3)
		return false;
	for (size_t i = 31; i >= 1; i--)
	{
		if (bytemask[i] == 0 && bytemask[i - 1] == 1)
			return false;

	}
	return true;

}

int main()
{
	setlocale(0, "");
	unsigned long ip, mask;//, host, subnet;
	char* ip_ = new char[16], * mask_ = new char[16]; bool flag = true;

	do
	{
		if (!flag) cout << "Неверно введён адрес!" << endl;
		cout << "IP: ";
		cin >> ip_;
	} while (!(flag = CheckAddress(ip_)));

	do
	{
		if (!flag) cout << "Неверно введена маска!" << endl;
		cout << "Mask: ";
		cin >> mask_;
	} while (!(flag = СheckMask(mask_)));



	mask = CharToLong(mask_); //Конвертация в uns. long
	ip = CharToLong(ip_); //Конвертация в uns. long

	bitset<32> byteip = (bitset<32>(ip));
	bitset<32> bytemask = (bitset<32>(mask));

	bitset<32>subnet = byteip & bytemask;		//Рассчёт адреса подсети, хоста и широковещательного адреса
	bitset<32>host = byteip & ~bytemask;
	bitset<32> broadcast = (byteip & bytemask | ~bytemask);



	bitset<8> netbyte1, netbyte2, netbyte3, netbyte4;
	bitset<8> hostbyte1, hostbyte2, hostbyte3, hostbyte4; // Для октетов адреса подсети и хоста
	bitset<8> broadcast1, broadcast2, broadcast3, broadcast4; //Для октетов широковещат. адреса

	for (int i = 31, j = 7; i >= 24; i--, j--)
	{
		netbyte1[j] = subnet[i];
		netbyte2[j] = subnet[i - 8];
		netbyte3[j] = subnet[i - 16];
		netbyte4[j] = subnet[i - 24];

		hostbyte1[j] = host[i];
		hostbyte2[j] = host[i - 8];
		hostbyte3[j] = host[i - 16];
		hostbyte4[j] = host[i - 24];

		broadcast1[j] = broadcast[i];
		broadcast2[j] = broadcast[i - 8];
		broadcast3[j] = broadcast[i - 16];
		broadcast4[j] = broadcast[i - 24];

	}
	cout << "Network ID: " << netbyte1.to_ulong() << "." << netbyte2.to_ulong() << "." << netbyte3.to_ulong() << "." << netbyte4.to_ulong() << endl;
	cout << "Host ID: " << hostbyte1.to_ulong() << "." << hostbyte2.to_ulong() << "." << hostbyte3.to_ulong() << "." << hostbyte4.to_ulong() << endl;
	cout << "Broadcast ID: " << broadcast1.to_ulong() << "." << broadcast2.to_ulong() << "." << broadcast3.to_ulong() << "." << broadcast4.to_ulong() << endl;
	system("pause");
	return 0;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
