from PIL import Image
import os
import sys

def resize(path):
    ii = Image.open(path)
    im = ii.resize((ii.size[0]//2,ii.size[1]//2),Image.NEAREST)
    while (path[-1]!='\\'):
        path = path[:-1]
    im.save(path+'___temp.jpg')
