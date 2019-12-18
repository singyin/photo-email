import json
import os
import pyperclip

directory = input("Directory to photos file")
def process(s):
    if "\\" in s:
        s=s[s.rindex("\\")+1:]
    if os.path.exists(directory+"\\"+s):
        return s
    else:
        return "ERROR"

with open("data.json") as json_file:
    data = json.load(json_file)
for i in range(len(data["QUEUE"])):
    data["QUEUE"][i][1]=[directory+process(path) for path in data["QUEUE"][i][1]]
    if "ERROR" in data["QUEUE"][i][1]:
        data["QUEUE"][i][1].remove("ERROR")
with open("data.json","w") as outfile:
    json.dump(data,outfile)
input("Data.json modified.       Press Enter to continue...")