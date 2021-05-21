import random
from tkinter import ttk
import tkinter as tk
from decimal import Decimal
import decimal
import locale as lc

class Card:
    def __init__(self,rank="",suit="",points=0):
        self.rank = rank
        self.suit = suit
        self.points = points

    def __str__(self):
        return_str = str(self.rank)  + str(self.suit[0])
        return return_str

##    def __str__(self):
##        return_str = str(self.rank) + ' of ' + str(self.suit)
##        return return_str

    

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
                        card = Card(rank = 'Ace',suit = suit, points = [1,11])
                    elif rank == 11:
                        card = Card(rank='Jack', suit=suit, points=10)
                    elif rank == 12:
                        card = Card(rank='Queen', suit=suit, points=10)
                    elif rank == 13:
                        card = Card(rank='King', suit=suit, points=10)
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
            if card.rank == 'Ace':
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

class Session:
    def __init__(self,sessionID=0,startTime='x',startMoney=0,stopTime='y',stopMoney=0):
        self.sessionID = sessionID
        self.startTime = startTime
        self.startMoney = startMoney
        self.stopTime = stopTime
        self.stopMoney = stopMoney

    def __str__(self):
        sess =  'sessionID :' + str(self.sessionID) + " | " +\
                'startTime :' + str(self.startTime) + " | " +\
                'startMoney:' + str(self.startMoney) + " | " +\
                'stopTime  :' + str(self.stopTime) + " | " +\
                'stopMoney :' + str(self.stopMoney)
        return sess

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
    print("Hand points:", hand.points())
    print("Hand count:", hand.count())
    print("Deck count:", deck.count())

if __name__ == "__main__":
    main()
    
