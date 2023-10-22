#include <string>
#include <vector>
using namespace std;

#ifndef DD_GAMEHEADER
#define DD_GAMEHEADER
struct monster{
	string name;
	int hp;
	int atk;
	int exp;
	int gold;
};
int input_int();
string find_replace_all(string str, string substr, string newstr);
//
void add_monster(vector<monster> * monlist_arg, string m_name, int m_hp, int m_atk, int m_exp, int m_gold);
void set_monsters(vector<monster> * v);
void set_reactions(vector<string> * v);
void set_paths1(vector<string> * v);
void set_paths2(vector<string> * v);
void set_items(vector<string> * v);
#endif