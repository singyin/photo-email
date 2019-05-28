import numpy as np
import cv2
import face_recognition as fr
from face import face
from album import album


def take_photo_get_path_from(albumPath):

    img = 0
    display = 0

    cap = cv2.VideoCapture(0)
    while(True):
        # Capture frame-by-frame
        ret, frame = cap.read()
        display = frame.copy()
        location = fr.api.face_locations(display)
        if len(location) > 0:
            for fc in location:
                display = cv2.rectangle(display, (fc[3], fc[0]), (fc[1], fc[2]), (0,255,0), 5)

        cv2.imshow('frame',display)
        key = cv2.waitKey(1)

        if   key == ord('q') : break
        elif key == ord('c') : img = frame
        # When everything done, release the capture
    cap.release()
    cv2.destroyAllWindows()
    cv2.imshow('image', img)
    cv2.waitKey()
    cv2.destroyAllWindows()

    location = fr.api.face_locations(img)
    encoding = fr.api.face_encodings(img, known_face_locations=location)
    pht = face(0, location, encoding)

    alb = album.load(albumPath)

    for photo in alb.match(pht, 0.6):
        print(photo[0].path)

take_photo_get_path_from_album('C:/FaceRecognition/photo-email/tests/photos/album/train_data');