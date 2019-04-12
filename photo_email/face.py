import face_recognition as fr
from matplotlib import pyplot as plt
plt.style.use('default')
import os
import cv2
import numpy as np

class Face :
    def __init__(self, path, pos, encoding):
        self.path = np.array(path)
        self.pos = pos
        self.encoding = encoding

    def compare(self, other_face):
        return (fr.api.face_distance(np.array([other_face.encoding]), self.encoding)[0])
