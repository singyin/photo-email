from album import album
import sys
import os

path = sys.argv[1]
alb = album(path)
alb.save()
os.remove(path+"/___temp.jpg")
