#include "String.h"

int main() {
	setlocale(LC_ALL, "rus");
	try{
		std::cout << "������ ����:\n";
		BitString bit("0101011011");
		std::cout << bit << std::endl;
		std::cout << "������ ���:\n";
		BitString bit2("1001000001");
		std::cout << bit2 << std::endl;

		BitString bit3(bit);
		~bit3;
		String *str3 = &bit3;
		std::cout << "������ ���, �������� ������ 1:\n";
		std::cout << *str3 << std::endl;

		std::cout << "������ ��� � ���������� ������� ���������:\n";
		std::cout << static_cast<int>(*str3) << "\n";

		std::cout << "������ ������ = ������ ���� & ������ ���:\n";
		BitString bit4(bit & bit2);
		std::cout << bit4 << std::endl;

		std::cout << "������ ���� = ������ ���� ^ ������ ���:\n";
		BitString bit5(bit ^ bit2);
		String str5 = bit5;
		std::cout << str5 << std::endl;

		std::cout << "��������� ����� ������ ���� ����� �� 5 ���������:\n";
		bit5 << 5;
		std::cout << bit5 << std::endl;

		std::cout << "-----------------------------------------------\n";
		
		//������� �������, � ������� ���������� ����������
		String str6(-45);//"������ ������ �� ����� ���� ������������� ������."
		String str7(6587876387465834);//"������ �� ��������."
		String str8("u");
		--str8;
		--str8;//"������� �������� ������ ��� ���������� ����������."
		std::cout << str8[77];//"�������� � ������ �������� �� ����������."
		BitString bit6("dfgkjdfhg");//"������� ������ ������ ��������� '0' ��� '1'."
		BitString bit7("1101");
		BitString bit8("111111");
		std::cout << (bit7 & bit8) << "\n";//"������ ������ ���� ������ �������."
		bit8 << -87; //"���������� ������� ������ ���� ������������� ������."
	}
	catch (const std::length_error &ex){
		std::cerr << ex.what() << "\n";
	}
	catch (const std::bad_alloc &ex) {
		std::cerr << "������ �� ��������." << "\n";
	}
	catch (const std::domain_error &ex) {
		std::cerr << ex.what() << "\n";
	}
	catch (const std::invalid_argument &ex) {
		std::cerr << ex.what() << "\n";
	}
	catch (const std::out_of_range &ex) {
		std::cerr << ex.what() << "\n";
	}

	return 0;
}