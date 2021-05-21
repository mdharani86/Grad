from objects import Session, Deck, Hand, Card
import tkinter as tk
from tkinter import ttk
from decimal import Decimal
import decimal
import locale as lc

import db
import sys
from datetime import datetime
from decimal import Decimal

class BlackjackFrame(ttk.Frame):
    def __init__(self,parent,session):
        ttk.Frame.__init__(self,parent,padding="10 10 10 10")
        self.parent = parent
        self.session = session
        self.bet = 5
        self.money=session.stopMoney

        # variables for Blackjackgame
        self.player_hand = None
        self.dealer_hand = None
        self.player_stat = None
        self.is_bj = None
        self.is_player_bj = None
        self.is_dealer_bj = None
        self.deck = None

        try:
            result = lc.setlocale(lc.LC_ALL, "")
            if result == 'C':
                result = lc.setlocale(lc.LC_ALL, "en_US")
            test_val = (lc.currency(12345.67, grouping=True))
        except Exception:
            lc.setlocale(lc.LC_ALL, "en_US")

# Define string variables for text entry fields
        self.moneyText = tk.StringVar()
        self.betText = tk.StringVar()
        self.dealerCardText = tk.StringVar()
        self.dealerPointsText = tk.StringVar()
        self.yourCardText = tk.StringVar()
        self.yourPointsText = tk.StringVar()
        self.resultText = tk.StringVar()

        self.initComponents()

        for child in self.winfo_children():
            child.grid_configure(padx=5, pady=3)

    def initComponents(self):
        self.pack()
# 0. Money
        ttk.Label(self, text="Money:").grid(row=0, column=0, sticky=tk.E)
        moneyEntry = ttk.Entry(self, width=30, textvariable=self.moneyText,state="readonly").grid(row=0, column=1, sticky=tk.W)
        self.moneyText.set(lc.currency(self.money))
# 1. bet
        ttk.Label(self, text="Bet:").grid(row=1, column=0, sticky=tk.E)
        self.betEntry = ttk.Entry(self, width=30, textvariable=self.betText)
        self.betEntry.grid(row=1, column=1, sticky=tk.W)
        self.betText.set(self.bet)
# 2. Dealer
        ttk.Label(self, text="DEALER").grid(row=2, column=0, sticky=tk.E)
# 3. Cards (Dealer)
        ttk.Label(self, text="Cards:").grid(row=3, column=0, sticky=tk.E)
        dealerCardEntry = ttk.Entry(self, width=80, textvariable=self.dealerCardText, state="readonly").grid(row=3, column=1, sticky=tk.W)
# 4. Points (Dealer)
        ttk.Label(self, text="Points").grid(row=4, column=0, sticky=tk.E)
        dealerPointsEntry = ttk.Entry(self, width=30, textvariable=self.dealerPointsText, state="readonly").grid(row=4, column=1, sticky=tk.W)
# 5. You (label)
        ttk.Label(self, text="YOU").grid(row=5, column=0, sticky=tk.E)
# 6. Cards(you)
        ttk.Label(self, text="Cards:").grid(row=6, column=0, sticky=tk.E)
        yourCardEntry = ttk.Entry(self, width=80, textvariable=self.yourCardText, state="readonly").grid(row=6, column=1, sticky=tk.W)
# 7. points(you)
        ttk.Label(self, text="Points:").grid(row=7, column=0, sticky=tk.E)
        yourPointsEntry = ttk.Entry(self, width=30, textvariable=self.yourPointsText, state="readonly").grid(row=7, column=1, sticky=tk.W)
# 8. hit and stand buttons
        buttonFrame1 = ttk.Frame(self)
        buttonFrame1.grid(column=1, columnspan=2, row=8, sticky=tk.W)
        self.buttonHit = ttk.Button(buttonFrame1, text="Hit", command=self.hit)
        self.buttonHit.grid(column=0, row=0)
        self.buttonStand = ttk.Button(buttonFrame1, text="Stand", command=self.stand)
        self.buttonStand.grid(column=1, row=0, padx=5)
        self.buttonHit["state"] = "disabled"
        self.buttonStand["state"] = "disabled"
# 9. result
        ttk.Label(self, text="Result:").grid(row=9, column=0, sticky=tk.E)
        resultEntry = ttk.Entry(self, width=80, textvariable=self.resultText, state="readonly").grid(row=9, column=1, sticky=tk.W)
# 10. plan and exit buttons
        buttonFrame2 = ttk.Frame(self)
        buttonFrame2.grid(column=1, columnspan=2, row=10, sticky=tk.W)
        self.buttonPlay = ttk.Button(buttonFrame2, text="Play", command=self.play)
        self.buttonPlay.grid(column=0, row=0)
        ttk.Button(buttonFrame2, text="Exit", command=self.exit_game).grid(column=1, row=0, padx=5)
# 11 - 12 Game Assumptions
        ttk.Label(self,text = "*Deafult bet is 5. You can enter your new default bet*!").grid(row=11, column=1)
        text = "*When you have money less than " + lc.currency(5) + ", the game adds " + lc.currency(100) + " to your account!*"
        ttk.Label(self, text=text).grid(row=12, column=1)


    def play(self):
        self.buttonHit["state"] = "enabled"
        self.buttonStand["state"] = "enabled"
        self.player_hand = None
        self.dealer_hand = None
        self.natural_bj = None
        self.resultText.set("")
        self.dealerCardText.set("")
        self.yourCardText.set("")
        self.dealerPointsText.set("")
        self.yourPointsText.set("")
        self.deck = Deck()
        self.deck.shuffle()

        if self.isvalid_bet():
            self.buttonPlay["state"] = "disabled"
            self.buttonHit["state"] = "enabled"
            self.buttonStand["state"] = "enabled"
            self.betEntry.configure(state="readonly")
            self.start_game()
        else:
            self.buttonHit["state"] = "disabled"
            self.buttonStand["state"] = "disabled"

    def start_game(self):
        self.player_hand, self.dealer_hand = self.dealer_deals_cards(self.deck)
        player_points = self.player_hand.pointList()

        self.dealerCardText.set(self.dealer_hand.getCard(0))
        self.dealerPointsText.set(self.dealer_hand.getCard(0).points)
        self.yourCardText.set(self.display_cards(self.player_hand))
        self.yourPointsText.set('/'.join(map(str, player_points)))
        self.is_player_bj = self.check_bj(self.player_hand)
        self.is_dealer_bj = self.check_bj(self.dealer_hand)

        self.natural_bj = False
        if self.is_player_bj or self.is_dealer_bj:  # Natural Blackjack
            self.buttonHit["state"] = "disabled"
            self.buttonStand["state"] = "disabled"
            self.buttonPlay["state"] = "enabled"
            self.betEntry.configure(state="normal")
            self.natural_bj = True
            self.buttonHit["state"]="disabled"
            self.buttonStand["state"] = "disabled"
            self.dealerCardText.set(self.display_cards(self.dealer_hand))
            self.dealerPointsText.set(self.dealer_hand.points())
            self.yourPointsText.set(self.player_hand.points())
            self.update_money()


    def hit(self):
        self.resultText.set("")
        is_break = self.player_hit(self.deck, self.player_hand)
        self.yourCardText.set(self.display_cards(self.player_hand))
        player_points = self.player_hand.pointList()
        self.yourPointsText.set('/'.join(map(str,player_points)))
        if is_break:
            self.buttonPlay["state"] = "enabled"
            self.betEntry.configure(state="normal")
            self.buttonHit["state"] = "disabled"
            self.buttonStand["state"] = "disabled"
            self.dealerCardText.set(self.display_cards(self.dealer_hand))
            self.dealerPointsText.set(self.dealer_hand.points())
            if self.player_hand.points() == 21:
                self.stand()
            else:
                self.update_money()

    def stand(self):
        self.buttonPlay["state"] = "enabled"
        self.betEntry.configure(state="normal")
        self.buttonHit["state"] = "disabled"
        self.buttonStand["state"] = "disabled"
        while True:
            if any((i >= 17 and i <= 21) for i in self.dealer_hand.pointList()):
                break
            elif all(i > 21 for i in self.dealer_hand.pointList()):
                break
            else:
                self.dealer_hand.addCard(self.deck.dealCard())
        self.dealerCardText.set(self.display_cards(self.dealer_hand))
        self.dealerPointsText.set(self.dealer_hand.points())
        self.yourPointsText.set(self.player_hand.points())
        self.update_money()

    def player_hit(self,deck,player_hand):
        """
        when player chose to hit, new card is drawn from deck. This function returns
        True - if the player can hit again
        False - if the player is bust or has a total card value of 21
        """
        player_hand.addCard(deck.dealCard())
        if (all(i > 21 for i in player_hand.pointList())) \
                or (21 in player_hand.pointList()):
            return True
        else:
            return False

    def display_cards(self,hand):
        msg = ""
        for card in hand:
            msg += card.__str__() + " | "
        return msg

    def check_bj(self,cards):
        """
        This function checks if the total value of card is 21 and returns True or False"
        """
        bj = False
        total = cards.points()
        if total == 21:
            bj = True
        else:
            bj = False

        return bj

    def get_player_stat(self,player_hand, dealer_hand):
        """
        This function check if player won or not or if there is a tie. It returns
        True  - when player wins
        False - when player loses
        None  - when tie between player and dealer
        """
        player_total = player_hand.points()
        dealer_total = dealer_hand.points()
        if player_total > 21:
            return False
        elif dealer_total > 21:
            return True
        elif player_total == dealer_total:
            return None
        elif player_total > dealer_total:
            return True
        else:
            return False


    def update_money(self):
        money = float(self.money)
        money = Decimal(money)
        money = money.quantize(Decimal("1.00"))
        bet =  float(self.betText.get())
        bet = Decimal(bet)
        bet = bet.quantize(Decimal("1.00"))

        returnmsg = ""
        player_stat = self.get_player_stat(self.player_hand, self.dealer_hand)

        if player_stat is True:
            if self.natural_bj:
                money = (money + (bet * Decimal("1.5")))
                money = money.quantize(Decimal("1.00"))
                returnmsg += "You got BLACKJACK!!"
            else:
                money = (money + bet).quantize(Decimal("1.00"))
                returnmsg += "Hooray!You Win!"
        elif player_stat is False:
            if self.natural_bj:
                returnmsg+="Sorry! you Lose. Dealer Blackjack!"
            else:
                returnmsg += "Sorry! you Lose."
            money = (money - bet).quantize(Decimal("1.00"))
        else:
            returnmsg += "Push!! Player and Dealer tie!!"

        self.resultText.set(returnmsg)
        self.moneyText.set(lc.currency(money,grouping=True))
        self.money = money
        # print("BookMark1",type(self.money)," , ",self.money)

    def dealer_deals_cards(self,deck):
        """
        This fuction draws cards from the deck to the player and dealer during the start of each game.
        The cards from the deck is popped and it returns the player and dealer hand cards.
        """
        dealer_hand = Hand()
        player_hand = Hand()
        player_hand.addCard(deck.dealCard())
        dealer_hand.addCard(deck.dealCard())
        player_hand.addCard(deck.dealCard())
        dealer_hand.addCard(deck.dealCard())
        return player_hand, dealer_hand

    def isvalid_bet(self):
        """
        This function get bet amount from the the user terminal and stores it as a float value in the global variable 'bet'
        """
        valid_bet = False
        returnMsg = ""
        try:
            self.check_money_balance()
            bet = float(self.betText.get())
            if not self.is_two_digit_decimal(str(bet)):
                returnMsg+="Enter only two digits after decimal! eg.10.25, 10.2, 10 are valid."
                self.resultText.set(returnMsg)
            else:
                if (bet < 5) or (bet > 1000):
                    returnMsg+="Invalid bet! Minimum bet is " + lc.currency(5) +" and maximum bet is "+ lc.currency(1000) +"!"
                    self.resultText.set(returnMsg)
                else:
                    if bet > float(self.money):
                        returnMsg+="Bet amount is greater than the actual amount!"
                        self.resultText.set(returnMsg)
                    else:
                        valid_bet = True
        except (ValueError, TypeError, decimal.InvalidOperation) as e:
            returnMsg = "Enter a valid bet amount!"
            self.resultText.set(returnMsg)
        except Exception as e:
            returnMsg ="Unexpected error. " + str(e)
            self.resultText.set(returnMsg)
        return valid_bet

    def check_money_balance(self):
        if self.money < 5:
            self.resultText.set("Insufficient Fund! But we gave bonus $100.00 to continue")
            self.money += 100
            self.moneyText.set(lc.currency(self.money,grouping = "True"))

    def is_two_digit_decimal(self,val):
        if '.' in val:
            dot_index = val.find('.')
            if len(val[dot_index:]) > 3:
                return False
        return True

    def exit_game(self):
        # self.money = self.moneyText.get()
        self.parent.destroy()
        # return self.money

    def __str__(self):
        return str(self.money)

def main():
##    start_time = datetime.now().strftime("%I:%M:%S %p")
    start_time = datetime.now()
    db.connect()
    db.create_session()
    last_session = db.get_last_session()
    start_money = last_session.stopMoney
    print("last_session: ",last_session)
    root=tk.Tk()
    root.title("BlackJack")
    stop_money = BlackjackFrame(root,last_session)
    root.mainloop()
##    stop_time = datetime.now().strftime("%I:%M:%S %p")
    stop_time = datetime.now()
    current_session = Session(last_session.sessionID+1,start_time,last_session.stopMoney,stop_time,float(str(stop_money)))
    print("current_session: ",current_session)
    db.add_session(current_session)
    print("checking if inserted :")
    print(db.get_last_session())
    db.close()

if __name__=="__main__":
    main()
