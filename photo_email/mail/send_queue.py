import json
import sys
from send import sender

with open("data.json") as json_file:
    data = json.load(json_file)

key=input("Password : ")

for i in data["QUEUE"]:
    receiver = i[0]
    photo_list = i[1]
    print(receiver)
    print(*photo_list,sep='\n')
    while (len(photo_list)>0):
        temp_photo_list = photo_list[:min(30,len(photo_list))]
        if len(photo_list)>=30:
            photo_list = photo_list[30:]
        else:
            photo_list = []
        main_sender = sender(temp_photo_list,receiver,key)
        success_sent = main_sender.send_email()
    if not success_sent:
        print("Wrong Password")
        sys.exit(0)

data = {"QUEUE":[]}

with open("data.json","w") as outfile:
    json.dump(data,outfile)