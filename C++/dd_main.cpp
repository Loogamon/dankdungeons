#include <iostream>
#include <string>
#include <vector>
#include <time.h>
#include <sstream>
#include "dankdungeons.h"
using namespace std;
#undef UNICODE

int main()
{
	string temp_str;
	string GAME_NAME = "Dank Dungeons C++";
	char tmp_cstr[512];
	srand(time(NULL));
	int mode = 0;
	string item = "---"; //Items use "---" to represent an empty item slot.
	int no_mon = 0; //No enemy will be generated.
	int err = 0; //Flow controls if there's an input error.
	int num_paths = 2; //Number of Paths to enter
	int floor_num = 1; //Current Floor
	int lvl = 1; //Current Level
	int current_hp = 10; //HP
	int max_hp = 10; //Maximum HP
	int current_mp = 10; //MP
	int max_mp = 10; //Maximum MP
	int gold = 500; //Gold. Unused.
	int game_off = 0; //Game is off? Used to break game loop.
	int in_p = -1; //Variable for input choice.
	int current_mode = 0; //Current game mode. 0=Dungeon, 1=Battle
	int max_num = 1; //Maximum number of choices.
	int min_num = 1; //Minimum number of choices.
	int monsters = 0; //Number of monsters in the paths.
	vector<string> loc_names;
	vector<string> mon_locs;
	for (int i=0; i < 30; i++)
	{
		loc_names.push_back("");
		mon_locs.push_back("");
	}

	int monster_find = 0;
	vector<monster> mon_data; set_monsters(&mon_data);
	vector<string> reactions; set_reactions(&reactions);
	vector<string> path_name1; set_paths1(&path_name1);
	vector<string> path_name2; set_paths2(&path_name2);
	vector<string> item_name; set_items(&item_name);

	int fight_mon = 0; //Monster identifer
	int mon_hp = 0; //Monster's HP
	int mon_maxhp = 0; //Monster's Maxmium HP
	string battle_str = ""; //String used to print battle text.
	int exp = 0; //EXP.
	int next_lvl = 100; //Ammount of EXP needed to reach the next level.
	int mon_range = 10; //Number of monster types allowed to appear.
	int item_range = 1; //Number of item types allowed to appear.
	string output_str = ""; 
	int startit = 0;
	int input = 0;

	int score_floor=0;
	int	score_lvl=0;
	FILE * savefile;

	system("cls");
	std::cout << "(To exit the program loop, input a negative number.)\r\n\r\n";
	string kass_str="";
	std::stringstream ss;
	while (input >= 0)
	{
		kass_str = "";
		switch (mode)
		{
		case 0: //Title Screen/Start
			kass_str += "----------\r\nDank Dungeons -- Game by Loogamon\r\nPython Original: 4/30/17 - 5/2/17\r\nC# Ver: 5/19/18 - 5/20/18\r\nC# GUI Ver: 11/28/18\r\nC++ Ver: 7/9/22 - 7/10/22\r\n----------\r\n";
			//Reset Game Values
			item = "---"; //Items use "---" to represent an empty item slot.
			no_mon = 0; //No enemy will be generated.
			err = 0; //Flow controls if there"s an input error.
			num_paths = 2; //Number of Paths to enter
			floor_num = 1; //Current Floor
			lvl = 1; //Current Level
			current_hp = 10; //HP.
			max_hp = 10; //Maximum HP.
			current_mp = 10; //MP.
			max_mp = 10; //Maximum MP.
			gold = 500; //Gold. Unused.
			game_off = 0; //Game is off? Used to break game loop.
			in_p = -1; //Variable for input choice.
			current_mode = 0; //Current game mode. 0=Dungeon, 1=Battle
			max_num = 1; //Minimum number of choices.
			min_num = 1; //Maximum number of choices.
			monsters = 0; //Number of monsters in the paths.
			monster_find = 0; //Monster is found?
			int z;
			for (z = 0; z < 30; z++)
			{
				//Console.WriteLine(z);
				loc_names[z] = "";
				mon_locs[z] = "";
				loc_names[z] = "{a1} {a2}";
				loc_names[z] = find_replace_all(loc_names[z], "{a1}", path_name1[rand() % path_name1.size()]);
				loc_names[z] = find_replace_all(loc_names[z], "{a2}", path_name2[rand() % path_name2.size()]);
			}
			fight_mon = 0; //Monster indentifer
			mon_hp = 0; //Monster"s HP
			mon_maxhp = 0; //Monster"s Maximum HP.
			battle_str = ""; //String used to print battle text.
			exp = 0; //EXP.
			next_lvl = 100; //Ammount of EXP needed to reach the next level.
			mon_range = 10; //Number of monster types allowed to appear.
			mon_range = 1; //
			item_range = 7;//Number of item types allowed to appear.
			item_range = 1; //
			num_paths = rand() % (6 + 1);
			if (num_paths < 1)
				num_paths = 1;
			//
			savefile = fopen("dd_gamesave.sav", "r");
			if (savefile != NULL)
			{
				string myscore_str;
				
				int test=0;
				fgets(tmp_cstr, sizeof(tmp_cstr), savefile);
				score_floor = atoi(tmp_cstr);
				fgets(tmp_cstr, sizeof(tmp_cstr), savefile);
				score_lvl = atoi(tmp_cstr);
				
				myscore_str = "High Score: Floor {floor} | LVL. {lvl}\r\n";
				ss.str(""); ss.clear();  ss << score_floor; temp_str=ss.str();
				myscore_str = find_replace_all(myscore_str, "{floor}", temp_str);
				ss.str(""); ss.clear();  ss << score_lvl; temp_str=ss.str();
				myscore_str = find_replace_all(myscore_str, "{lvl}", temp_str);
				
				kass_str += myscore_str;
				fclose(savefile);
			}
			kass_str += "Please input a number to continue.\r\n";
			break;
		case (1) :
			in_p = input;
			err = 0;
			if (in_p == 0) err = 2;
			if (err == 0)
			{
				if (in_p > max_num) err = 1;
				if (in_p < 1) err = 1;
			}
			battle_str = "";
			if (err == 2 && current_mode == 0 && in_p == 0 && item != "---" && mode == 1)
			{
				battle_str += "Discarded " + item + ".\r\n---\r\n";
				item = "---";
				no_mon = 1;
			}
			if (err == 0)
			{
				if (current_mode == 0 && in_p > 0 && mode == 1)
				{
					int chest;
					chest = rand() % (10000 + 1);
					if (chest < 5000)
					{
						no_mon = 1;
						if (item == "---")
						{
							item = item_name[rand() % (item_range + 1)];
							battle_str += "A chest was found!\r\nIt contains " + item + ".\r\n---\r\n";
						}
						else
							battle_str += "A chest was found!\r\nBut you already have an item...\r\n---\r\n";
					}
					int nextfloor;
					nextfloor = rand() % (10000 + 1);
					if (nextfloor < 1500)
					{
						floor_num += 1;
						ss.str(""); ss.clear();  ss << "A staircase was found!\r\nI'm now on Floor " << floor_num << "!\r\nBetter rewards, but stronger enemies will be coming!\r\n---\r\n"; temp_str=ss.str();
						battle_str += temp_str;
						if (floor_num == 2 || floor_num == 5 || floor_num == 7 || floor_num >= 10)
							mon_range += 1;
						if (mon_range > 8)
							mon_range = 8;
						if (floor_num > 99)
							mon_range = 10;
						item_range += 1;
						if (item_range >= 7)
							item_range = 7;
						if (mon_range > 10)
							mon_range = 10;
						no_mon = 1;
					}
					monster_find = 0;
					num_paths = rand() % (6 + 1);
					if (num_paths < 1)
						num_paths = 1;
					for (int abc = 0; abc < 30; abc++)
					{
						loc_names[abc] = "{a1} {a2}";
						loc_names[abc] = find_replace_all(loc_names[abc], "{a1}", path_name1[rand() % path_name1.size()]);
						loc_names[abc] = find_replace_all(loc_names[abc], "{a2}", path_name2[rand() % path_name2.size()]);
					}
					monsters = rand() % (num_paths + 1);
					if (monsters < 0)
						monsters = 0;
					for (z = 0; z < 30; z++)
					{
						mon_locs[z] = "";
					}
					for (z = 0; z < monsters; z++)
					{
						int good;
						int zx;
						good = 0;
						zx = -1;
						while (good == 0)
						{
							zx = rand() % num_paths;
							good = 1;
							for (int mon_check = 0; mon_check < 10; mon_check++)
							{
								ss.str(""); ss.clear();  ss << zx; temp_str=ss.str();
								if (mon_locs[mon_check] == temp_str)
									good = 0;
							}
						}
						ss.str(""); ss.clear();  ss << z; temp_str=ss.str();
						if (zx != -1)
							mon_locs[zx] = temp_str;
					}
				}
				if (current_mode == 1 && mode == 1)
				{
					if (in_p == 1)
					{
						mon_hp -= 1 * lvl;
						ss.str(""); ss.clear(); ss << "I attacked!\r\n" << mon_data[fight_mon].name << " took " << (1 * lvl) << " damage!\r\n---\r\n"; temp_str=ss.str();
						battle_str += temp_str;
					}
					if (in_p == 2)
					{
						if (current_mp >= 5)
						{
							current_mp -= 5;
							if (current_mp < 0) current_mp = 0;
							mon_hp -= 2 * lvl;
							ss.str(""); ss.clear(); ss << "I casted my magic!\r\n" << mon_data[fight_mon].name << " took " << (2 * lvl) << " damage!\r\n---\r\n"; temp_str=ss.str();
							battle_str += temp_str;
						}
						else
							battle_str += "I don't have enough MP to use magic!\r\n---\r\n";
					}
					if (in_p == 3)
					{
						if (item == "---")
							battle_str += "I don't have an item to use!\r\n---\r\n";
						if (item == "Potion")
						{
							battle_str += "I recovered 10 HP!\r\n---\r\n";
							current_hp += 10;
						}
						if (item == "Elixir")
						{
							battle_str += "I recovered 10 MP!\r\n---\r\n";
							current_mp += 10;
						}
						if (item == "Sword")
						{
							battle_str += "The Sword shines!\r\n";
							mon_hp -= 3 * lvl;
							ss.str(""); ss.clear(); ss << mon_data[fight_mon].name << " took " << (3 * lvl) << " damage!\r\n---\r\n"; temp_str=ss.str();
							battle_str += temp_str;
						}
						if (item == "Smoke Ball")
						{
							battle_str += "Poof!\r\nI escaped successfully!\r\n---\r\n";
							current_mode = 0;
						}
						if (item == "Stronger Potion")
						{
							battle_str += "I recovered 30 HP!\r\n";
							current_hp += 30;
						}
						if (item == "Stronger Elixir")
						{
							battle_str += "I recovered 30 MP!\r\n";
							current_mp += 30;
						}
						if (item == "Stronger Sword")
						{
							battle_str += "The Stronger Sword shines!\r\n";
							mon_hp -= 5 * lvl;
							ss.str(""); ss.clear(); ss << mon_data[fight_mon].name << " took " << (5 * lvl) << " damage!\r\n---\r\n"; temp_str=ss.str();
							battle_str += temp_str;
						}
						if (item == "Death Sword")
						{
							battle_str += "The Death Sword emblazes in a dark aura!\r\n---\r\n";
							if (mon_data[fight_mon].name == "Kass")
							{
								battle_str += "No! Kass is too powerful!\r\n---\r\n";
							}
							else
							{
								mon_hp = 0;
							}
						}
						item = "---";
						if (current_hp > max_hp) current_hp = max_hp;
						if (current_mp > max_mp) current_mp = max_mp;
					}
					if (in_p == 4)
					{
						int escape;
						escape = rand() % (100+1);
						if (escape < 50)
						{
							battle_str += "I escaped successfully!\r\n---\r\n";
							current_mode = 0;
						}
						else
							battle_str += "Escape failed!\r\n---\r\n";
					}
					if (current_mode == 1)
					{
						if (mon_hp <= 0)
						{
							mon_hp = 0;
							exp += mon_data[fight_mon].exp;
							ss.str(""); ss.clear(); ss << "Victory!\r\n" << mon_data[fight_mon].name << " was defeated!\r\n" << mon_data[fight_mon].exp << " EXP was obtained!\r\n---\r\n"; temp_str=ss.str();
							battle_str += temp_str;
							if (exp > next_lvl)
							{
								lvl += 1;
								double calc;
								calc = max_hp * 1.5;
								max_hp = (int)calc;
								calc = max_mp * 1.5;
								max_mp = (int)calc;
								current_hp = max_hp;
								current_mp = max_mp;
								ss.str(""); ss.clear(); ss << "Level Up!\r\nMy level is now at Level " << lvl << "!\r\nHP can now be up to "<< max_hp << "!\r\nMP can now be up to " << max_mp << "!\r\nHP and MP is fully recovered!\r\n---\r\n"; temp_str=ss.str();
								battle_str += temp_str;
								next_lvl *= 2;
							}
							mon_hp = 0;
							current_mode = 0;
						}
						else
						{
							double calc;
							int damage;
							double mon_attack;
							mon_attack = mon_data[fight_mon].atk;
							calc = mon_attack / (double)lvl;
							damage = (int)calc;
							current_hp -= damage;
							ss.str(""); ss.clear(); ss << mon_data[fight_mon].name << " attacked!\r\nI took " << damage << " damage!\r\n---\r\n"; temp_str=ss.str();
							battle_str += temp_str;
							if (current_hp <= 0)
							{
								current_hp = 0;
								ss.str(""); ss.clear(); ss << battle_str << "I'm dead...\r\nGame Over!\r\n---\r\n"; temp_str=ss.str();
								output_str += temp_str;
								game_off = 1;
								mode = -1;
								int score_floor;
								int score_lvl;
								int score_total;
								score_floor = 0;
								score_lvl = 0;
								score_total = 0;
								savefile = fopen("dd_gamesave.sav", "r");
								if (savefile != NULL)
								{
									fgets(tmp_cstr, sizeof(tmp_cstr), savefile);
									score_floor = atoi(tmp_cstr);
									fgets(tmp_cstr, sizeof(tmp_cstr), savefile);
									score_lvl = atoi(tmp_cstr);
									score_total = score_floor * score_lvl;
									fclose(savefile);
								}
								int my_score;
								my_score = lvl * floor_num;
								if (my_score > score_total)
								{
									ss.str(""); ss.clear(); ss << "Congrats! You made the high score!\r\nFloor: " << floor_num << " | LVL. " << lvl << "\r\n"; temp_str=ss.str();
									output_str += temp_str;
									savefile = fopen("dd_gamesave.sav", "w");
									if (savefile != NULL)
									{
										ss.str(""); ss.clear(); ss << floor_num << "\n"; temp_str=ss.str();
										fputs(temp_str.c_str(), savefile);
										ss.str(""); ss.clear(); ss << lvl << "\n"; temp_str=ss.str();
										fputs(temp_str.c_str(), savefile);
										fclose(savefile);
									}
								}

							}
						}
					}

				}
			}
			ss.str(""); ss.clear(); ss << "Floor " << floor_num << "\r\n"; temp_str=ss.str(); output_str += temp_str;
			ss.str(""); ss.clear(); ss << "HP: " << current_hp << "/" << max_hp << " | "; temp_str=ss.str(); output_str += temp_str;
			ss.str(""); ss.clear(); ss << "MP: " << current_mp << "/" << max_mp << " | "; temp_str=ss.str(); output_str += temp_str;
			ss.str(""); ss.clear(); ss << "LVL. " << lvl << "\r\n----------\r\n"; temp_str=ss.str(); output_str += temp_str;
			if (monster_find == 0 && current_mode == 0 && no_mon == 0 && mode == 1)
			{
				monster_find = 1;
				fight_mon = rand() % (mon_range + 1); //RND: 0 - mon_range
				int oan;
				oan = in_p;
				if (oan < 0) oan = 0;
				if (oan > 20) oan = 20;
				if (mon_locs[oan] != "")
				{
					output_str += reactions[rand() % reactions.size()];
					ss.str(""); ss.clear(); ss << " A monster!\r\n" << mon_data[fight_mon].name << " appeared!\r\n---\r\n"; temp_str=ss.str();
					output_str += temp_str;
					mon_hp = mon_data[fight_mon].hp;
					mon_maxhp = mon_data[fight_mon].hp;
					current_mode = 1;
				}
			}
			if (no_mon == 1)
				no_mon = 0;
			if (current_mode == 0 && mode == 1)
			{
				if (num_paths > 1)
				{
					output_str += battle_str;
					ss.str(""); ss.clear(); ss << "The path splits into " << num_paths << "...\r\nWhich path I should take?\r\n---\r\n"; temp_str=ss.str();
					output_str += temp_str;
					if (item != "---")
					{
						ss.str(""); ss.clear(); ss << "0 - Discard Item [" << item << "]\r\n"; temp_str=ss.str();
						output_str += temp_str;
					}
					for (int i = 0; i < num_paths; i++)
					{
						ss.str(""); ss.clear(); ss << (i + 1) << " - " << loc_names[i] << "\r\n"; temp_str=ss.str();
						output_str += temp_str;
					}
				}
				else
				{
					output_str += battle_str;
					ss.str(""); ss.clear(); ss << "There is only one path...\r\nIt leads to " << loc_names[0] << ".\r\nProceed?\r\n---\r\n"; temp_str=ss.str();
					output_str += temp_str;
					if (item != "---")
					{
						ss.str(""); ss.clear(); ss << "0 - Discard Item [" << item << "]\r\n"; temp_str=ss.str();
						output_str += temp_str;
					}
					output_str += "1 - Move further.\r\n";
				}
				max_num = num_paths;
			}
			if (current_mode == 1 && mode == 1)
			{
				output_str += battle_str;
				output_str += mon_data[fight_mon].name;
				ss.str(""); ss.clear(); ss << "\r\nHP: " << mon_hp << "/" << mon_maxhp << "\r\n"; temp_str=ss.str(); output_str += temp_str;
				ss.str(""); ss.clear(); ss << "1 - Attack\r\n2 - Magic\r\n3 - Use Item [" << item << "]\r\n4 - Escape\r\n"; temp_str=ss.str(); output_str += temp_str;
				max_num = 4; //There's only 4 options in Battle Mode regardless of the situation, so therefore you can't use any number greater than 4 nor any lower than 0.
			}
			break;
		}
		kass_str += output_str;
		std::cout << kass_str;
		std::cout << "Input: ";
		input = input_int();
		system("cls");
		kass_str = "";
		output_str = "";
		if (mode == 0)
			mode = 1;
		if (mode == -1)
			mode = 0;
	}

	return 0;
}