from PIL import Image
import os
import sys

def resize(path):
    ii = Image.open(path)
    im = ii.resize((ii.size[0]//3,ii.size[1]//3),Image.NEAREST)
    im.save('C:\\FaceRecognition\\photo-email\\photo_email\\temp\\temp.jpg')

# resize('C:\\Users\\4E14ChuYatHong\\Desktop\\20190909_Prizegiving_ceremony\\_DSC7244.jpg')