import numpy as np
import cv2
import face_recognition as fr
from face import face
from album import album
import sys

def take_photo(albumPath):
    img = 0
    display = 0

    cap = cv2.VideoCapture(0, cv2.CAP_DSHOW)
    cv2.namedWindow('frame', cv2.WINDOW_NORMAL)

    cv2.setWindowProperty('frame',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_FULLSCREEN)
    cv2.setWindowProperty('frame',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_NORMAL)

    while(True):
        # Capture frame-by-frame
        ret, frame = cap.read()
        display = frame.copy()
        location = fr.api.face_locations(display)
        if len(location) > 0:
            for fc in location:
                display = cv2.rectangle(display, (fc[3], fc[0]), (fc[1], fc[2]), (0,255,0), 4)
        
        cv2.imshow('frame',display)
        key = cv2.waitKey(1)

        if key == ord('q') : 
            cap.release()
            cv2.destroyAllWindows()
            break
        elif key == ord('c') : img = frame

    location = fr.api.face_locations(img)
    encoding = fr.api.face_encodings(img, known_face_locations=location)
    pht = face(0, location, encoding)

    alb = album.load(albumPath)
    for photo in alb.match(pht, 0.35):
        print(photo[0].path, photo[1][0][0])


path = sys.argv[1]
take_photo(path)