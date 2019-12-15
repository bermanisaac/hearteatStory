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

    public static string[] allNames = {"*","Dawn","Everyone","Nyx","Student","Teacher"};
    public static StoryLine  line1 = new StoryLine (1, "Dawn", "Good morning, Nyx! ", new int[] {2}, false, 1);
    public static StoryEvent  line1005 = new StoryEvent (1005, new Tuple<StoryEvent.Action, string>[] {new Tuple<StoryEvent.Action, String>(StoryEvent.Action.Enter, "Nyx")}, 2);
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
    public static StoryLine  line30 = new StoryLine (30, "*", "vaguely interested murmuring* ", new int[] {31}, false, 0);
    public static StoryLine  line31 = new StoryLine (31, "Dawn", "[I wonder what today will bring?] ", new int[] {32}, false, 0);
    public static StoryLine  line32 = new StoryLine (32, "*", "You really should pay attention in class, but instead you're distracted by remembering how Nyx and you met. She's really cute. You love her a lot. ", new int[] {1}, false, 0);
    public static void initStory() {
        allLines.Add(1, line1);
        allEvents.Add(1005, line1005);
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
    }
}
