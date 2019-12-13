import json
import sys
from send import sender

with open("data.json") as json_file:
    data = json.load(json_file)

key=input("Password : ")

for i in data["QUEUE"]:
    receiver = i[0]
    photo_list = i[1]
    main_sender = sender(photo_list,receiver,key)
    print(receiver)
    print(photo_list)
    success_sent = main_sender.send_email()
    if not success_sent:
        print("Wrong Password")
        sys.exit(0)

data = {"QUEUE":[]}

with open("data.json","w") as outfile:
    json.dump(data,outfile)