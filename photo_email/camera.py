# import numpy as np
# import cv2
# import face_recognition as fr
# from face import face
# from album import album
# import sys

# def take_photo(albumPath):
#     img = 0
#     display = 0

#     cap = cv2.VideoCapture(0, cv2.CAP_DSHOW)
#     cv2.namedWindow('camera', cv2.WINDOW_NORMAL)

#     cv2.setWindowProperty('camera',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_FULLSCREEN)
#     cv2.setWindowProperty('camera',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_NORMAL)

#     while(True):
#         # Capture camera-by-camera
#         ret, camera = cap.read()
#         display = camera.copy()
#         location = fr.api.face_locations(display)
#         if len(location) > 0:
#             for fc in location:
#                 display = cv2.rectangle(display, (fc[3], fc[0]), (fc[1], fc[2]), (0,255,0), 4)
        
#         cv2.imshow('camera',display)
#         key = cv2.waitKey(1)

#         if key == ord('q') : 
#             cap.release()
#             cv2.destroyAllWindows()
#             break
#         elif key == ord('c') : img = camera

#     location = fr.api.face_locations(img)
#     encoding = fr.api.face_encodings(img, known_face_locations=location)
#     pht = face(0, location, encoding)

#     alb = album.load(albumPath)
#     for photo in alb.match(pht, 0.8):
#         # continue
#         print(photo[0].path, photo[1][0])


# path = sys.argv[1]
# take_photo(path)



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
    cv2.namedWindow('camera', cv2.WINDOW_NORMAL)

    cv2.setWindowProperty('camera',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_FULLSCREEN)
    cv2.setWindowProperty('camera',cv2.WND_PROP_FULLSCREEN,cv2.WINDOW_NORMAL)

    white = cv2.imread('C:/FaceRecognition/photo-email/photo_email/background.png')

    faces = []
    phrase = 0
    while(True):
        # Capture camera-by-camera
        ret, camera = cap.read()
        display = camera.copy()
        location = fr.api.face_locations(display)
        if len(location) > 0:
            for fc in location:
                display = cv2.rectangle(display, (fc[3], fc[0]), (fc[1], fc[2]), (0,255,0), 4)

        if phrase == 0:
            display = np.concatenate((display[0:480 , 140:500], white, white), axis=1)
        elif phrase == 1:
            display = np.concatenate((faces[0], display[0:480 , 140:500], white), axis=1)
        else:
            display = np.concatenate((faces[0], faces[1], display[0:480 , 140:500]), axis=1)

        
        cv2.imshow('camera',display)
        key = cv2.waitKey(1)

        if key == ord('q'):
            cap.release()
            cv2.destroyAllWindows()
            break
        elif key == ord('c') and len(location) > 0:
            faces.append(camera[0:480 , 140:500])
            if phrase < 2:
                phrase += 1
            else:
                cap.release()
                cv2.destroyAllWindows()
                break
    photo = []
    for f in faces:
        location = fr.api.face_locations(f)
        encoding = fr.api.face_encodings(f, known_face_locations=location)
        # print(encoding)
        photo.append(face(0, location, encoding))
    
    alb = album.load(albumPath)
    ppp = alb.match(photo, 0.6)
#     print(r"""C:\Users\4E14ChuYatHong\Desktop\20190909_Prizegiving_ceremony\_DSC7317.JPG 0.4951498138713914
# C:\Users\4E14ChuYatHong\Desktop\20190909_Prizegiving_ceremony\_DSC7318.JPG 0.502228817791267""")
    # sys.exit()
    for p in ppp:
        print(p[0].path, p[1][0])
    # print(len(ppp))
    # for fff in ppp:
    #     print(fff[0].path,fff[1][0])
path = sys.argv[1]
take_photo(path)
sys.exit()