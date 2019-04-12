import face_recognition as fr
from matplotlib import pyplot as plt
plt.style.use('default')
import os
import cv2
import numpy as np

class Photo:
    def __init__(self, path, name):
        self.path = path
        self.name = name
        self.encodings = [];

    def print_name(self) :
        print(self.name)

    def 
