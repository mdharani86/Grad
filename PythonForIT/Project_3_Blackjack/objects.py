import random

class Card:
    def __init__(self,rank="",suit="",points=0):
        self.rank = rank
        self.suit = suit
        self.points = points

    def __str__(self):
        return_str = str(self.rank) + ' of ' + str(self.suit)
        return return_str

class Deck:
    def __init__(self,no_of_deck = 1):
        self.cards = self.__createDeck(no_of_deck)
        
    def __createDeck(self,no_of_deck=1):
        cards = []
        while len(cards) < 52*no_of_deck:
            suits = ['Hearts', 'Dimonds', 'Spades', 'Clubs']
            for suit in suits:
                for rank in range(1, 14):
                    if rank == 1:
                        card = Card(rank = 'A',suit = suit, points = [1,11])
                    elif rank == 11:
                        card = Card(rank='J', suit=suit, points=10)
                    elif rank == 12:
                        card = Card(rank='Q', suit=suit, points=10)
                    elif rank == 13:
                        card = Card(rank='K', suit=suit, points=10)
                    else:
                        card = Card(rank=str(rank), suit=suit, points=rank)
                    cards.append(card)
        return cards
        
    def shuffle(self):
        random.shuffle(self.cards)

    def count(self):
        return len(self.cards)

    def dealCard(self):
        if len(self.cards) <= 0:
            newDeck = self.__createDeck()
            random.shuffle(newDeck)
            self.cards.extend(newDeck)
            print('new deck')
        tempCard = self.cards.pop(0)
        return tempCard
            

class Hand:
    def __init__(self):
        self.cards = []

    def addCard(self,card):
        self.cards.append(card)

    def getCard(self,idx):
        return self.cards[idx]

    def count(self):
        return len(self.cards)

    def pointList(self):
        cnt_A = 0
        total_point = 0
        for card in self.cards:
            if card.rank == 'A':
                cnt_A += 1
            else:
                total_point += card.points
        if cnt_A == 0:
            return [total_point]
        else:
            total_point_A = total_point + cnt_A
            if total_point + 11 + cnt_A - 1 <= 21:
                total_point = total_point + 11 + cnt_A - 1
            else:
                total_point = total_point_A

            if total_point == total_point_A:
                return [total_point]
            elif total_point > 21 or total_point_A > 21:
                return [min(total_point,total_point_A)]
            else:
                return[total_point,total_point_A]

    def points(self):
        
        totalPointList = self.pointList()
        if all(i>21 for i in totalPointList):
           return max(totalPointList)
        while any(i>21 for i in totalPointList):
            totalPointList.remove(max(totalPointList))
        if len(totalPointList) >= 1:
            return max(totalPointList)

    def __iter__(self):
        self.__index = -1
        return self

    def __next__(self):
        if self.__index >= len(self.cards)-1:
            raise StopIteration()
        self.__index += 1
        card = self.cards[self.__index]
        return card

# 1. Copy and paste the main() below into objects.py
# 2. You may need to change the name of some methods, if they are different from the classes of yours.
# 3. Run objects.py and the main() will be executed to test if all three classes are defined correctly.
# 4. If classes are defined correctly, the main() output should look like the one below with cards randomly generated.
##>>>
##==================== RESTART: C:\.........\Project_3\objects.py ====================
##Cards - Tester
##
##DECK
##Deck created.
##Deck shuffled.
##Deck count: 52
##
##HAND
##4 of Clubs
##King of Hearts
##8 of Hearts
##7 of Spades
##
##Hand points: 29
##Hand count: 4
##Deck count: 48
##>>>

def main():
    print("Cards - Tester")
    print()
    
    # test Deck class
    print("DECK")
    deck = Deck()
    print("Deck created.")
    deck.shuffle()
    print("Deck shuffled.")
    print("Deck count:", deck.count())
    print()
    # test Hand class
    print("HAND")
    hand = Hand()
    for i in range(4):
        hand.addCard(deck.dealCard())
    for card in hand:
        print(card)
    print()
##
##    print("Hand pointlist:", hand.pointList())
    print("Hand points:", hand.points())
    print("Hand count:", hand.count())
    print("Deck count:", deck.count())
##    print(hand.cards[0].points)
##    print(hand.getCard(0))
if __name__ == "__main__":
    main()
