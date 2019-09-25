from album import album
import sys

path = sys.argv[1]
alb = album(path)
alb.save()