#include <iostream>
#include <string>
#include <sstream>
#include "dankdungeons.h"
using namespace std;
#undef UNICODE

int input_int()
{
	char input[512];
	std::string line;
	int d;
	int wait=1;
	while (wait)
	{
		cin.getline(input, sizeof(input));
		//something = input;
		std::stringstream ss(input);

		if (ss >> d)
		{
			if (ss.eof())
			{   // Success
				break;
			}
		}
		else
			{
				d=-2;
				break;
			}
	}
	return d;
}

string find_replace_all(string str, string substr, string newstr)
{
	int pos;
	string nstr = str;
	while (nstr.find(substr) != string::npos)
	{
		pos = nstr.find(substr);
		nstr.replace(pos, substr.length(), newstr);
	}
	return nstr;
}