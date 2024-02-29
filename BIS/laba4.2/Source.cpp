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
    cout << "������:" << n << endl;
    cout << "������� ������: " << eiler << endl;
    cout << "�������� ����������: " << e << endl;
    d = power(e, -1, eiler);
    d = 43;
    cout << "��������� ����������: " << d << endl;
    cout << "�������� ����: {" << e << ", " << n << "}" << endl;
    cout << "�������� ����: {" << d << ", " << n << "}" << endl << endl;
    cout << "����� ��� ����������: " << key1 << endl;
    c = power(key1, e, n);
    cout << "����������: " << c << endl;
    cout << "�����������: " << power(c, d, n) << endl; 
    s = power(key1, d, n); 
    key2 = power(s, e, n); 
    if (key1 == key2)
    {
        cout << "������� ����������" << endl;
    }
    else
    {
        cout << "������� ������������" << endl;
    }
}


int main() {
    setlocale(LC_ALL, "rus");
    rsa();

}