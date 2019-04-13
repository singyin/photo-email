from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import pickle
import os
from face import Face

class Photo:
    def __init__(self, path):
        self.path = path
        self.name = path.split('/')[-1]
        self.faces = []
        self.process()

    def load(path):
        ifile = open(path, 'rb')
        file = pickle.load(ifile)
        ifile.close()
        return file

    def process(self):
        img = fr.api.load_image_file(self.path)
        location = fr.api.face_locations(img, model='hog')
        encoding = fr.api.face_encodings(img, known_face_locations=location, num_jitters=5)
        for i in range(len(encoding)) :
            self.faces.append(Face(self.path, location[i], encoding[i]))

    def save(self, path):
        ofile = open(path + '/' + self.name + '_data', 'wb')
        pickle.dump(self, ofile)
        ofile.close
