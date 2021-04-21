"""
This Module contains main logic of the blackjack game.
The Value of Ace is 1 or 11 - determined by the cards drawn by dealer/player
"""

from objects import Card, Deck, Hand
import random
import db
import sys
import locale as lc
from datetime import datetime
from decimal import Decimal
import decimal
import math

#Attempting to use the locale from user's computer. If that fails, Locale is set to en_US
try:
    result=lc.setlocale(lc.LC_ALL, "")
    if result == 'C':
        result=lc.setlocale(lc.LC_ALL, "en_US")
    test_val = (lc.currency(12345.67,groupung = True))
except Exception:
    lc.setlocale(lc.LC_ALL, "en_US")    

start_time = None
stop_time = None
money_filename = "money.txt"
game_over = False
bet = 0.0
    
def display_head():
    """
    Displays game header
    """
    print("BLACKJACK!")
    print("The Value of Ace is 1 or 11 - determined by the cards drawn.")
    print("Blackjack payout is 3:2")
    global start_time
    start_time = datetime.now()
    print("start time: ",start_time.strftime("%I:%M:%S %p"))
    print()

def is_two_digit_decimal(val):
    if '.' in val:
        dot_index = val.find('.')
        if len(val[dot_index:])>3:
            return False
    return True

def get_bet():
    """
    This fuction get bet amount from the the user terminal and stores it as a float value in the global variable 'bet'
    """
    global game_over,bet
    valid_bet = False
    while not valid_bet:
        try:
            money = get_money(money_filename)
            money = check_money_balance(money)
            
            bet = float(input("Bet amount : "))
            if not is_two_digit_decimal(str(bet)):
                print("Please enter only two digits after decimal! eg.10.25, 10.2, 10 are valid. 10.25134,0.1234,10.123 are invalid.")
                print("Try again!")
                print()
                continue
            if (bet < 5) or (bet > 1000):
                print(f"Invalid bet! Minimum bet amount is {lc.currency(5)} and maximum bet amount is {lc.currency(1000)}!")
                print()
                continue
            if bet > float(money):
                print(f"Bet amout is greater than the actual amount! ({money})")
                print("Lower your bet!")
                print()
                continue
            bet = Decimal(bet).quantize(Decimal("1.00"))
            valid_bet = True
        except (ValueError, TypeError,decimal.InvalidOperation) as e:
            #print(e)
            print("Invalid value entered! Try again!")
        except Exception as e:
            print("Unexpected error occured while getting bet. Terminating game!")
            print(type(e),e)
            exit_game()
            
def get_money(filename):
    money = db.read_file(filename)
    try:
        money = Decimal(money)
        money = money.quantize(Decimal("1.00"))
    
    except (ValueError,TypeError,decimal.InvalidOperation):
        print("Invalid money in the input file. Terminating Game!")
        exit_game()
    except Exception as e:
        print("Unexpected error occured while getting money. Terminating game!")
        print(type(e),e)
        exit_game()
    return money


def buy_chips(filename):
    while True:
        try:
            amt = float(input("Enter the amount/value to buy chips: "))
            if not is_two_digit_decimal(str(amt)):
                print("Please enter only two digits after decimal! eg.10.25, 10.2, 10 are valid. 10.123, 10.25134,0.1234 are invalid.")
                print("Try again!")
                print()
                continue
            amt = Decimal(amt)
            amt = amt.quantize(Decimal("1.00"))
            if amt >= 0:
                break
            else:
                print("Money cannot be nagative. Try Again!")
        except (ValueError,TypeError,decimal.InvalidOperation):
            print("Invalid Amount entered! Try Again!")
        except Exception as e:
            print("Unexpected error occured while buying chips. Terminating game!")
            print(type(e),e)
            sys.exit()
    money = get_money(filename)
    money += amt
    db.write_file(filename,money)
    print(f"Transaction success! You have chip value of {lc.currency(money,grouping=True)}.")
    print()

def dealer_deals_cards(deck):
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
    return player_hand,dealer_hand

def start_game(deck):

    """
    This function has the main flow of the blacjack game using the deck of cards as argument
    The money in the money.txt is updated based on the game result and bet amount
    """

    global game_over
    
    player_hand,dealer_hand = dealer_deals_cards(deck)
    player_points = player_hand.pointList()
    
    print()
    print(f"DEALER'S SHOW CARD: ")
    print(dealer_hand.getCard(0))
    print()
    print(f"YOUR CARDS:({'/'.join(map(str,player_points))})")
    display_cards(player_hand)
    is_player_bj = check_bj(player_hand)
    is_dealer_bj = check_bj(dealer_hand)
    
    natural_bj = False
    if is_player_bj or is_dealer_bj:  #Natural Blackjack
        natural_bj = True
        print()
        print(f"Dealer cards: ({dealer_hand.points()})")
        display_cards(dealer_hand)
        print()
        is_player_won = get_player_stat(player_hand,dealer_hand)
        if is_player_won is True:
            print("Yay! you got Blackjack! you get 1.5 times of your bet!")
        elif is_player_won is False:
            print("Dealer Blackjack")
        else:
            print("Push!! Player and Dealer Blackjack")
        print()
    else:
        choice = ""
        
        while choice == "":
            print()
            choice = input("Hit or Stand? ((h)it/(s)tand) : ")
            
            if choice.lower() == "hit" or choice.lower() == "h":
                is_break = player_hit(deck,player_hand)
                print()
                print(f"YOUR CARDS:({'/'.join(map(str,player_hand.pointList()))})")
                display_cards(player_hand)
                if is_break:
                    print()
                    print(f"Dealer Cards:({'/'.join(map(str,dealer_hand.pointList()))})")
                    display_cards(dealer_hand)
                    if player_hand.points() == 21:
                        player_stand(deck,dealer_hand)
                        print()
                        print(f"Dealer cards: ({dealer_hand.points()})")
                        display_cards(dealer_hand)       
                    break
                else:
                    choice = ""
            elif choice.lower() == "stand" or choice.lower() == "s":
                player_stand(deck,dealer_hand)
                print()
                print(f"Dealer cards: ({dealer_hand.points()})")
                display_cards(dealer_hand)
                break
            else:
                print("Invalid Entry. Type 'hit' or 'stand'. Try Again!!")
                choice = ""
    print()

    money = get_money(money_filename)
    if get_player_stat(player_hand,dealer_hand) is True:
        print("Player Won!")
        if natural_bj:  
            money = (money + (bet *Decimal("1.5")))
            money = money.quantize(Decimal("1.00"))
        else:
            money = (money+bet).quantize(Decimal("1.00"))
        db.write_file(money_filename,money)
    elif get_player_stat(player_hand,dealer_hand) is False:
        print("Dealer Won!")
        money = (money-bet).quantize(Decimal("1.00"))
        db.write_file(money_filename,money)
    else:
        print("Push!! Player and Dealer tie!!")
            
    print()
    print("Money :",lc.currency(get_money(money_filename),grouping = True))

def check_bj(cards):
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

def get_player_stat(player_hand,dealer_hand):
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
    
def display_cards(hand):
    for card in hand:
        print(card)
        
def player_hit(deck,player_hand):
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

def player_stand(deck,dealer_hand):
    """
    when player chose to stand, new card is drawn from deck to the dealer.
    The dealer stops drwing cards if
    - Dealer hits soft 17 or
    - Busted 
    """
            
    while True:
        if any((i>=17 and i<=21)for i in dealer_hand.pointList()):
            break
        elif all(i>21 for i in dealer_hand.pointList()):
            break
        else:
            dealer_hand.addCard(deck.dealCard())

def check_money_balance(money):
    '''
    Checks if the minimum balce of $5 is maintained. Otherwise prompts the user to buy more chips.
    The game is ended if the player refuse to buy more chips when the balance is under $5.
    '''
    while money < 5:
        print()
        print(f"You are low on chips! ({lc.currency(money)})")
        buy_choice = input("Do you want to buy more chips? (y/n):")
        print()
        if buy_choice.lower() == 'y':
            buy_chips(money_filename)
            money = get_money(money_filename)
        elif buy_choice.lower() == 'n':
            print("Insufficient Balance!")
            exit_game()
        else:
            print("Invalid option! type 'y' or 'n'")
    return money


def exit_game():
    print()
    global stop_time
    stop_time = datetime.now()
    elapsed_time = get_elapsed_time(start_time,stop_time)
    print("Stop time : ",stop_time.strftime("%I:%M:%S %p"))
    print("Elapsed time: ",elapsed_time)
    print()
    print("GAME OVER!\nBye!")
    sys.exit()

def get_elapsed_time(start_time,stop_time):
    elapsed_time = stop_time - start_time
    tot_secs = elapsed_time.total_seconds()
    tot_secs = math.ceil(tot_secs)
    hours = tot_secs//3600
    mins = (tot_secs%3600)//60
    sec =  ((tot_secs%3600)%60)
    formated_elapse = "{:02}:{:02}:{:02}".format(hours,mins,sec)
    return formated_elapse

def main():
    """
    The main function of the blackjack.py
    """
    global game_over
    game_over= False
    display_head()
    money = get_money(money_filename)
    print("Money : ", lc.currency(money,grouping = True))
    money = check_money_balance(money)
    get_bet()
    deck = Deck()
    deck.shuffle()
    while not game_over:
        start_game(deck)
        print()
        while True:
            play_again_choice = input("Play again? (y/n) : ")
            if play_again_choice.lower() == "y":
                if deck.count() <= 15:
                    print("New Deck!")
                    deck = Deck()
                    deck.shuffle()
                print("Great! Let's play again!!")
                print()
                print("~" * 50)
                print()
                print(f"Money : {lc.currency(get_money(money_filename),grouping=True)}")
                print()
                get_bet()
                break
            elif play_again_choice.lower() == "n":
                game_over = True
                exit_game()
            else:
                print("Invalid Option! Type 'y' to play again and 'n' to exit the game!")
    else:
        exit_game()
    
        
if __name__ == "__main__":
    main()
    
