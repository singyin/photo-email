import json
import sys

lst = sys.argv[1].split(';')
receiver = sys.argv[2]

with open('../../../photo_email/mail/data.json') as json_file:
    data = json.load(json_file)

data["QUEUE"].append([receiver,lst])

with open('../../../photo_email/mail/data.json','w') as outfile:
    json.dump(data,outfile)

with open("data.json","w") as outfile:
    json.dump(data,outfile)