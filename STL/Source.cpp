#include <iostream>
#include <string>
#include <memory>
#include <deque>
#include <algorithm>

using Number = int;
using Year = unsigned short int;

class Address {
public:
    Address() = delete;
    Address(std::string street, Number house, Number appartment, Year age):
        street(street),
        house(house),
        appartment(appartment),
        age(age) {}
    void setStreet(std::string street) {
        this->street = street;
    }
    void setHouse(Number house) {
        this->house = house;
    }
    void setAppartment(Number appartment) {
        this->appartment = appartment;
    }
    void setAge(Year age) {
        this->age = age;
    }
    std::string getStreet() const {
        return this->street;
    }
    Number getHouse()const {
        return this->house;
    }
    Number getAppartment() const {
        return this->appartment;
    }
    Number getAge()const {
        return this->age;
    }
private:
    std::string street;
    Number house;
    Number appartment;
    Year age;
};

class Human {
public:
    Human() = delete;
    Human(std::string name, std::shared_ptr<Address> registration) :
        name(name),
        registration(registration)
    {}
    void setName(std::string name) {
        this->name = name;
    }
    void setRegistration(std::shared_ptr<Address> registration) {
        this->registration.swap(registration);
    }
    
    std::string getName()const {
        return this->name;
    }
    std::shared_ptr<Address> getRegistration()const {
        return registration;
    }

private:
    std::string name;
    std::shared_ptr<Address> registration;
};


class IssueApartmentQueue {
public:

    void AddHuman(Human &hum) {
        q.push_back(std::make_shared<Human>(hum));
    }

    void Sort() {
        std::sort(
            q.begin(),
            q.end(),
            [](std::shared_ptr<Human> A, std::shared_ptr<Human> B)->bool {
                return A->getRegistration()->getAge() < B->getRegistration()->getAge();
            }
        );
    }
    void PrintQ(){
        int k{ 0 };
        for (auto &human : q) {
            k++;
            std::cout << k << ". " << human->getName() << ", Year of hous construction: "<< human->getRegistration()->getAge() <<"\n";
        }
    }
    void IssueApartment(int value) {
        try {
            if (q.empty()) throw "\nQueue is empty!\n";
            if (value < 0) throw "\nNumber should be >=0!\n";
            
            int k{ 0 };
            for (size_t i = 0; i <q.size(); i++) {
                if (k == value) {
                    break;
                }
                q.at(i)->getRegistration()->setAge(2021);
                k++;
            }
        }
        catch (const char *e) { std::cout << e << "\n"; }
    }
private:
    std::deque<std::shared_ptr<Human>> q;
};

int main()
{
    Human first("Vasiliy", std::make_shared<Address>("Plushkina", 12, 2, 2003));
    Human second("Adam", std::make_shared<Address>("Bublickovaja", 65, 189, 1987));
    Human third("Sofja", std::make_shared<Address>("Tortikovaja", 74, 9, 1998));
    Human fourth("Pavla", std::make_shared<Address>("Pechenkina", 78, 5, 1957));
    Human fifth("Tom", std::make_shared<Address>("Krekernaja", 23, 98, 2010));
    
    IssueApartmentQueue que;
    que.AddHuman(first);
    que.AddHuman(second);
    que.AddHuman(third);
    que.AddHuman(fourth);
    que.AddHuman(fifth);
    que.Sort();
    std::cout << "Sorted list of people: \n";
    que.PrintQ();
    std::cout << "Enter the number of issued apartments: \n";

    int volume{ 0 };
    std::cin >> volume;

    que.IssueApartment(volume);
    std::cout << "Sorted list of people after issue apartments: \n";
    que.Sort();
    que.PrintQ();
}