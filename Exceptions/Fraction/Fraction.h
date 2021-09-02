#ifndef FRACTION

#define FRACTION

#include<iostream>
#include<exception>
#include<string.h>
#include<string>
#include<climits>

class Fraction
{
public:
	Fraction(int num, int denom = 1) {
		numerator = num;
		if (denom==0){
			throw std::domain_error("Знаменатель не должен быть равен нулю.");
		}
		denominator = denom;
	}
	Fraction(int num) :Fraction{ num, 1 } {}
	Fraction() :Fraction{ 0, 1 } {}

	void setNumerator();
	void setDenominator();

	int getNumerator()const {
		return numerator;
	}
	int getDenominator()const {
		return denominator;
	}

	Fraction reduceFraction();

	Fraction operator*(const Fraction &one);

	Fraction operator/(const Fraction &one);

	Fraction operator+(const Fraction &one);

	Fraction operator-(const Fraction &one);

	Fraction &operator++();

	Fraction operator++(int);

	Fraction &operator--();

	Fraction operator--(int);

	bool operator!() const;

	void PrintFraction();

	friend std::ostream &operator<<(std::ostream &out, const Fraction &one);
	friend std::istream &operator>>(std::istream &in, Fraction &fraction);

	friend bool operator==(const Fraction &one, const Fraction &two);
	friend bool operator!=(const Fraction &one, const Fraction &two);
	friend bool operator>(const Fraction &one, const Fraction &two);
	friend bool operator<(const Fraction &one, const Fraction &two);
	friend bool operator>=(const Fraction &one, const Fraction &two);
	friend bool operator<=(const Fraction &one, const Fraction &two);
private:

	int numerator;
	int denominator;

	int greatestCommonDivisor(int numberOne, int numberTwo);
	bool isNumber(char sym);
	bool isCorrectData(std::string &data);
};

#endif FRACTION