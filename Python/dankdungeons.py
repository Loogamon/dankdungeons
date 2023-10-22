import os
import random
import math
playme='fun' #Used to break game loop
no_clear=0 #Does not use 'os.system('cls')' if value is 1.
while playme!='': #Loop for replaying the game as many times you'd like.
    #Defines Default Values & Game Data
    item='---' #Items use '---' to represent an empty item slot.
    no_mon=0 #No enemy will be generated.
    err=0 #Flow controls if there's an input error.
    num_paths=2 #Number of Paths to enter
    floor_num=1 #Current Floor
    lvl=1 #Current Level
    current_hp=10 #HP.
    max_hp=10 #Maximum HP.
    current_mp=10 #MP.
    max_mp=10 #Maximum MP.
    gold=500 #Gold. Unused.
    game_off=0 #Game is off? Used to break game loop.
    in_p=-1 #Variable for input choice.
    current_mode=0 #Current game mode. 0=Dungeon, 1=Battle
    max_num=1 #Minimum number of choices.
    min_num=1 #Maximum number of choices.
    monsters=0 #Number of monsters in the paths.
    loc_names=['' for z in range(30)] #List of location names.
    mon_locs=['' for z in range(30)] #List of monster locations.
    #for z in range(30):
    #    print(z)
    monster_find=0 #Monster is found?
    #Monster Data:
    #[Name,HP,Attack,EXP,Gold]
    mon_data=[
    [
    'Ghost',
    '3',
    '1',
    '100',
    '25'
    ],[
    'Imp',
    '5',
    '2',
    '125',
    '35'
    ],[
    'Mummy',
    '12',
    '1',
    '320',
    '120'
    ],[
    'Dragon',
    '25',
    '12',
    '1000',
    '5000'
    ],[
    'Dark Mage',
    '20',
    '7',
    '750',
    '215'
    ],[
    'Dark Knight',
    '32',
    '20',
    '432',
    '562'
    ],[
    'Tiger',
    '40',
    '40',
    '820',
    '450'
    ],[
    'Centaur',
    '32',
    '100',
    '4500',
    '3200'
    ],[
    'Dark King',
    '80',
    '128',
    '6500',
    '7500'
    ],[
    'Demon Lord',
    '1000',
    '95',
    '10000',
    '10000'
    ],[
    'Kass',
    '5000',
    '5000',
    '50000',
    '50000'
    ]]
    #Reactions used in battles. 
    reactions=[
    'Yikes',
    'Ah!',
    'Jinkies!',
    'Oh boy!',
    'Argh!',
    'Woah!',
    'Oh no!',
    'Great...']
    #Adjectives for area names.
    path_name1=[
    'Stinky',
    'Strange',
    'Colorful',
    'Wonderous',
    'Puzzling',
    'Silly',
    'Perplexing',
    'Spooky',
    'Bland',
    'Cold',
    'Hot',
    'Mysterious'
    ]
    #Nouns for area names.
    path_name2=[
    'Hallway',
    'Terrance',
    'Atrium',
    'Patio',
    'Shrine',
    'Forest',
    'Sewers',
    'Engine Room',
    'Studio',
    'Kitchen',
    'Bathroom',
    'Balcony'
    ]
    #List of items. The name of items' strings do affect the game!
    item_name=[
    'Potion',
    'Elixir',
    'Sword',
    'Smoke Ball',
    'Stronger Potion',
    'Stronger Elixir',
    'Stronger Sword',
    'Death Sword'
    ]
    fight_mon=0 #Monster indentifer
    mon_hp=0 #Monster's HP
    mon_maxhp=0 #Monster's Maximum HP.
    battle_str="" #String used to print battle text.
    exp=0 #EXP.
    next_lvl=100 #Ammount of EXP needed to reach the next level.
    mon_range=10 #Number of monster types allowed to appear.
    mon_range=1 #
    item_range=7 #Number of item types allowed to appear.
    item_range=1 #
    for abc in range(30): #Generating random path names.
        loc_names[abc]="{a1} {a2}".format(a1=path_name1[random.randint(0,len(path_name1)-1)],a2=path_name2[random.randint(0,len(path_name2)-1)])
    num_paths=random.randint(1,6) #How many paths will be generated?
    #Title Screen
    print("----------\nDank Dungeons\nGame by Loogamon -- 4/30/17 - 5/2/17\n----------") #Print Text
    #Exception Handling for reading files and displays the high score, if there is any.
    try:
        if os.path.isfile("dd_gamesave.sav"):
            thefile=open("dd_gamesave.sav")
            score_floor=int(thefile.readline())
            score_lvl=int(thefile.readline())
            thefile.close()
            print("High Score: Floor {floor} | LVL. {lvl}\n".format(floor=score_floor,lvl=score_lvl))
    except:
        print("Error loading file!\n")
    input("Please play this from the Python exectuable to fully enjoy the game.\nInput anything to continue: ")
    while game_off==0: #Game Loop 2 starts here  
        if no_clear==0: os.system('cls')
        print("Floor {floor_num}".format(floor_num=floor_num)) #Print Floor
        print("HP: {current_hp}/{max_hp} | MP: {current_mp}/{max_mp} | LVL. {lvl}\n----------".format(current_hp=current_hp,max_hp=max_hp,current_mp=current_mp,max_mp=max_mp,lvl=lvl,gold=gold)) #Print Stats
        if monster_find==0 and current_mode==0 and no_mon==0: #If Monster is found, initalize battle!
            monster_find=1
            fight_mon=random.randint(0,mon_range) #Choose the type of monster.
            oan=in_p #Thing to prevent error.
            if oan<0: #Thing to prevent error.
                oan=0 #Thing to prevent error.
            if oan>20: #Thing to prevent error.
                oan=20 #Thing to prevent error.
            if mon_locs[oan]!='': #If the current area lacks a monster, show reactions!
                print("{reactions} A monster!\n{monster} appeared!\n---".format(reactions=reactions[random.randint(0,len(reactions)-1)],monster=mon_data[fight_mon][0]))
                mon_hp=int(mon_data[fight_mon][1])
                mon_maxhp=int(mon_data[fight_mon][1])
                current_mode=1
        if no_mon==1: #Sets the no_mon flag to 0. Used to prevent monsters from appearing in the next turn.
            no_mon=0
        if current_mode==0: #Dungeon Mode
            if num_paths>1: #If there's more than one path, print a list a with different string.
                print("{battle_str}The path splits into {num_paths}...\nWhich path I should take?".format(battle_str=battle_str,num_paths=num_paths))
                print("---")
                if item!="---": #Show Discard Item function if the player has an item.
                    print("0 - Discard Item [{item}]".format(item=item))
                for x in range(num_paths): #Show Paths to go to
                    print("{x} - {a1}".format(x=x+1,a1=loc_names[x]))
            else: #If there is only one path, show a different set of dialog with only one (two, if the player has an item) choices.
                print("{battle_str}There is only one path...\nIt leads to {a1}.\nProceed?".format(battle_str=battle_str,num_paths=num_paths,a1=loc_names[1]))
                print("---")
                if item!="---": #Show Discard Item function if player has an item.
                    print("0 - Discard Item [{item}]".format(item=item))
                print("1 - Move further.")
            max_num=num_paths #Change the highest allowed option to the number of paths
        if current_mode==1: #Battle 
            print("{battle_str}{monster}\nHP: {mon_hp}/{mon_maxhp}".format(battle_str=battle_str,monster=mon_data[fight_mon][0],mon_hp=mon_hp,mon_maxhp=mon_maxhp)) #Monster Stats
            print("1 - Attack\n2 - Magic\n3 - Use Item [{item}]\n4 - Escape".format(item=item)) #Battle Options
            max_num=4 #There's only 4 options in Battle Mode regardless of the situation, so therefore you can't use any number greater than 4 nor any lower than 0.
        try: #Input the options
            in_p=int(input("Select a number from the list: "))
            err=0 #Sets the error checker to 0.
            #These if statements will block the game from doing progressing actions, if true.
            if in_p==0: err=2
            if err==0: 
                if in_p>max_num: err=1
                if in_p<1: err=1
        except:
            in_p=-1 #If there's an error with the input, set the choice to negative 1.
            err=1
        battle_str="" #Reset Battle Message Log
        if err==2 and current_mode==0 and in_p==0 and item!="---": #Option for discarding item.
            battle_str+="Discarded {item}.\n---\n".format(floor_num=floor_num,item=item)
            item="---" #The string '---' represents an empty item.
            no_mon=1 #Disallow mons from appearing.
        if err==0: #If there's no error, progress further in the dungeon or the process the battle.
            if current_mode==0 and in_p>0: #Dungeon Mode
                chest=random.randint(0,10000) #Randomizes the odds of finding a chest. Odds in a 5,000/10,000 chance.
                if chest<5000: #If a chest was found.
                    no_mon=1 #Disallow mon
                    if item=="---": #If the player has no item, obtain the chest's contents.
                        item=item_name[random.randint(0,item_range)] #Randomize the item.
                        battle_str+="A chest was found!\nIt contains {item}.\n---\n".format(floor_num=floor_num,item=item)
                    else: #Otherwise, if the player has none. Show a message the player can't obtain it.
                        battle_str+="A chest was found!\nBut you already have an item...\n---\n".format(floor_num=floor_num,item=item)
                nextfloor=random.randint(0,10000) #Randomizes the odds of finding a staircase leading the next floor. Odds in a 1,500 in a 10,000 chance.
                if nextfloor<1500: #Floor was found.
                    floor_num+=1 #Increment the current floor to 1.
                    battle_str+="A staircase was found!\nI'm now on Floor {floor_num}!\nBetter rewards, but stronger enemies will be coming!\n---\n".format(floor_num=floor_num)
                    if floor_num==2 or floor_num==5 or floor_num==7 or floor_num>=10: #On specfic floors. Increase the randomized range of enemy types.
                        mon_range+=1
                    if mon_range>8: mon_range=8 #Cap the range to 8.
                    if floor_num>99: #If the player has reached to the 100th floor, throw in two new monsters. Note that these two monsters are almost impossible to defeat without reaching a high level beforehand. 
                        mon_range=10
                    item_range+=1 #Increase the randomized range of item types.
                    if item_range>=7: item_range=7 #Cap the range up to 7.
                    if mon_range>10: mon_range=10 #Cap the enemy range up to 10.
                    no_mon=1 #Disallow monsters from appearing.
                monster_find=0
                num_paths=random.randint(1,6) #Randomize the number of paths.
                for abc in range(30): #Randomize the name of the paths
                    loc_names[abc]="{a1} {a2}".format(a1=path_name1[random.randint(0,len(path_name1)-1)],a2=path_name2[random.randint(0,len(path_name2)-1)])
                #Randomize the monster locations
                monsters=random.randint(0,num_paths)
                if monsters<0: monsters=0
                mon_locs=['' for z in range(30)] #Clean up the previous monster locations
                for z in range(monsters): #Spawns the monsters in a unique path.
                    good=0
                    zx=-1
                    while good==0:
                        zx=random.randint(0,num_paths-1)                  
                        good=1
                        for mon_check in range(10):
                            if mon_locs[mon_check]==zx: good=0
                    if zx!=-1:
                        mon_locs[zx]=str(z)
            if current_mode==1: #Battle Mode
                if in_p==1: #Attack, Regular Damage
                    mon_hp-=1*lvl
                    battle_str+="I attacked!\n{monster} took {damage} damage!\n---\n".format(monster=mon_data[fight_mon][0],damage=str(1*lvl))
                if in_p==2: #Magic, Double Damage--Requires MP.
                    if current_mp>=5:
                        current_mp-=5
                        if current_mp<0: current_mp=0
                        mon_hp-=2*lvl
                        battle_str+="I casted my magic!\n{monster} took {damage} damage!\n---\n".format(monster=mon_data[fight_mon][0],damage=str(2*lvl))
                    else:
                        battle_str+="I don't have enough MP to use magic!\n---\n"
                if in_p==3: #Use Item, if have any.
                    if item=='---':
                        battle_str+="I don't have an item to use!\n---\n"
                    if item=='Potion':
                        battle_str+="I recovered 10 HP!\n---\n"
                        current_hp+=10
                    if item=='Elixir':
                        battle_str+="I recovered 10 MP!\n---\n"
                        current_mp+=10
                    if item=='Sword':
                        battle_str+="The Sword shines!\n"
                        mon_hp-=3*lvl
                        battle_str+="{monster} took {damage} damage!\n---\n".format(monster=mon_data[fight_mon][0],damage=str(3*lvl))
                    if item=='Smoke Ball':
                        battle_str+="I escaped successfully!\n---\n"
                        current_mode=0
                    if item=='Stronger Potion':
                        battle_str+="I recovered 30 HP!\n"
                        current_hp+=30
                    if item=='Stronger Elixir':
                        battle_str+="I recovered 30 MP!\n"
                        current_mp+=30
                    if item=='Stronger Sword':
                        mon_hp-=5*lvl
                        battle_str+="The Stronger Sword shines!\n"
                        battle_str+="{monster} took {damage} damage!\n---\n".format(monster=mon_data[fight_mon][0],damage=str(5*lvl))
                    if item=='Death Sword':
                        if mon_data[fight_mon][0]=="Kass":
                             battle_str+="Kass is too powerful!\n---\n"
                        else:
                            battle_str+="The Death Sword shines!\n---\n"
                            mon_hp=0
                        
                    item='---' #This 'consumes' the item after use.
                    if current_hp>max_hp: current_hp=max_hp
                    if current_mp>max_mp: current_mp=max_mp
                if in_p==4: #Escape, 50% chance of ending the battle. The player will not gain EXP if escaped.
                    escape=random.randint(0,100)
                    if escape<50:
                        battle_str+="I escaped successfully!\n---\n"
                        current_mode=0
                    else:
                        battle_str+="Escape failed!\n---\n"
                if current_mode==1: #Only in Battle Mode.
                    if mon_hp<=0: #If the monster's HP is down 0. Process the victory segment.
                        mon_hp=0
                        exp_get=int(mon_data[fight_mon][3]) #Get the ammount of EXP the monster contains.
                        exp+=exp_get
                        gold_get=int(mon_data[fight_mon][4])+random.randint(-32,32) #Get the number of gold the monster holds.
                        if gold_get<10: #Makes sure the number of gold obtain is never less than 10.
                            gold_get=10
                        gold+=gold_get #Adds the gold. Note that gold is an unused feature.
                        battle_str+="Victory!\n{monster} was defeated!\n{exp} EXP was obtained!\n---\n".format(monster=mon_data[fight_mon][0],exp=exp_get,gold=gold_get)
                        if exp>next_lvl: #If the ammount of EXP is greater than the amount required for the next level. Increase the player's level.
                            lvl+=1
                            max_hp*=1.5 #Increase player's stats.
                            max_hp=math.floor(max_hp) 
                            current_hp=max_hp
                            max_mp*=1.5
                            max_mp=math.floor(max_hp)
                            current_mp=max_mp
                            battle_str+="Level Up!\nMy level is now at Level {lvl}!\nHP can now up to {newhp}!\nMP can now up to {newmp}!\nHP and MP is fully recovered!\n---\n".format(lvl=lvl,newhp=max_hp,newmp=max_mp)
                            next_lvl*=2
                        mon_hp=0
                        current_mode=0
                    else: #If the monster is still alive.
                        damage=math.floor(int(mon_data[fight_mon][2])/lvl) #Calculate the damage it will give to the player.
                        current_hp-=damage
                        battle_str+="{monster} attacked!\nI took {damage} damage!\n---\n".format(monster=mon_data[fight_mon][0],damage=damage)
                        if current_hp<=0: #If the player runs out HP...
                            current_hp=0
                            print("{battle_str}I'm dead...\nGame Over!\n---".format(battle_str=battle_str))
                            game_off=1
                            #High Score recording.
                            score_floor=0
                            score_lvl=0
                            score_total=0
                            try:
                                if os.path.isfile("dd_gamesave.sav"):
                                    thefile=open("dd_gamesave.sav")
                                    score_floor=int(thefile.readline())
                                    score_lvl=int(thefile.readline())
                                    score_total=score_floor*score_lvl #Score is calculated from the player's level times the floor he/she is on.
                                    thefile.close()
                                    #print("High Score: Floor {floor} | LVL. {lvl}\n".format(floor=score_floor,lvl=score_lvl))
                                my_score=lvl*floor_num
                                if my_score>score_total: #If the player's score is greater than the previous, or is the first to score. Record the score onto an external file.
                                    print("Congrats! You made the high score!\nFloor: {floor} | LVL. {level}\n".format(floor=floor_num,level=lvl))
                                    thefile=open("dd_gamesave.sav",'w')
                                    thefile.write(str(floor_num)+"\n")
                                    thefile.write(str(lvl)+"\n")
                                    thefile.close()
                            except:
                                print("File error!\n")

    playme=input("Input anything to restart the game: ") #Input to restart the game.
    if no_clear==0: os.system('cls')
