from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import os

class Face :
    def __init__(self, path, pos, encoding):
        self.path = np.array(path)
        self.pos = pos
        self.encoding = encoding

    def compare(self, other_face):
        return (fr.api.face_distance(np.array([other_face.encoding]), self.encoding)[0])
