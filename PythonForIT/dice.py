import random


class Die:
    def __init__(self):
        self.__value = self.roll()
        self.__image = ""

    @property
    def value(self):
        return self.__value

    @value.setter
    def value(self, value):
        if value < 1 or value > 6:
            raise ValueError("Die can't be less than 1 or greater than 6.")
        else:
            self.__value = value

    def roll(self):
        self.__value = random.randrange(1, 7)
        return self.value

    @property
    def image(self):
        if self.value == 1:
            image = " _____ \n" + \
                    "|     |\n" + \
                    "|  o  |\n" + \
                    "|_____|"
        elif self.value == 2:
            image = " _____ \n" + \
                    "| o   |\n" + \
                    "|     |\n" + \
                    "|____o|"
        elif self.value == 3:
            image = " _____ \n" + \
                    "|o    |\n" + \
                    "|  o  |\n" + \
                    "|____o|"
        elif self.value == 4:
            image = " _____ \n" + \
                    "|o   o|\n" + \
                    "|     |\n" + \
                    "|o___o|"
        elif self.value == 5:
            image = " _____ \n" + \
                    "|o   o|\n" + \
                    "|  o  |\n" + \
                    "|o___o|"
        elif self.value == 6:
            image = " _____ \n" + \
                    "|o   o|\n" + \
                    "|o   o|\n" + \
                    "|o___o|"
        return image



class Dice:
    def __init__(self):
        self.__list = []

    def addDie(self, die):
        self.__list.append(die)

    @property
    def list(self):
        dice_tuple = tuple(self.__list)
        return dice_tuple

    def rollAll(self):
        for die in self.__list:
            die.roll()

    def getTotal(self):
        total = 0
        for die in self.__list:
            total += die.value
        return total

if __name__ == "__main__":
    d = Die()
    print(d.value)

