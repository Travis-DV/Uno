using System;
					
//MOVE THIS INTO .NET AT HOMEs
using System;
using System.Collections.Generic;

class card
{
	public string[] color = {"", ""};
	public string[] number = {"", ""};
	public void addcolor(string[] newcolor, string[] newnumber)
	{
		color = newcolor;
		number = newnumber;
	}
}

class player
{
	public List<card> deck;
	public bool aicontroled;
	public player(bool aicolorled)
	{
		aicontroled = aicolorled;
	}
	
	public void readoutcards() {foreach (card c in deck) {Console.WriteLine($"{c.color[0]}, {c.number[0]}");}}
	
}

class cardvalues
{
	public static string[, ] colors = {{"red", "yellow", "green", "blue", "red", "yellow", "green", "blue", "wild"}, {"purple", "teal", "orange", "pink", "purple", "teal", "orange", "pink", "wild"}};
	public static string[, ] numbers = {{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+2", "reverse", "skip"}};
	public static string[, ] wilds = {{"wild", "+4", "rotate decks"}};
	public static int[, ] pointsnumbers = {{1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 20, 25}};
}

class gamelogic
{
	List<card> deck = new List<card>();
	int startingcardnumber = 4;
	List<player> players = new List<player>() {new player(false)};
	
	public gamelogic()
	{
		for (int i = 0; i < cardvalues.colors[0, 0].Length; i++) { for (int j = 0; j < 2; j++) { for (int x = j; x < 12; x++) { deck.Add(new card()); string[] newcolors = new string[]{cardvalues.colors[0, i], ""}; string[] newnumbers = {cardvalues.numbers[0, x], ""}; deck[deck.Count - 1].addcolor(newcolors, newnumbers); } } }
		for (int i = 0; i < startingcardnumber - 1; i++) {players.Add(new player(true));}
		// pl.deck.Add(addcard); deck.Remove(addcard);  pl.readoutcards();
		foreach (player pl in players) {for (int i = 0; i < 10; i++) {Random rnd = new Random(); card addcard = deck[rnd.Next(deck.Count)]; Console.WriteLine(pl);}}
	}
}

public class main
{
	public static void Main()
	{
		gamelogic game = new gamelogic();
		Console.WriteLine("reeee");
	}
}