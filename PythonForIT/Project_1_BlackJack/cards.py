
import random
import sys

def create_deck(no_of_deck=1):
    '''
    This function creates one deck of card(52 cards) by default.
    This function returns deck in the format[[shape,card],...]
    eg. [['hearts','A'],['hearts','2'],..]
    '''
    suit = []
    for i in range(1,14):
        if i == 1:
            suit.append('A')
        elif i == 11:
            suit.append('J')
        elif i == 12:
            suit.append('Q')
        elif i == 13:
            suit.append('K')
        else:
            suit.append(str(i))
##
    shapes = ['hearts','dimonds','spades','clubs']
    deck = []
    for shape in shapes:
        for num in suit:
            card = [shape,num]
            deck.append(card)
            
    return deck*no_of_deck

def add_card_value(add_list):
    """
    This function add the list of cards and returns a list of the sum of the cards.
    The length of the list is >=1 if there is aces, whose value is 1 or 11.
    """

    if len(add_list) == 0:
        return [0]
    
    temp_val_list = []
    for [shape,val] in add_list:
        if val == 'J' or val == 'Q' or val == 'K':
            temp_val_list.append('10')
        else:
            temp_val_list.append(val)
    temp_val_list.sort()

    cnt_A = temp_val_list.count('A')
    total = 0
    if cnt_A == 0:
        for val in temp_val_list:
            total += int(val)
        return [total]
    else:
        i = 0
        while temp_val_list[i] != 'A':
            total += int(temp_val_list[i])
            i += 1
        
        totalA = total
        totalA = total + cnt_A
        if total + 11 + cnt_A - 1 <= 21:
            total = total + 11 + cnt_A - 1
        else:
            total = total+cnt_A

        if total == totalA:
            return [total]
        elif total > 21 or totalA > 21:
            return [min(total,totalA)]
        else:
            return[totalA,total]

def display_cards(disp_card_list):
    """
    This function retuns list of cards in printable format
    """
    return_val = ''
    for card in disp_card_list:
            return_val += '\n' + card[1] + " of " + card[0]
    return return_val

def deal_card(deck,hand_card):
    """
    Card drawn from deck to  hand
    """
    try:
        temp_card = deck.pop(0)
        hand_card.append(temp_card)
    except IndexError:
        print("Unexpected error while dealing Cards - No more cards in deck to deal")
        print("Ending Game now!")
        sys.exit()


def dealer_deals_cards(deck):
    """
    This fuction draws cards from the deck to the player and dealer during the start of each game.
    The cards from the deck is popped and it returns the player and dealer hand cards.
    """
    dealer_cards = []
    player_cards = []
    deal_card(deck,player_cards)
    deal_card(deck,dealer_cards)
    deal_card(deck,player_cards)
    deal_card(deck,dealer_cards)
    return player_cards,dealer_cards

def final_cards_sum(card_list):
    """
    This function determines if Aces in a hand is counted as 1 or 11
    """
    totals = add_card_value(card_list)
    if all(i>21 for i in totals):
           return max(totals)
    while any(i>21 for i in totals):
        totals.remove(max(totals))
    if len(totals) >= 1:
        return max(totals)
                    

if __name__ == "__main__":
    #deck = create_deck()
    #print(deck)
    #sample_list = random.sample(deck,4)
    #sample_list = [['','A'],['','A'],['D','J']]
    sample_list = [['D','J']]
    print(sample_list)
    cards_sum = add_card_value(sample_list)
    print(cards_sum)
    new_list = []
    print(new_list)
    print("calling player_card - and printung new lists")
    #player_card(sample_list,new_list)
    deal_card(sample_list,new_list)
    print(sample_list)
    print(new_list)
    print("calling dealer_card - and printung new lists")
    #dealer_card(sample_list,new_list)
    deal_card(sample_list,new_list)
    print(sample_list)
    print(new_list)
                   
                   
