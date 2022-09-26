#MOVE THIS INTO .NET AT HOMEs
import random as r

class player:

    def __init__(self):

        self.cards = []
        self.name = ""
        self.points = 0
        self.onuno = False
        self.filloutcards()
        #return self

    def addcard(self):
        #NORMAL
        normalstuff = {"colors": ["red", "blue", "green", "yellow", "red", "blue", "green", "yellow", "special"], "numbers": [["0", 0],["1", 1],["2",1],["3",3],["4",4],["5",5],["6",6],["7",7],["8",8],["9",9], ["flip", 45], ["+1", 15], ["skip", 30], ["reverce", 20]], "special": [["wild", 30], ["+4 wild", 50]]}
        newcard = card()
        newcard.addcolor(False, normalcolor=r.choice(normalstuff["colors"]))
        if newcard.colors[0] != "special":
            temp = r.choice(normalstuff["numbers"])
            newcard.addnumber(False, normalnumber=temp[0])
        elif newcard.colors[0] == "special":
            temp = r.choice(normalstuff["special"])
            newcard.addnumber(False, normalnumber=temp[0])
        self.points += temp[1]
        #FLIP
        flipstuff = {"colors": ["purple", "teal", "orange", "pink", "purple", "teal", "orange", "pink", "special"], "numbers": [["0", 0],["1", 1],["2",1],["3",3],["4",4],["5",5],["6",6],["7",7],["8",8],["9",9],["+5", 60], ["skip all", 50], ["flip", 45], ["draw to color", 40], ["skip", 20], ["reverce", 20]], "special": [["wild", 30], ["+2 wild", 35]]}
        newcard.addcolor(True, flipcolor=r.choice(flipstuff["colors"]))
        if newcard.colors[1] != "special":
            temp = r.choice(flipstuff["numbers"])
            newcard.addnumber(True, flipnumber=temp[0])
        elif newcard.colors[1] == "special":
            temp = r.choice(flipstuff["special"])
            newcard.addnumber(True, flipnumber=temp[0])
        self.points += temp[1]
        self.cards.append(newcard)

    def filloutcards(self):
        for i in range(7):
            self.addcard()

    def drawtomach(self, newcolor, isflipp) :
        newcards = []
        while newcards == [] or (not isflipp and newcards[-1].color[0] != newcolor[0]) or (isflipp and newcards[-1].color[1] != newcolor[1]):
            newcards.append(card())
        self.cards += newcards

    def pluscards(self, numberofcards):
        for x in range(numberofcards):
            self.cards.append(card())

    def isitelegable(self, card, isfliped):
        if isfliped and (card.colors[1] == self.cards.colors[1] or card.colors[1] == "special" or card.number[1] == self.cards.number[1]): return True
        elif not isfliped and (card.colors[0] == self.cards[0] or card.colors[0] == "special" or card.number[0] == self.cards.number[0]): return True
        else: return False

class card:

    def __init__(self):
        self.colors = ["", ""]
        self.number = [-1, -1]

    def addcolor(self, isfliped, normalcolor = "", flipcolor =""):
        if not isfliped:
            self.colors[0] = normalcolor
        elif isfliped:
            self.colors[1] = flipcolor

    def addnumber(self, isfliped, normalnumber = -1, flipnumber = -1):
        if not isfliped:
            self.number[0] = normalnumber
        elif isfliped:
            self.number[1] = flipnumber

    def printstuff(self):
        print(f"You have a {self.colors[0]} {self.number[0]} on the normal side and on the flip side you have a {self.colors[1]} {self.number[1]}")

class discardpile(player):

    def __init__(self):
        self.cards = card()

    def getstartingcard(self):
        while True:
            self.cards = self.addcard()
            if not "special" in self.cards.colors:
                break

    def replacecard(self, newcard, isfliped):
        if self.isitelegable(newcard, isfliped):
            self.cards = newcard

class gamelogic():

    def __init__(self):
        self.players = [player()]
        self.makeplayers()
        self.discardpile = discardpile()
        self.currentplayer = self.players[0]
        self.isreversed = False
        self.color = []

    def isint(self, string):
        try: return int(string)
        except: return -1

    def getamountofplayers(self):
        amountofplayers = self.isint(input("How many players do you want to have? (max 4)\n"))
        self.players[0].name = input("What is your name?\n")
        while True:
            if amountofplayers > 1 and amountofplayers < 5:
                return amountofplayers - 1
            amountofplayers = self.isint(input("Please input a number between 2 and 4\n"))

    def makeplayers(self):
        amountofplayers = self.getamountofplayers()
        for x in range(amountofplayers):
            self.players.append(AI())
        return self.players

    def throwcard(self):
        self.players[self.currentplayer].throwcard()

class AI(player):

    def __init__(self):
        self.name = r.choice(["Olivia", "Emma", "Charlotte", "Amelia", "Ava", "Sophia", "Isabella", "Mia", "Evelyn", "Harper", "Luna", "Camila", "Gianna", "Elizabeth", "Eleanor", "Ella", "Abigail", "Sofia", "Avery", "Scarlett", "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Theodore", "Jack", "Levi", "Alexander", "Jackson", "Mateo", "Daniel", "Michael", "Mason", "Sebastian", "Ethan"])

    def makeanger(self, players):
        self.anger = []
        for player in players:
            if player.name != self.name:
                self.anger.append([player, 0])

    def throwcard(self, isfliped, nextplayer):
        clearedcards = []
        for card in self.cards:
            if self.isitelegable(card, isfliped):
                clearedcards.append(card)
        keydict = dict(zip(self.cards[0], self.card[1]))
        self.cards.sort(key=keydict.get)



game = gamelogic()