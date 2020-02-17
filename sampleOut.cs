using System.Collections.Generic;
using System;
public class StoryLine
{
    public int ID;
    public string Name;
    public string Line;
    public int[] Connects;
    public bool IsChoice;
    public int ArtNum;



    public StoryLine (int id, string name, string line, int[] connects, bool isChoice, int artNum) 
    {
        ID = id;
        Name = name;
        Line = line;
        Connects = connects;
        IsChoice = isChoice;
        ArtNum = artNum;
    }
}

public class StoryEvent
{
    public enum Action
    {
        Enter,
        Exit
    }

    public int ID;
    public Tuple<Action, string>[] Actions;
    public int Connect;

    public StoryEvent (int id, Tuple<Action, string>[] actions, int connect)
    {
        ID = id;
        Actions = actions;
        Connect = connect;
    }
}

public class Story
{
    public static Dictionary<int, StoryLine> allLines = new Dictionary<int, StoryLine>();
    public static Dictionary<int, StoryEvent> allEvents = new Dictionary<int, StoryEvent>();

    public static string[] allNames = {"*","Dawn","Everyone","Harmony","Nina","Nyx","Student","Summer","Teacher"};
    public static StoryLine  line1 = new StoryLine (1, "Dawn", "Good morning, Nyx! ", new int[] {2}, false, 1);
    public static StoryLine  line2 = new StoryLine (2, "Nyx", "Hi! <3 ", new int[] {2001,2002,2003}, true, 0);
    public static StoryLine  line2001 = new StoryLine (2001, "Dawn", "Just remember to clean up after yourself, please? ", new int[] {3}, false, 2);
    public static StoryLine  line2002 = new StoryLine (2002, "Dawn", "What are you doing??? ", new int[] {301}, false, 0);
    public static StoryLine  line2003 = new StoryLine (2003, "Dawn", "Don't you think it's a bit early for this? ", new int[] {3}, false, 0);
    public static StoryLine  line3 = new StoryLine (3, "Nyx", "I saw her and I just had to, you know? Her HEART looked so delicious. ", new int[] {3001,3002,3003}, true, 0);
    public static StoryLine  line301 = new StoryLine (301, "Nyx", "I'm eating Lilly Valley's HEART, silly! ", new int[] {3001,3012,3013}, true, 0);
    public static StoryLine  line3001 = new StoryLine (3001, "Dawn", "...Right. ", new int[] {4}, false, 3);
    public static StoryLine  line3002 = new StoryLine (3002, "Dawn", "*sigh* Every morning, Nyx. Every morning. ", new int[] {5}, false, 0);
    public static StoryLine  line3003 = new StoryLine (3003, "Dawn", "Did you at least kill her first this time? ", new int[] {6}, false, 0);
    public static StoryLine  line3012 = new StoryLine (3012, "Dawn", "Aw...  she was cute...  ", new int[] {7}, false, 0);
    public static StoryLine  line3013 = new StoryLine (3013, "Dawn", "Is it tasty? ", new int[] {8}, false, 0);
    public static StoryLine  line4 = new StoryLine (4, "Nyx", "I'm done now! Time for the drain cleaner <3. ", new int[] {9}, false, 0);
    public static StoryLine  line5 = new StoryLine (5, "Nyx", "I can't help it, our school is just full of cute girls who aren't quite as cute as you UwU. ", new int[] {9}, false, 0);
    public static StoryLine  line6 = new StoryLine (6, "Nyx", "Of course. I'm not mean :( ", new int[] {9}, false, 0);
    public static StoryLine  line7 = new StoryLine (7, "Nyx", "Not as cute as you... ", new int[] {9}, false, 0);
    public static StoryLine  line8 = new StoryLine (8, "Nyx", "Yeah! ", new int[] {9}, false, 0);
    public static StoryLine  line9 = new StoryLine (9, "*", "*The two of you banter for a while. It's really nice, and you get the mess all cleaned up.* ", new int[] {10}, false, 0);
    public static StoryLine  line10 = new StoryLine (10, "Teacher", "Good morning, everyone. ", new int[] {11}, false, 0);
    public static StoryLine  line11 = new StoryLine (11, "Everyone", "*bleary eyes* ", new int[] {12}, false, 0);
    public static StoryLine  line12 = new StoryLine (12, "Teacher", "I see there are once more a couple of empty seats. ", new int[] {13}, false, 0);
    public static StoryLine  line13 = new StoryLine (13, "Dawn", "[Thankfully Nyx and I cleaned up after ourselves. I don't want her to get expelled.] ", new int[] {14}, false, 0);
    public static StoryLine  line14 = new StoryLine (14, "Teacher", "Marci August. ", new int[] {15}, false, 0);
    public static StoryLine  line15 = new StoryLine (15, "Student", "Here. ", new int[] {16}, false, 0);
    public static StoryLine  line16 = new StoryLine (16, "Dawn", "[I don't have to pay attention until I hear my name. I wonder what she's going to say about Lilly?] ", new int[] {17}, false, 0);
    public static StoryLine  line17 = new StoryLine (17, "Teacher", "Lilly Valley isn't here. Hm. Knowing this place, she's probably been murdered. Pity. She was sort of tolerable. ", new int[] {18}, false, 0);
    public static StoryLine  line18 = new StoryLine (18, "Dawn", "[It's a good thing my homeroom teacher is so callous. Some of them actually care, it makes things way more complicated.] ", new int[] {19}, false, 0);
    public static StoryLine  line19 = new StoryLine (19, "Teacher", "Dawn. Dawn. ", new int[] {20}, false, 0);
    public static StoryLine  line20 = new StoryLine (20, "Dawn", "??? ", new int[] {21}, false, 0);
    public static StoryLine  line21 = new StoryLine (21, "Teacher", "Dawn you have to pay attention. ", new int[] {22}, false, 0);
    public static StoryLine  line22 = new StoryLine (22, "Dawn", "I was. I'm just a bit tired, is all. ", new int[] {23}, false, 0);
    public static StoryLine  line23 = new StoryLine (23, "Teacher", "Staying up late studying? ", new int[] {24}, false, 0);
    public static StoryLine  line24 = new StoryLine (24, "Dawn", "Yeah, sure! ", new int[] {25}, false, 0);
    public static StoryLine  line25 = new StoryLine (25, "Nyx", "She was helping me. I'm really bad at math. ", new int[] {26}, false, 0);
    public static StoryLine  line26 = new StoryLine (26, "Dawn", "And I'm bad at German! So we were helping each other. ", new int[] {27}, false, 0);
    public static StoryLine  line27 = new StoryLine (27, "Teacher", "As heartwarming as your solidarity is, you need to pay attention in class. This is a very prestigious school, after all, and you better not forget it. And Nyx, no talking unprompted. Please remember that. ", new int[] {28}, false, 0);
    public static StoryLine  line28 = new StoryLine (28, "Nyx", "*smiles* ", new int[] {29}, false, 0);
    public static StoryLine  line29 = new StoryLine (29, "Teacher", "Moving right along. Rose Thorn was expelled for the murder of Polly Winkle after being caught thanks to the efforts of the newspaper club. ", new int[] {30}, false, 0);
    public static StoryLine  line30 = new StoryLine (30, "*", "*vaguely interested murmuring* ", new int[] {31}, false, 0);
    public static StoryLine  line31 = new StoryLine (31, "Dawn", "[I wonder what today will bring?] ", new int[] {32}, false, 0);
    public static StoryLine  line32 = new StoryLine (32, "*", "*You really should pay attention in class, but instead you're distracted by remembering how Nyx and you met. She's really cute. You love her a lot.* ", new int[] {33}, false, 0);
    public static StoryLine  line33 = new StoryLine (33, "*", "*first day in the dorm...* ", new int[] {34}, false, 0);
    public static StoryLine  line34 = new StoryLine (34, "Dawn", "!!!? ", new int[] {35}, false, 0);
    public static StoryLine  line35 = new StoryLine (35, "Dawn", "What are you doing? ", new int[] {36}, false, 0);
    public static StoryLine  line36 = new StoryLine (36, "Nyx", "Wait, is this yours? ", new int[] {37}, false, 0);
    public static StoryLine  line37 = new StoryLine (37, "Dawn", "Yes! That's mine! ", new int[] {38}, false, 0);
    public static StoryLine  line38 = new StoryLine (38, "*", "*She's eating your hamster, Dawn. That's what's happening.* ", new int[] {39}, false, 0);
    public static StoryLine  line39 = new StoryLine (39, "Nyx", "Oh, sorry! I didn't know it was anyone's. ", new int[] {40}, false, 0);
    public static StoryLine  line40 = new StoryLine (40, "*", "*Nyx puts down your hamster back in her cage.* ", new int[] {41001,41002,41003}, true, 0);
    public static StoryLine  line41001 = new StoryLine (41001, "Dawn", "...her name is Madame Fluffbottom. ", new int[] {42}, false, 0);
    public static StoryLine  line41002 = new StoryLine (41002, "Dawn", "Do you always eat hamsters you find? ", new int[] {43}, false, 0);
    public static StoryLine  line41003 = new StoryLine (41003, "Dawn", "Man, you're really lucky you're cute. ", new int[] {44}, false, 0);
    public static StoryLine  line42 = new StoryLine (42, "Nyx", "That's so cute, oh my god! ", new int[] {45001}, false, 0);
    public static StoryLine  line43 = new StoryLine (43, "Nyx", "Only the ones that look tasty. ", new int[] {45002}, false, 0);
    public static StoryLine  line44 = new StoryLine (44, "Nyx", "UwU ;3. ", new int[] {45003}, false, 0);
    public static StoryLine  line45001 = new StoryLine (45001, "Dawn", "I'm glad you think so. You're Nyx?  ", new int[] {46}, false, 0);
    public static StoryLine  line45002 = new StoryLine (45002, "Dawn", "...I can sort of understand that. ", new int[] {46}, false, 0);
    public static StoryLine  line45003 = new StoryLine (45003, "Dawn", "!! <3 ", new int[] {46}, false, 0);
    public static StoryLine  line46 = new StoryLine (46, "*", "*You really should feel more weird about this entire... situation, but your hamster is fine and your room is cute, so you just sort of end up talking. It's nice.* ", new int[] {47}, false, 0);
    public static StoryLine  line47 = new StoryLine (47, "Teacher", "Dawn! Pay attention!", new int[] {48}, false, 0);
    public static StoryLine  line48 = new StoryLine (48, "*", "Oh, shoot, you drifted off again. You smile at Nox and bend your head over your notebook, forcing yourself for the rest of class.*", new int[] {49}, false, 0);
    public static StoryLine  line49 = new StoryLine (49, "*", "Nothing super interesting happens for the rest of class, and you find yourself clutching a piece of paper making your way to the student council room. You're not in any clubs, but you're also obedient enough that the teachers use you to ferry messages to the President. You're pretty sure they're scared of her. ", new int[] {50}, false, 0);
    public static StoryLine  line50 = new StoryLine (50, "Harmony", "What are you doing here!", new int[] {51}, false, 0);
    public static StoryLine  line51 = new StoryLine (51, "*", "A gun?? Why is the Student Council president pointing a gun at you?", new int[] {52}, false, 0);
    public static StoryLine  line52 = new StoryLine (52, "Harmony", "Summer, did you see her face? Ha ha ha ha!", new int[] {53}, false, 0);
    public static StoryLine  line53 = new StoryLine (53, "Summer", "UwU :3", new int[] {54}, false, 0);
    public static StoryLine  line54 = new StoryLine (54, "*", "You sigh. They always do this, and they always get you.*", new int[] {55}, false, 0);
    public static StoryLine  line55 = new StoryLine (55, "Dawn", "I have a note for you. It's about who was killed yesterday, and who's been expelled. ", new int[] {56}, false, 0);
    public static StoryLine  line56 = new StoryLine (56, "Harmony", "Excellent. Thank you. Please leave. ", new int[] {57}, false, 0);
    public static StoryLine  line57 = new StoryLine (57, "Dawn", "I just arrived!", new int[] {58}, false, 0);
    public static StoryLine  line58 = new StoryLine (58, "Harmony", "Are you talking back to me?", new int[] {59}, false, 0);
    public static StoryLine  line59 = new StoryLine (59, "Harmony", "Summer, is she talking back to me? ", new int[] {60}, false, 0);
    public static StoryLine  line60 = new StoryLine (60, "Summer", "OwO", new int[] {61}, false, 0);
    public static StoryLine  line61 = new StoryLine (61, "Dawn", "Alright, alright, I'm leaving!", new int[] {62}, false, 0);
    public static StoryLine  line62 = new StoryLine (62, "Summer", ":3", new int[] {63}, false, 0);
    public static StoryLine  line63 = new StoryLine (63, "*", "Outside, you find Nina staring intently at the door.*", new int[] {64}, false, 0);
    public static StoryLine  line64 = new StoryLine (64, "Nina", "Dawn, I need to talk to you. ", new int[] {65}, false, 0);
    public static StoryLine  line65 = new StoryLine (65, "Dawn", "Is everything okay? ", new int[] {66}, false, 0);
    public static StoryLine  line67 = new StoryLine (67, "Nina", "We can't talk here. Meet me on the roof at midnight. ", new int[] {68}, false, 0);
    public static StoryLine  line68 = new StoryLine (68, "Dawn", "Oh... okay...", new int[] {70}, false, 0);
    public static StoryLine  line70 = new StoryLine (70, "Nina", "Bring Nyx!", new int[] {71}, false, 0);
    public static StoryLine  line71 = new StoryLine (71, "*", "She leaves you standing alone outside of the student council office. You stare after her, then make a beeline for your dorm. If this involves Nyx, it's almost guaranteed to be weird.*", new int[] {72}, false, 0);
    public static StoryLine  line72 = new StoryLine (72, "*", "You tell Nyx and her expression gets more serious than you've seen her in a while. She pulls you into a hug, and you can't keep the worry you are suddenly feeling off your face.*", new int[] {73}, false, 0);
    public static StoryLine  line73 = new StoryLine (73, "Dawn", "Is everything okay?", new int[] {74}, false, 0);
    public static StoryLine  line74 = new StoryLine (74, "Nyx", "You said Nina, right?", new int[] {75}, false, 0);
    public static StoryLine  line75 = new StoryLine (75, "Dawn", "Yeah?", new int[] {76}, false, 0);
    public static StoryLine  line76 = new StoryLine (76, "Nyx", "She's the head of the newspaper club. She knows something. I'm sure of it. ", new int[] {77}, false, 0);
    public static StoryLine  line77 = new StoryLine (77, "Dawn", "Do you think she...?", new int[] {78}, false, 0);
    public static StoryLine  line78 = new StoryLine (78, "Nyx", "Yeah.", new int[] {79}, false, 0);
    public static StoryLine  line79 = new StoryLine (79, "Dawn", "Shoot. I guess there's nothing we can do but talk to her. ", new int[] {80}, false, 0);
    public static StoryLine  line80 = new StoryLine (80, "Nyx", "It's okay. I'll eat her if necessary.", new int[] {81}, false, 0);
    public static StoryLine  line81 = new StoryLine (81, "*", "She's serious, of course, and you find yourself comforted by the threat.*", new int[] {82}, false, 0);
    public static StoryLine  line82 = new StoryLine (82, "Dawn", "I love you. ", new int[] {83}, false, 0);
    public static StoryLine  line83 = new StoryLine (83, "Nyx", "<3", new int[] {84}, false, 0);
    public static StoryLine  line84 = new StoryLine (84, "*", "You go to the roof, Nyx in tow. You're not technically allowed up here, the door isn't alarmed and nobody monitors it so that doesn't really matter. You spot Nina standing near the edge. Grabbing Nyx tightly by the hand, you approach her.*", new int[] {85}, false, 0);
    public static StoryLine  line85 = new StoryLine (85, "Nina", "I know what you are. ", new int[] {86}, false, 0);
    public static StoryLine  line86 = new StoryLine (86, "*", "Your heart clenches in your chest, but Nyx's expression doesn't change.*", new int[] {87}, false, 0);
    public static StoryLine  line87 = new StoryLine (87, "Nyx", "I'm not afraid of you. ", new int[] {88}, false, 0);
    public static StoryLine  line88 = new StoryLine (88, "Nina", "I don't expect you to be. I just want your help.", new int[] {89}, false, 0);
    public static StoryLine  line89 = new StoryLine (89, "*", "You glare at her, knowing it's not going to help but not sure what else you're supposed to do. Nyx squeezes your hand, and you feel something inside your chest unclench.* ", new int[] {90}, false, 0);
    public static StoryLine  line90 = new StoryLine (90, "Dawn", "What do you need?", new int[] {91}, false, 0);
    public static StoryLine  line91 = new StoryLine (91, "Nina", "Have you heard of the Murder Club?", new int[] {92}, false, 0);
    public static StoryLine  line92 = new StoryLine (92, "Dawn", "Murder Club?", new int[] {93}, false, 0);
    public static StoryLine  line93 = new StoryLine (93, "Nyx", "That's just a rumor.", new int[] {94}, false, 0);
    public static StoryLine  line94 = new StoryLine (94, "Nina", "It's an organization of girls who kill other girls for fun.", new int[] {95}, false, 0);
    public static StoryLine  line95 = new StoryLine (95, "Dawn", "People get murdered here all the time.", new int[] {96}, false, 0);
    public static StoryLine  line96 = new StoryLine (96, "Nina", "Yeah, but this is different. They're killing a lot of people, and if they're not stopped they'll just keep going. You get that, right?", new int[] {97}, false, 0);
    public static StoryLine  line97 = new StoryLine (97, "Dawn", "I guess? What does this have to do with us, with blackmailing Nyx. ", new int[] {98}, false, 0);
    public static StoryLine  line98 = new StoryLine (98, "Nina", "You're smart. I'm not just saying that to flatter you, you've been able to hide your heart-eating girlfriend for this long. I need you to figure out who the murder club people are before they hurt anyone else. ", new int[] {99}, false, 0);
    public static StoryLine  line99 = new StoryLine (99, "Nyx", "And then what? ", new int[] {100}, false, 0);
    public static StoryLine  line100 = new StoryLine (100, "Nina", "We bring proof to the teachers and get them expelled. ", new int[] {101}, false, 0);
    public static StoryLine  line101 = new StoryLine (101, "Nyx", "And what else? ", new int[] {102}, false, 0);
    public static StoryLine  line102 = new StoryLine (102, "Nina", "I don't know what you mean. ", new int[] {103}, false, 0);
    public static StoryLine  line103 = new StoryLine (103, "Nyx", "I know you're not just concerned for the well-being of the other students. What's your stake in this?", new int[] {104}, false, 0);
    public static void initStory() {
        allLines.Add(1, line1);
        allLines.Add(2, line2);
        allLines.Add(2001, line2001);
        allLines.Add(2002, line2002);
        allLines.Add(2003, line2003);
        allLines.Add(3, line3);
        allLines.Add(301, line301);
        allLines.Add(3001, line3001);
        allLines.Add(3002, line3002);
        allLines.Add(3003, line3003);
        allLines.Add(3012, line3012);
        allLines.Add(3013, line3013);
        allLines.Add(4, line4);
        allLines.Add(5, line5);
        allLines.Add(6, line6);
        allLines.Add(7, line7);
        allLines.Add(8, line8);
        allLines.Add(9, line9);
        allLines.Add(10, line10);
        allLines.Add(11, line11);
        allLines.Add(12, line12);
        allLines.Add(13, line13);
        allLines.Add(14, line14);
        allLines.Add(15, line15);
        allLines.Add(16, line16);
        allLines.Add(17, line17);
        allLines.Add(18, line18);
        allLines.Add(19, line19);
        allLines.Add(20, line20);
        allLines.Add(21, line21);
        allLines.Add(22, line22);
        allLines.Add(23, line23);
        allLines.Add(24, line24);
        allLines.Add(25, line25);
        allLines.Add(26, line26);
        allLines.Add(27, line27);
        allLines.Add(28, line28);
        allLines.Add(29, line29);
        allLines.Add(30, line30);
        allLines.Add(31, line31);
        allLines.Add(32, line32);
        allLines.Add(33, line33);
        allLines.Add(34, line34);
        allLines.Add(35, line35);
        allLines.Add(36, line36);
        allLines.Add(37, line37);
        allLines.Add(38, line38);
        allLines.Add(39, line39);
        allLines.Add(40, line40);
        allLines.Add(41001, line41001);
        allLines.Add(41002, line41002);
        allLines.Add(41003, line41003);
        allLines.Add(42, line42);
        allLines.Add(43, line43);
        allLines.Add(44, line44);
        allLines.Add(45001, line45001);
        allLines.Add(45002, line45002);
        allLines.Add(45003, line45003);
        allLines.Add(46, line46);
        allLines.Add(47, line47);
        allLines.Add(48, line48);
        allLines.Add(49, line49);
        allLines.Add(50, line50);
        allLines.Add(51, line51);
        allLines.Add(52, line52);
        allLines.Add(53, line53);
        allLines.Add(54, line54);
        allLines.Add(55, line55);
        allLines.Add(56, line56);
        allLines.Add(57, line57);
        allLines.Add(58, line58);
        allLines.Add(59, line59);
        allLines.Add(60, line60);
        allLines.Add(61, line61);
        allLines.Add(62, line62);
        allLines.Add(63, line63);
        allLines.Add(64, line64);
        allLines.Add(65, line65);
        allLines.Add(67, line67);
        allLines.Add(68, line68);
        allLines.Add(70, line70);
        allLines.Add(71, line71);
        allLines.Add(72, line72);
        allLines.Add(73, line73);
        allLines.Add(74, line74);
        allLines.Add(75, line75);
        allLines.Add(76, line76);
        allLines.Add(77, line77);
        allLines.Add(78, line78);
        allLines.Add(79, line79);
        allLines.Add(80, line80);
        allLines.Add(81, line81);
        allLines.Add(82, line82);
        allLines.Add(83, line83);
        allLines.Add(84, line84);
        allLines.Add(85, line85);
        allLines.Add(86, line86);
        allLines.Add(87, line87);
        allLines.Add(88, line88);
        allLines.Add(89, line89);
        allLines.Add(90, line90);
        allLines.Add(91, line91);
        allLines.Add(92, line92);
        allLines.Add(93, line93);
        allLines.Add(94, line94);
        allLines.Add(95, line95);
        allLines.Add(96, line96);
        allLines.Add(97, line97);
        allLines.Add(98, line98);
        allLines.Add(99, line99);
        allLines.Add(100, line100);
        allLines.Add(101, line101);
        allLines.Add(102, line102);
        allLines.Add(103, line103);
    }
}