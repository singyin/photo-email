import cv2
import face_recognition as fr
import numpy as np
from PIL import Image
import os
import matplotlib
# path = 'Azusa_Nakano_new_mugshot.png'
# img = Image.open(r'Azusa_Nakano_new_mugshot.png')
# img.show()




#Photo plotting
path = r''
#Photo Capturing Part
"""cam = cv2.VideoCapture(0)
cv2.namedWindow("test")
img_counter = 0
while True:
    ret, frame = cam.read()
    cv2.imshow("test", frame)
    if not ret:
        break
    k = cv2.waitKey(1)

    if k%256 == 27:
        # ESC pressed
        print("Escape hit, closing...")
        break
    elif k%256 == 32:
        # SPACE pressed
        img_name = "opencv_frame_{}.png".format(img_counter)
        cv2.imwrite(img_name, frame)
        print("{} written!".format(img_name))
        img_counter += 1"""

#camera testing
"""import cv2
import face_recognition as fr
import numpy as np

cv2.namedWindow("preview")
webcam=cv2.VideoCapture(0)

if webcam.isOpened():
    rval, frame = webcam.read()
else:
    ravl = False
while rval:
    cv2.imshow("preview",frame)
    rval, frame = webcam.read()
    key = cv2.waitKey(20)
    if key == 27:
        break
cv2.destroyWindow("preview")"""