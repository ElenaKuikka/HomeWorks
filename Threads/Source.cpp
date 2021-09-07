#include<iostream>
#include<list>
#include<vector>
#include<set>
#include<thread>
#include<typeinfo>
#include<time.h>
#include<algorithm>
#include<mutex>


std::mutex mtx;

template<class T>
class PrintCollection {
public:

	void operator()(T &collection) {
		std::lock_guard<std::mutex>guard(mtx);
		
		for (auto &element:collection){
			std::cout << "Thread " << std::this_thread::get_id() << " " << typeid(collection).name() << " "<< element << "\n";
		}
		std::cout << "-----------------------------------------------------\n";
	}

};


int main() {
	std::cout << "Main thread: " << std::this_thread::get_id() << "\n";
	srand(time(NULL));
	
	std::list<int> listColl;
	for (int i = 0; i < 1000; i++) {
		listColl.push_back(rand()%1000);
	}

	std::set<int> setColl;
	for (int i = 0; i < 1000; i++) {
		setColl.insert(-rand() % 1000);
	}

	std::vector<char> vectorColl;
	for (int i = 0; i < 1000; i++) {
		vectorColl.push_back(65+rand() % 26);
	}

	PrintCollection<std::list<int>> printList;
	std::thread thList([&listColl, &printList]() {
		listColl.sort();
		printList(listColl);
		});

	PrintCollection<std::set<int>> printSet;
	std::thread thSet([&setColl, &printSet]() {
		printSet(setColl);
		});

	PrintCollection<std::vector<char>> printVector;
	std::thread thVector([&vectorColl, &printVector]() {
		std::sort(vectorColl.begin(), vectorColl.end());
		printVector(vectorColl);
		});


	thList.join();
	thSet.join();
	thVector.join();

	return 0;
}