// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>

static void updateID(uint8_t* idstr, uint32_t id)
{
	int n;
	idstr[0] = 7;
	for (n = 2; n < 9; n++) {
		idstr[n] = 0x30 + (id & 0x1f);
		id >>= 5;  //Right shifts bits of id by 5 and stores the result in id.
	}
}

int main()
{
	uint32_t hsh = 0x474E5253L;
	uint8_t result[9] = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };  // Initialize with spaces
	uint32_t mlOwnId = 0x9E467A86;

	printf("Initial Hash : 0x%x\n", hsh);
	printf("Initial OwnID: 0x%x\n", mlOwnId);

	updateID(result, hsh ^ mlOwnId);  // ^ is bitwise XOR

    std::cout << "Updated ID:\n";

	int n;
	for (n = 0; n < 9; n++) {
		printf("0x%x ", result[n]);
	}

	std::cout << "\n\nPress Enter to continue.\n";
	std::string buf;
	std::getline(std::cin, buf);
	return 0;
}
