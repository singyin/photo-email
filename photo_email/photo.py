import face_recognition as fr
from matplotlib import pyplot as plt
import os
import numpy as np
import importlib
from face import *

class Photo:
    def __init__(self, path):
        self.path = path
        self.faces = []
        self.process()

    def process(self):
        img = fr.api.load_image_file(self.path)
        location = fr.api.face_locations(img, model='hog')
        encoding = fr.api.face_encodings(img, known_face_locations=location, num_jitters=5)
        for i in range(len(encoding)) :
            self.faces.append(Face(self.path, location[i], encoding[i]))

