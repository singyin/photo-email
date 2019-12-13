from PIL import Image
import os
import sys

def resize(path):
    ii = Image.open(path)
    im = ii.resize((ii.size[0]//2,ii.size[1]//2),Image.NEAREST)
    while (path[-1]!='\\'):
        path = path[:-1]
    im.save(path+'___temp.jpg')

# resize('C:\\Users\\4E14ChuYatHong\\Desktop\\20190909_Prizegiving_ceremony\\_DSC7244.jpg')