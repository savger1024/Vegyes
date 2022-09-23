while(True):
    kezdes = input("Helló, mit akarsz?\n1: Egy kis FizzBuzz-t szeretnék!\n")
    if(kezdes == "semmit"): 
        print("Akkor heló")
        break
    elif(kezdes == "1"):
        print("Oké!")
        meddig = input("Hanyadik számig szeretnéd kiiratni?\n")
        meddigInt = int(meddig)
        fizz = input("Hánnyal osztható legyen a Fizz?\n")
        fizzInt = int(fizz)
        buzz = input("Hánnyal osztható legyen a Buzz?\n")
        buzzInt = int(buzz)
        for i in range(1, meddigInt+1):
            if(i % fizzInt == 0 and i % buzzInt == 0):
                print("FizzBuzz!")
            elif(i % fizzInt == 0):
                print("Fizz!")
            elif(i % buzzInt == 0):
                print("Buzz!")
            else:
                print(i)
        orulok = input("Kész! Remélem örülsz az eredménynek! (igen/nem)\n")
