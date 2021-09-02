#include "Fraction.h"

void Fraction::setNumerator() {
	std::string tempNum;
	std::cin >> tempNum;

	if (isCorrectData(tempNum)) {
		numerator = std::stoi(tempNum);
	}
}

void Fraction::setDenominator() {
	std::string tempDenom;
	std::cin >> tempDenom;

	if (tempDenom == "0") {
		throw std::domain_error("Знаменатель не должен быть равен нулю.");
	}
	if (isCorrectData(tempDenom)) {
		denominator = std::stoi(tempDenom);
	}
}

Fraction Fraction::reduceFraction() {
	int temp = greatestCommonDivisor(numerator, denominator);
	if (temp != 1) {
		numerator /= temp;
		denominator /= temp;
	}
	return Fraction(numerator, denominator);
}

Fraction Fraction::operator*(const Fraction &one) {
	return Fraction(numerator * one.numerator, denominator * one.denominator);
}

Fraction Fraction::operator/(const Fraction &one) {
	return Fraction(numerator * one.denominator, denominator * one.numerator);
}

Fraction Fraction::operator+(const Fraction &one) {
	int commonDenominator{ denominator * one.denominator };
	int commonNumerator{ numerator * one.denominator + one.numerator * denominator };
	return Fraction(commonNumerator, commonDenominator);
}

Fraction Fraction::operator-(const Fraction &one) {
	int commonDenominator{ denominator * one.denominator };
	int commonNumerator{ numerator * one.denominator - one.numerator * denominator };
	return Fraction(commonNumerator, commonDenominator);
}

Fraction &Fraction::operator++() {
	numerator += denominator;
	return *this;
}

Fraction Fraction::operator++(int) {
	Fraction temp(numerator, denominator);
	++(*this);
	return temp;
}

Fraction &Fraction::operator--() {
	numerator -= denominator;
	return *this;
}

Fraction Fraction::operator--(int) {
	Fraction temp(numerator, denominator);
	--(*this);
	return temp;
}

void Fraction::PrintFraction() {
	if (numerator == 0) {
		std::cout << numerator << "\n";
	}
	else {
		if (denominator == 1) {
			std::cout << numerator << "\n";
		}
		else {
			std::cout << numerator << "/" << denominator << "\n";
		}
	}
}

int Fraction::greatestCommonDivisor(int numberOne, int numberTwo) {
	int temp;
	while (numberTwo > 0) {
		temp = numberOne % numberTwo;
		numberOne = numberTwo;
		numberTwo = temp;
	}
	return numberOne;
}

bool Fraction::isNumber(char sym) {
	if (sym>='0'&&sym<='9'){
		return true;
	}
	else{
		return false;
	}
}

bool Fraction::isCorrectData(std::string &data) {
	
	int maxRank{ 11 };
	if (data.length()>maxRank){
		throw std::domain_error("Слишком большое число.");
	}
	for (int i = 0; i < data.length(); i++) {
		if (!(isNumber(data[i]))) {
			if (data[0] == '-') {
				continue;
			}
			throw std::invalid_argument("Целое число не должно содержать посторонние символы.");
		}
	}
	if (std::stoll(data) > INT_MAX) {
		throw std::domain_error("Слишком большое число.");
	}
	return true;
}

std::ostream &operator<<(std::ostream &out, const Fraction &fraction) {
	if (fraction.denominator == 1) {
		out << fraction.numerator << "\n";
	}
	else {
		out << fraction.numerator << "/" << fraction.denominator << "\n";
	}
	return out;
}

std::istream &operator>>(std::istream &in, Fraction &fraction) {
	std::string tempNum;
	in >> tempNum;
	
	if (fraction.isCorrectData(tempNum)){
		fraction.numerator = std::stoi(tempNum);
	}
	
	std::string tempDenom;
	in >> tempDenom;

	if (tempDenom =="0"){
		throw std::domain_error("Знаменатель не должен быть равен нулю.");
	}
	if (fraction.isCorrectData(tempDenom)) {
		fraction.denominator = std::stoi(tempDenom);
	}

	return in;
}

bool Fraction::operator!() const {
	return (numerator == 0 && denominator == 1);
}

bool operator==(const Fraction &one, const Fraction &two) {
	return (one.numerator * two.denominator) == (two.numerator * one.denominator);
}

bool operator!=(const Fraction &one, const Fraction &two) {
	return !(one == two);
}

bool operator>(const Fraction &one, const Fraction &two) {
	return (one.numerator * two.denominator) > (two.numerator * one.denominator);
}

bool operator<(const Fraction &one, const Fraction &two) {
	return (one.numerator * two.denominator) < (two.numerator * one.denominator);
}

bool operator>=(const Fraction &one, const Fraction &two) {
	return (one.numerator * two.denominator) >= (two.numerator * one.denominator);
}

bool operator<=(const Fraction &one, const Fraction &two) {
	return (one.numerator * two.denominator) <= (two.numerator * one.denominator);
}
