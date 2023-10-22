using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassDungeonGUI
{
    public partial class Form1 : Form
    {
        private string GAME_NAME= "Dank Dungeons v1.036";
        private Random rand = new Random();
        private int mode = 0;
        private string item = "---"; //Items use "---" to represent an empty item slot.
        private int no_mon = 0; //No enemy will be generated.
        private int err = 0; //Flow controls if there"s an input error.
        private int num_paths = 2; //Number of Paths to enter
        private int floor_num = 1; //Current Floor
        private int lvl = 1; //Current Level
        private int current_hp = 10; //HP.
        private int max_hp = 10; //Maximum HP.
        private int current_mp = 10; //MP.
        private int max_mp = 10; //Maximum MP.
        private int gold = 500; //Gold. Unused.
        private int game_off = 0; //Game is off? Used to break game loop.
        private int in_p = -1; //Variable for input choice.
        private int current_mode = 0; //Current game mode. 0=Dungeon, 1=Battle
        private int max_num = 1; //Minimum number of choices.
        private int min_num = 1; //Maximum number of choices.
        private int monsters = 0; //Number of monsters in the paths.
        private string[] loc_names = new string[30];
        private string[] mon_locs = new string[30];
        private int monster_find = 0;
        //Monster Data:
        //[Name,HP,Attack,EXP,Gold]
        private string[,] mon_data = new string[,] {
        {
        "Ghost",
        "3",
        "1",
        "100",
        "25"
        },{
          "Imp",
          "5",
          "2",
          "125",
          "35"
        },{
          "Mummy",
          "12",
          "1",
          "320",
          "120"
        },{
          "Dragon",
          "25",
          "12",
          "1000",
          "5000"
        },{
          "Dark Mage",
          "20",
          "7",
          "750",
          "215"
        },{
          "Dark Knight",
          "32",
          "20",
          "432",
          "562"
        },{
          "Tiger",
          "40",
          "40",
          "820",
          "450"
        },{
          "Centaur",
          "32",
          "100",
          "4500",
          "3200"
        },{
          "Dark King",
          "80",
          "128",
          "6500",
          "7500"
        },{
          "Demon Lord",
          "1000",
          "95",
          "10000",
          "10000"
        },{
          "Kass",
          "5000",
          "5000",
          "50000",
          "50000"
        }};
        //Reactions used in battles. 
        private string[] reactions =  {
        "Yikes",
        "Ah!",
        "Jinkies!",
        "Oh boy!",
        "Argh!",
        "Woah!",
        "Oh no!",
        "Great..."};
        //Adjectives for area names.
        private string[] path_name1 =  {
        "Stinky",
        "Strange",
        "Colorful",
        "Wonderous",
        "Puzzling",
        "Silly",
        "Perplexing",
        "Spooky",
        "Bland",
        "Cold",
        "Hot",
        "Mysterious"
        };
        //Nouns for area names.
        private string[] path_name2 =  {
        "Hallway",
        "Terrance",
        "Atrium",
        "Patio",
        "Shrine",
        "Forest",
        "Sewers",
        "Engine Room",
        "Studio",
        "Kitchen",
        "Bathroom",
        "Balcony"
        };
        //List of items. The name of items" strings do affect the game!
        private string[] item_name =  {
        "Potion",
        "Elixir",
        "Sword",
        "Smoke Ball",
        "Stronger Potion",
        "Stronger Elixir",
        "Stronger Sword",
        "Death Sword"
        };
        private int fight_mon = 0; //Monster indentifer
        private int mon_hp = 0; //Monster"s HP
        private int mon_maxhp = 0; //Monster"s Maximum HP.
        private string battle_str = ""; //String used to print battle text.
        private int exp = 0; //EXP.
        private int next_lvl = 100; //Ammount of EXP needed to reach the next level.
        private int mon_range = 10; //Number of monster types allowed to appear.
        private int item_range = 1; //Number of item types allowed to appear.
        private string output_str="";
        private bool startit=false;

        private void ResetGame()
        {
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
            for (int z = 0; z < 30; z++)
            {
                //Console.WriteLine(z);
                loc_names[z] = "";
                mon_locs[z] = "";
                loc_names[z] = "{a1} {a2}";
                loc_names[z] = loc_names[z].Replace("{a1}", path_name1[rand.Next(0, path_name1.Length)]);
                loc_names[z] = loc_names[z].Replace("{a2}", path_name2[rand.Next(0, path_name2.Length)]);
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
            num_paths = rand.Next(1, 6 + 1);
            //output_str = "";
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public Form1()
        {
            InitializeComponent();
            Text = GAME_NAME;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //Edge of Window is 17 minus the Width. 39 for Height.
            //MessageBox.Show("OOO");
            size_me();
        }

        private void size_me()
        {
            Text = GAME_NAME;
            myOutput.Top = 0;
            myOutput.Left = 0;
            myOutput.Width = Form1.ActiveForm.Width - 17;
            myOutput.Height = (Form1.ActiveForm.Height - 39);
            myOutput.Height -= myInput.Height;
            myInput.Top = myOutput.Top + myOutput.Height;
            myInput.Width = Form1.ActiveForm.Width - 17;
            mySender.Top = myOutput.Top + myOutput.Height;
            mySender.Width = Form1.ActiveForm.Width / 4;
            mySender.Height = myInput.Height;
            mySender.Left = (Form1.ActiveForm.Width - 17) - (mySender.Width);
            myInput.Width = (mySender.Left - myInput.Left);
        }

        private void Form1_Init(object sender, EventArgs e)
        {
            //Edge of Window is 17 minus the Width. 39 for Height.
            //MessageBox.Show("OOO");
            size_me();
            if (startit==false)
            Game_Input("1");
            startit = true;
        }

        private void mySender_Click(object sender, EventArgs e)
        {
            Game_Input(myInput.Text);
            myInput.Focus();
            myInput.Text = "";
        }

        private void myInput_KeyPress(object sender, KeyPressEventArgs e)
        {
                //Game_Input(myInput.Text);
                //myInput.Text = "";
        }

        private void Game_Input(string message)
        {
            //MessageBox.Show(s_input);
            //myOutput.Text = message;
            if (message == "")
                return;
            string kass_str;
            kass_str = "";
            output_str = "";

            switch (mode)
            {
                case 0:
                    Console.WriteLine("[GAME START?]");
                    ResetGame();
                    kass_str += "----------\r\nDank Dungeons -- Game by NeoSinth\r\nOriginal: 4/30/17 - 5/2/17\r\nC# Port: 5/19/18 - 5/20/18\r\nC# GUI Port: 11/28/18\r\n----------\r\n";//
                    if (System.IO.File.Exists("dd_gamesave.sav"))
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader("dd_gamesave.sav");
                        int score_floor;
                        int score_lvl;
                        int.TryParse(file.ReadLine(), out score_floor);
                        int.TryParse(file.ReadLine(), out score_lvl);
                        file.Close();
                        kass_str += "High Score: Floor {floor} | LVL. {lvl}\r\n".Replace("{floor}", score_floor.ToString()).Replace("{lvl}", score_lvl.ToString());
                    }
                    kass_str += "Please input a number to continue.\r\n";
                    mode = 1;
                    break;
                case 1:
                    if (!IsDigitsOnly(message))
                        return;
                    output_str = "";
                    Console.WriteLine("[GAME]");
                    int.TryParse(message, out in_p);
                    //INPUT CODE

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
                            chest = rand.Next(0, 10000 + 1);
                            if (chest < 5000)
                            {
                                no_mon = 1;
                                if (item == "---")
                                {
                                    item = item_name[rand.Next(0, item_range + 1)];
                                    battle_str += "A chest was found!\r\nIt contains " + item + ".\r\n---\r\n";
                                }
                                else
                                    battle_str += "A chest was found!\r\nBut you already have an item...\r\n---\r\n";
                            }
                            int nextfloor;
                            nextfloor = rand.Next(0, 10000 + 1);
                            if (nextfloor < 1500)
                            {
                                floor_num += 1;
                                battle_str += "A staircase was found!\r\nI'm now on Floor " + floor_num.ToString() + "!\r\nBetter rewards, but stronger enemies will be coming!\r\n---\r\n";
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
                            num_paths = rand.Next(1, 6 + 1);
                            for (int abc = 0; abc < 30; abc++)
                            {
                                loc_names[abc] = "{a1} {a2}";
                                loc_names[abc] = loc_names[abc].Replace("{a1}", path_name1[rand.Next(0, path_name1.Length)]);
                                loc_names[abc] = loc_names[abc].Replace("{a2}", path_name2[rand.Next(0, path_name2.Length)]);
                            }
                            monsters = rand.Next(0, num_paths + 1);
                            if (monsters < 0)
                                monsters = 0;
                            for (int z = 0; z < 30; z++)
                            {
                                mon_locs[z] = "";
                            }
                            for (int z = 0; z < monsters; z++)
                            {
                                int good;
                                int zx;
                                good = 0;
                                zx = -1;
                                while (good == 0)
                                {
                                    zx = rand.Next(0, num_paths);
                                    good = 1;
                                    for (int mon_check = 0; mon_check < 10; mon_check++)
                                    {
                                        if (mon_locs[mon_check] == zx.ToString())
                                            good = 0;
                                    }
                                }
                                if (zx != -1)
                                    mon_locs[zx] = z.ToString();
                            }
                        }
                        if (current_mode == 1 && mode == 1)
                        {
                            if (in_p == 1)
                            {
                                mon_hp -= 1 * lvl;
                                battle_str += "I attacked!\r\n" + mon_data[fight_mon, 0] + " took " + (1 * lvl).ToString() + " damage!\r\n---\r\n";
                            }
                            if (in_p == 2)
                            {
                                if (current_mp >= 5)
                                {
                                    current_mp -= 5;
                                    if (current_mp < 0) current_mp = 0;
                                    mon_hp -= 2 * lvl;
                                    battle_str += "I casted my magic!\r\n" + mon_data[fight_mon, 0] + " took " + (2 * lvl).ToString() + " damage!\r\n---\r\n";
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
                                    battle_str += mon_data[fight_mon, 0] + " took " + (3 * lvl).ToString() + " damage!\r\n---\r\n";
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
                                    battle_str += mon_data[fight_mon, 0] + " took " + (5 * lvl).ToString() + " damage!\r\n---\r\n";
                                }
                                if (item == "Death Sword")
                                {
                                    battle_str += "The Death Sword emblazes in a dark aura!\r\n---\r\n";
                                    if (mon_data[fight_mon, 0] == "Kass")
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
                                escape = rand.Next(0, 100 + 1);
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
                                    int exp_get;
                                    int.TryParse(mon_data[fight_mon, 3], out exp_get);
                                    exp += exp_get;
                                    battle_str += "Victory!\r\n" + mon_data[fight_mon, 0] + " was defeated!\r\n" + exp_get.ToString() + " EXP was obtained!\r\n---\r\n";
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
                                        battle_str += "Level Up!\r\nMy level is now at Level " + lvl.ToString() + "!\r\nHP can now be up to " + max_hp.ToString() + "!\r\nMP can now be up to " + max_mp.ToString() + "!\r\nHP and MP is fully recovered!\r\n---\r\n";
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
                                    double.TryParse(mon_data[fight_mon, 2], out mon_attack);
                                    calc = mon_attack / (double)lvl;
                                    damage = (int)calc;
                                    current_hp -= damage;
                                    battle_str += "" + mon_data[fight_mon, 0] + " attacked!\r\nI took " + damage.ToString() + " damage!\r\n---\r\n";
                                    if (current_hp <= 0)
                                    {
                                        current_hp = 0;
                                        output_str += battle_str + "I'm dead...\r\nGame Over!\r\n---\r\n";
                                        game_off = 1;
                                        mode = 0;
                                        int score_floor;
                                        int score_lvl;
                                        int score_total;
                                        score_floor = 0;
                                        score_lvl = 0;
                                        score_total = 0;
                                        if (System.IO.File.Exists("dd_gamesave.sav"))
                                        {
                                            System.IO.StreamReader file = new System.IO.StreamReader("dd_gamesave.sav");
                                            int.TryParse(file.ReadLine(), out score_floor);
                                            int.TryParse(file.ReadLine(), out score_lvl);
                                            score_total = score_floor * score_lvl;
                                            file.Close();
                                        }
                                        int my_score;
                                        my_score = lvl * floor_num;
                                        if (my_score > score_total)
                                        {
                                            output_str += "Congrats! You made the high score!\r\nFloor: " + floor_num.ToString() + " | LVL. " + lvl.ToString() + "\r\n";
                                            System.IO.StreamWriter file = new System.IO.StreamWriter("dd_gamesave.sav");
                                            file.WriteLine(floor_num.ToString());
                                            file.WriteLine(lvl.ToString());
                                            file.Close();
                                        }

                                    }
                                }
                            }


                        }
                    }


                    output_str += "Floor " + floor_num.ToString(); output_str += "\r\n";
                    output_str += "HP: " + current_hp.ToString() + "/" + max_hp.ToString() + " | ";
                    output_str += "MP: " + current_mp.ToString() + "/" + max_mp.ToString() + " | ";
                    output_str += "LVL. " + lvl.ToString() + "\r\n----------\r\n";
                    if (monster_find == 0 && current_mode == 0 && no_mon == 0 && mode == 1)
                    {
                        monster_find = 1;
                        fight_mon = rand.Next(0, mon_range + 1); ; //RND: 0 - mon_range
                        int oan;
                        oan = in_p;
                        if (oan < 0) oan = 0;
                        if (oan > 20) oan = 20;
                        if (mon_locs[oan] != "")
                        {
                            //print("{reactions} A monster!\r\n{monster} appeared!\r\n---".format(reactions=reactions[random.randint(0,len(reactions)-1)],monster=mon_data[fight_mon][0]))
                            output_str += reactions[rand.Next(0, reactions.Length - 1)];
                            output_str += " A monster!\r\n" + mon_data[fight_mon, 0] + " appeared!\r\n---"; output_str += "\r\n";
                            int.TryParse(mon_data[fight_mon, 1], out mon_hp);
                            int.TryParse(mon_data[fight_mon, 1], out mon_maxhp);
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
                            output_str += "The path splits into " + num_paths.ToString() + "...\r\nWhich path I should take?\r\n---"; output_str += "\r\n";
                            if (item != "---")
                            {
                                output_str += "0 - Discard Item [" + item + "]"; output_str += "\r\n";
                            }
                            for (int i = 0; i < num_paths; i++)
                            {
                                output_str += "" + (i + 1).ToString() + " - " + loc_names[i] + ""; output_str += "\r\n";
                            }
                        }
                        else
                        {
                            output_str += battle_str;
                            output_str += "There is only one path...\r\nIt leads to " + loc_names[0] + ".\r\nProceed?\r\n---"; output_str += "\r\n";
                            if (item != "---")
                            {
                                output_str += "0 - Discard Item [" + item + "]"; output_str += "\r\n";
                            }
                            output_str += "1 - Move further."; output_str += "\r\n";
                        }
                        max_num = num_paths;
                    }
                    if (current_mode == 1 && mode == 1)
                    {
                        output_str += battle_str;
                        output_str += mon_data[fight_mon, 0];
                        output_str += "\r\nHP: " + mon_hp + "/" + mon_maxhp + ""; output_str += "\r\n";
                        output_str += "1 - Attack\r\n2 - Magic\r\n3 - Use Item [" + item + "]\r\n4 - Escape"; output_str += "\r\n";
                        max_num = 4; //There's only 4 options in Battle Mode regardless of the situation, so therefore you can't use any number greater than 4 nor any lower than 0.
                    }

                    //output_str += "GAME HERE"; output_str += "\r\n";                    }
                    break;
            }
            kass_str += output_str;
            myOutput.Text = kass_str;
        }
    }
}
