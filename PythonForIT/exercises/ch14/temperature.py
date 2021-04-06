class Temp:
    def __init__(self):
        self.__fahrenheit = 32
        self.__celsius = 0

    def getCelsius(self):
        return round(self.__celsius,2)

    def getFahrenheit(self):
        return round(self.__fahrenheit,2)

    def setFahrenheit(self,temp):
        self.__fahrenheit = temp
        celsius = (self.__fahrenheit - 32) * 5 / 9
        self.__celsius = celsius

    def setCelsius(self,temp):
        self.__celsius = temp
        fahrenheit = self.__celsius * 9 / 5 + 32
        self.__fahrenheit = fahrenheit

# the main function is used to test the other functions
# this code isn't run if this module isn't the main module
def main():
    temp = Temp()
    for f in range(0, 212, 40):
        temp.setFahrenheit(f)
        print(temp.getFahrenheit(), "Fahrenheit equals", temp.getCelsius(),"Celsius")

    for c in range(0, 100, 20):
        temp.setCelsius(c)
        print(temp.getCelsius(), "Celsius equals", temp.getFahrenheit(), "Fahrenheit")


# if this module is the main module, call the main function
# to test the other functions
if __name__ == "__main__":
    main()

