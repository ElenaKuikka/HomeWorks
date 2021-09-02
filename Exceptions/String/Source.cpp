#include "String.h"

int main() {
	setlocale(LC_ALL, "rus");
	try{
		std::cout << "Строка один:\n";
		BitString bit("0101011011");
		std::cout << bit << std::endl;
		std::cout << "Строка два:\n";
		BitString bit2("1001000001");
		std::cout << bit2 << std::endl;

		BitString bit3(bit);
		~bit3;
		String *str3 = &bit3;
		std::cout << "Строка три, обратная строке 1:\n";
		std::cout << *str3 << std::endl;

		std::cout << "Строка три в десятичной системе счисления:\n";
		std::cout << static_cast<int>(*str3) << "\n";

		std::cout << "Строка четыре = строка один & строка два:\n";
		BitString bit4(bit & bit2);
		std::cout << bit4 << std::endl;

		std::cout << "Строка пять = строка один ^ строка два:\n";
		BitString bit5(bit ^ bit2);
		String str5 = bit5;
		std::cout << str5 << std::endl;

		std::cout << "Побитовый сдвиг строки пять влево на 5 элементов:\n";
		bit5 << 5;
		std::cout << bit5 << std::endl;

		std::cout << "-----------------------------------------------\n";
		
		//Примеры случаев, в которых вызываются исключения
		String str6(-45);//"Размер строки не может быть отрицательным числом."
		String str7(6587876387465834);//"Память не выделена."
		String str8("u");
		--str8;
		--str8;//"Слишком короткая строка для выполнения декремента."
		std::cout << str8[77];//"Элемента с данным индексом не существует."
		BitString bit6("dfgkjdfhg");//"Битовая строка должна содержать '0' или '1'."
		BitString bit7("1101");
		BitString bit8("111111");
		std::cout << (bit7 & bit8) << "\n";//"Строки должны быть одного размера."
		bit8 << -87; //"Количество сдвигов должно быть положительным числом."
	}
	catch (const std::length_error &ex){
		std::cerr << ex.what() << "\n";
	}
	catch (const std::bad_alloc &ex) {
		std::cerr << "Память не выделена." << "\n";
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