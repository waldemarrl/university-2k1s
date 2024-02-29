#include <iostream>
using namespace std;

int power(int a, int b, int n) { 
    int temp = a;
    int sum = temp;
    for (int i = 1; i < b; i++) {
        for (int j = 1; j < a; j++) {
            sum += temp;
            if (sum >= n) {
                sum -= n;
            }
        }
        temp = sum;
    }
    return temp;
}


void rsa()
{
    int p = 17, q = 5, eiler, e = 3, n, key1 = 10, key2, c, d, s;
    cout << "p = " << p << endl;
    cout << "q = " << q << endl;
    n = p * q;
    eiler = (p - 1) * (q - 1);
    cout << "Модуль:" << n << endl;
    cout << "Функция Эйлера: " << eiler << endl;
    cout << "Открытая экспонента: " << e << endl;
    d = power(e, -1, eiler);
    d = 43;
    cout << "Секретная экспонента: " << d << endl;
    cout << "Открытый ключ: {" << e << ", " << n << "}" << endl;
    cout << "Закрытый ключ: {" << d << ", " << n << "}" << endl << endl;
    cout << "Число для зашифровки: " << key1 << endl;
    c = power(key1, e, n);
    cout << "Шифротекст: " << c << endl;
    cout << "Расшифровка: " << power(c, d, n) << endl; 
    s = power(key1, d, n); 
    key2 = power(s, e, n); 
    if (key1 == key2)
    {
        cout << "Подпись правильная" << endl;
    }
    else
    {
        cout << "Подпись неправильная" << endl;
    }
}


int main() {
    setlocale(LC_ALL, "rus");
    rsa();

}