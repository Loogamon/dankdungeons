#include <iostream>
#include <string>
#include <vector>
#include "dankdungeons.h"
using namespace std;
#undef UNICODE

void add_monster(vector<monster> * monlist_arg, string m_name, int m_hp, int m_atk, int m_exp, int m_gold)
{
	monster monste;
	monste.name = m_name;
	monste.hp = m_hp;
	monste.atk = m_atk;
	monste.exp = m_exp;
	monste.gold = m_gold;
	monlist_arg->push_back(monste);
}

void set_monsters(vector<monster> * v)
{
	add_monster(v, "Ghost", 3, 1, 100, 25);
	add_monster(v, "Imp", 5, 2, 125, 35);
	add_monster(v, "Mummy", 12, 1, 320, 120);
	add_monster(v, "Dragon", 25, 12, 1000, 5000);
	add_monster(v, "Dark Mage", 20, 7, 750, 215);
	add_monster(v, "Dark Knight", 32, 20, 432, 562);
	add_monster(v, "Tiger", 40, 40, 820, 450);
	add_monster(v, "Centaur", 32, 100, 4500, 3200);
	add_monster(v, "Dark King", 80, 128, 6500, 7500);
	add_monster(v, "Demon Lord", 1000, 95, 10000, 10000);
	add_monster(v, "Kass", 5000, 5000, 50000, 50000);
}

void set_reactions(vector<string> * v)
{
	v->push_back("Yikes");
	v->push_back("Ah!");
	v->push_back("Jinkies!");
	v->push_back("Oh boy!");
	v->push_back("Argh!");
	v->push_back("Woah!");
	v->push_back("Oh no!");
	v->push_back("Great...");
}

void set_paths1(vector<string> * v)
{
	v->push_back("Stinky");
	v->push_back("Strange");
	v->push_back("Colorful");
	v->push_back("Wonderous");
	v->push_back("Puzzling");
	v->push_back("Silly");
	v->push_back("Perplexing");
	v->push_back("Spooky");
	v->push_back("Bland");
	v->push_back("Cold");
	v->push_back("Hot");
	v->push_back("Mysterious");
}

void set_paths2(vector<string> * v)
{
	v->push_back("Hallway");
	v->push_back("Terrance");
	v->push_back("Atrium");
	v->push_back("Patio");
	v->push_back("Shrine");
	v->push_back("Forest");
	v->push_back("Sewers");
	v->push_back("Engine Room");
	v->push_back("Studio");
	v->push_back("Kitchen");
	v->push_back("Bathroom");
	v->push_back("Balcony");
}

void set_items(vector<string> * v)
{
	v->push_back("Potion");
	v->push_back("Elixir");
	v->push_back("Sword");
	v->push_back("Smoke Ball");
	v->push_back("Stronger Potion");
	v->push_back("Stronger Elixir");
	v->push_back("Stronger Sword");
	v->push_back("Death Sword");
}