"""
This Module contains main logic of the blackjack game.
The Value of Ace is 1 or 11 - determined by the cards drawn by dealer/player
"""

import cards
import random
import db
import sys

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
    print()

def get_bet():
    """
    This fuction get bet amount from the the user terminal and stores it as a float value in the global variable 'bet'
    """
    global game_over,bet
    valid_bet = False
    while not valid_bet:
        try:
            money = get_money(money_filename)
            while money < 5:
                print(f"You are low on chips. You have {money} balance.")
                buy_choice = input("Do you want to buy more chips? (y/n) :")
                print()
                if buy_choice == 'y':
                    buy_chips(money_filename)
                    money = get_money(money_filename)
                elif buy_choice == 'n':
                    print("Insufficeint Balance! You cannot continue the game!")
                    game_over = True
                    exit_game()
                else:
                    print("Invalid entry! Type 'y' or 'n'. Try again!!")
            
            bet = float(input("Bet amount : "))
            if (bet < 5) or (bet > 1000):
                print("Invalid bet! Minimum bet amount is 5 and maximum bet amount is 1000!")
                print()
                continue
            if bet > money:
                print(f"Bet amout is greater than the actual amount! ({money})")
                print("Lower your bet!")
                print()
                continue
            valid_bet = True
        except (ValueError, TypeError) as e:
            #print(e)
            print("Invalid value entered! Try again!")
        except Exception as e:
            print("Unexpected error occured while getting bet. Terminating game!")
            print(type(e),e)
            sys.exit()
            
def get_money(filename):
    money = db.read_file(filename)
    if money == None:
        print("File not found  or Empty Input file")
        print("Creating a new money file with balance $0.0")
        db.write_file(filename,'0')
        print("Success! Money file created with zero balance!")
        money = float(db.read_file(filename))
    else:
        try:
            money = float(money)
        except (ValueError,TypeError):
            print("Invalid money in the input file")
            global game_over
            game_over = True
            return db.read_file(filename)
        except Exception as e:
            print("Unexpected error occured while getting money. Terminating game!")
            print(type(e),e)
            sys.exit()
    return money

def is_valid_money(money):
    """
    This function validates if the money in input file can be converted to float/int type
    """
    global game_over
    if money == None:
        game_over = True
        print("Input money file not found")
        return False
    else:
        try:
            money = float(money)
        except (ValueError,TypeError):
            game_over = True
            print("Invalid money in the input file!")
            print("Data cannot be converted to Money!!")
            #print(f"Content: {money}, type(content): {type(money)}")
            return False
        except Exception as e:
            print("Unexpected error occured while validating money. Terminating game!")
            print(type(e),e)
            sys.exit()
    return True

def buy_chips(filename):
    while True:
        try:
            amt = float(input("Enter the amount/value to buy chips: "))
            amt = round(amt,2)
            if amt >= 0:
                break
            else:
                print("Money cannot be nagative. Try Again!")
        except (ValueError,TypeError):
            print("Invalid Amount entered! Try Again!")
        except Exception as e:
            print("Unexpected error occured while buying chips. Terminating game!")
            print(type(e),e)
            sys.exit()
    money = get_money(filename)
    money += amt
    db.write_file(filename,money)
    print(f"Transaction success! You have chip value of {money}.")

def start_game(deck):

    """
    This function has the main flow of the blacjack game using the deck of cards as argument
    The money in the money.txt is updated based on the game result and bet amount
    """

    global game_over
    
    player_cards,dealer_cards = cards.dealer_deals_cards(deck)
    dealer_sum = cards.add_card_value(dealer_cards[0:1])
    player_sum = cards.add_card_value(player_cards)
    
    print()
    print(f"DEALER'S SHOW CARD: ({'/'.join(map(str,dealer_sum))})")
    print(cards.display_cards(dealer_cards[0:1]))
    print()
    print(f"YOUR CARDS:({'/'.join(map(str,player_sum))})")
    print(cards.display_cards(player_cards))

    is_player_bj = check_bj(player_cards)
    is_dealer_bj = check_bj(dealer_cards)
    
    natural_bj = False
    if is_player_bj or is_dealer_bj:  #Natural Blackjack
        natural_bj = True
        print()
        print(f"Dealer cards: ({cards.final_cards_sum(dealer_cards)})")
        print(cards.display_cards(dealer_cards))
        print()
        if get_player_stat(player_cards,dealer_cards) is True:
            print("Player natural Blackjack")
        elif get_player_stat(player_cards,dealer_cards) is False:
            print("Dealer natural Blackjack")
        else:
            print("Push!! Player and Dealer natural Blackjack")
        print()
    else:
        choice = ""
        
        while choice == "":
            print()
            choice = input("Hit or Stand? ((h)it/(s)tand) : ")
            
            if choice.lower() == "hit" or choice.lower() == "h":
                is_break = player_hit(deck,player_cards)
                print()
                print(f"YOUR CARDS:({'/'.join(map(str,cards.add_card_value(player_cards)))})")
                print(cards.display_cards(player_cards))
                if is_break:
                    print()
                    print(f"Dealer Cards:({'/'.join(map(str,cards.add_card_value(dealer_cards)))})")
                    print(cards.display_cards(dealer_cards))
                    if cards.final_cards_sum(player_cards) == 21:
                        player_stand(deck,dealer_cards,player_cards)
                        print()
                        print(f"Dealer cards: ({cards.final_cards_sum(dealer_cards)})")
                        print(cards.display_cards(dealer_cards))        
                    break
                else:
                    choice = ""
            elif choice.lower() == "stand" or choice.lower() == "s":
                player_stand(deck,dealer_cards,player_cards)
                print()
                print(f"Dealer cards: ({cards.final_cards_sum(dealer_cards)})")
                print(cards.display_cards(dealer_cards))
                break
            else:
                print("Invalid Entry. Type 'hit' or 'stand'. Try Again!!")
                choice = ""
    print()

    money = get_money(money_filename)
    if get_player_stat(player_cards,dealer_cards) is True:
        print("Player Won!")
        if natural_bj:  
            money = round((money + (bet *1.5)),2)
        else:
            money = round((money+bet),2)
        db.write_file(money_filename,money)
    elif get_player_stat(player_cards,dealer_cards) is False:
        print("Dealer Won!")
        money = round((money - bet),2)
        db.write_file(money_filename,money)
    else:
        print("Push!! Player and Dealer tie!!")
            
    print()
    print("Money :",get_money(money_filename))

def check_bj(card_list):
    """
    This function checks if the total value of card is 21 and returns True or False"
    """
    bj = False
    total = cards.add_card_value(card_list)
    if 21 in total:
        bj = True
    else:
        bj = False
        
    return bj

def get_player_stat(player_cards,dealer_cards):
    """
    This function check if player won or not or if there is a tie. It returns
    True  - when player wins
    False - when player loses
    None  - when tie between player and dealer
    """
    player_total = cards.final_cards_sum(player_cards)
    dealer_total = cards.final_cards_sum(dealer_cards)
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
    

def player_hit(deck,player_cards):
    """
    when player chose to hit, new card is drawn from deck. This function returns
    True - if the player can hit again
    False - if the player is bust or has a total card value of 21
    """
    cards.deal_card(deck,player_cards)
    if (all(i > 21 for i in cards.add_card_value(player_cards))) \
        or (21 in cards.add_card_value(player_cards)):
        return True
    else:
        return False

def player_stand(deck,dealer_cards,player_cards):
    """
    when player chose to stand, new card is drawn from deck to the dealer.
    The dealer stops drwing cards if
    - Dealer hits soft 17 or
    - Busted 
    """
    player_val = cards.final_cards_sum(player_cards)
            
    while True:
        if any((i>=17 and i<=21)for i in cards.add_card_value(dealer_cards)):
            break
        elif all(i>21 for i in cards.add_card_value(dealer_cards)):
            break
        else:
            pass
##            if final_cards_sum(player_cards) < final_cards_sum(dealer_cards):
##                break
        cards.deal_card(deck,dealer_cards)


def exit_game():
    print()
    print("GAME OVER!")
    sys.exit()

def main():
    """
    The main function of the blackjack.py
    """
    global game_over
    game_over= False
    display_head()
##    money = 100                #resets the money to 100 for new game
##    db.write_file(money_filename,money)
    money = get_money(money_filename)
    print("Money : ", money)
    if is_valid_money(money):
        while money < 5:
            print(f"You are low on chips! ({money})")
            buy_choice = input("Do you want to buy more chips? (y/n):")
            print()
            if buy_choice.lower() == 'y':
                buy_chips(money_filename)
                money = get_money(money_filename)
            elif buy_choice.lower() == 'n':
                print("Insufficient Balance!")
                game_over = True
                exit_game()
            else:
                print("Invalid option! type 'y' or 'n'")
        get_bet()
        deck = cards.create_deck(1)
        random.shuffle(deck)
    else:
        game_over= True
    while not game_over:
        start_game(deck)
        print()
        while True:
            play_again_choice = input("Play again? (y/n) : ")
            if play_again_choice.lower() == "y":
                if len(deck) <= 15:
                    print("New Deck!")
                    deck = cards.create_deck()
                    random.shuffle(deck)
                print("Great! Let's play again!!")
                print("~" * 50)
                print()
                print(f"Money : {get_money(money_filename)}")
                print()
                get_bet()
                break
            elif play_again_choice.lower() == "n":
                game_over = True
                break
            else:
                print("Invalid Option! Type 'y' to play again and 'n' to exit the game!")

    else:
        print("GAME OVER!")
        print("Bye!!")
    
        
if __name__ == "__main__":
    main()
    
