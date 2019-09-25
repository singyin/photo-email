from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import pickle
import os
import resize
from face import face

class photo:
    def __init__(self, path):
        self.path  = path
        self.name  = path.split('\\')[-1]
        self.faces = []
        self.process()

    def load(path):
        ifile = open(path, 'rb')
        photo = pickle.load(ifile)
        ifile.close()
        return photo

    def process(self):
        resize.resize(self.path)
        img      = fr.api.load_image_file(r'C:\FaceRecognition\photo-email\photo_email\temp\temp.jpg')
        location = fr.api.face_locations(img, number_of_times_to_upsample=1, model='hog')
        encoding = fr.api.face_encodings(img, known_face_locations=location, num_jitters=1)
        for i in range(len(encoding)) :
            self.faces.append(face(self.path, location[i], encoding[i]))

    def save(self, path):
        data_name = self.name + '_data'
        ofile = open(path+'\\'+data_name, 'wb')
        pickle.dump(self, ofile)
        ofile.close

    def match(self, fc, threshold):
        matches = []
        for face in self.faces:
            dist = fc.compare(face)
            if dist <= threshold : matches.append((dist, face))
        if len(matches) > 0:
            matches = sorted(matches, key = lambda x: x[0], reverse=False)
            return matches[0]
        else : return None
