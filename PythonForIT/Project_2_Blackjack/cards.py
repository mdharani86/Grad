import random
import sys

def create_deck(no_of_deck=1):
    '''
    This function creates one deck of card(52 cards) by default.
    This function returns deck in the format[[shape,card],...]
    eg. [['hearts','A'],['hearts','2'],..]
    '''
    deck = []
    while len(deck)<(52*no_of_deck):

        suits = ['hearts', 'dimonds', 'spades', 'clubs']
        for suit in suits:
            for rank in range(1, 14):
                card = {}
                if rank == 1:
                    card['suit'] = suit
                    card['rank'] = 'A'
                    card['point'] = [1,11]
                elif rank == 11:
                    card['suit'] = suit
                    card['rank'] = 'J'
                    card['point'] = 10
                elif rank == 12:
                    card['suit'] = suit
                    card['rank'] = 'Q'
                    card['point'] = 10
                elif rank == 13:
                    card['suit'] = suit
                    card['rank'] = 'K'
                    card['point'] = 10
                else:
                    card['suit'] = suit
                    card['rank'] = str(rank)
                    card['point'] = rank
                deck.append(card)
    #
    return deck

def add_card_value(add_list):
    """
    This function add the list of cards and returns a list of the sum of the cards.
    The length of the list is >=1 if there is aces, whose value is 1 or 11.
    """
    cnt_A = 0
    total_point = 0
    for card in add_list:
        if card['rank'] == 'A':
            cnt_A += 1
        else:
            total_point += card['point']
    if cnt_A == 0:
        return [total_point]
    else:
        total_point_A = total_point +cnt_A
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


def display_cards(disp_card_list):
    """
    This function retuns list of cards in printable format
    """
    return_val = ''
    for card in disp_card_list:
        return_val +=  card['rank'] + " of " + card['suit'] + '\n'
    return return_val

def deal_card(deck,hand_card):
    """
    Card drawn from deck to  hand
    """
    try:
        if len(deck) <= 0:
            new_deck = create_deck()
            random.shuffle(new_deck)
            deck.extend(new_deck)
        temp_card = deck.pop(0)
        hand_card.append(temp_card)
        return deck
    except Exception as e:
        print("Unexpected error while dealing card! Terminating game!")
        print("Error:",e)
        sys.exit()


def dealer_deals_cards(deck):
    """
    This fuction draws cards from the deck to the player and dealer during the start of each game.
    The cards from the deck is popped and it returns the player and dealer hand cards.
    """
    dealer_cards = []
    player_cards = []
    deck = deal_card(deck,player_cards)
    deck = deal_card(deck,dealer_cards)
    deck = deal_card(deck,player_cards)
    deck = deal_card(deck,dealer_cards)
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
    deck = create_deck()
    print("deck:",deck)
    print(len(deck))
##    #deck = {}
##    print('~' * 80)
##    random.shuffle(deck)
##    print("shuffled_deck:\n",deck)
##    print('-' * 80)
##    sample_list_size = 53
##    sample_list = []
##    for i in range(sample_list_size):
##            deck = deal_card(deck,sample_list)
####        # sample_list = [deck[1], deck[2], deck[3], deck[4], deck[5]]
##    print("Sample list:\n",sample_list)
##    print('-' * 80)
####    print(display_cards(sample_list))
####    cards_sum = add_card_value(sample_list)
####    print(cards_sum)
##    print(len(sample_list))
##    print('-' * 80)
##    print(deck)
####    print(dealer_deals_cards(deck))

