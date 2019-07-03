from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import pickle
import os
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
        img      = fr.api.load_image_file(self.path)
        location = fr.api.face_locations(img, number_of_times_to_upsample=2, model='hog')
        encoding = fr.api.face_encodings(img, known_face_locations=location, num_jitters=5)
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
        return matches
