from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import pickle
import os
from photo import photo

class album:
    def __init__(self, folder_path):
        self.name = folder_path.split('/')[-1]
        self.path = folder_path
        self.photos = []
        img_paths = os.listdir(folder_path)
        for img_path in img_paths:
            self.photos.append(photo(os.path.join(folder_path, img_path)))

    def load(path):
        ifile = open(path, 'rb')
        album = pickle.load(ifile)
        ifile.close()
        return album

    def save(self, path):
        ofile = open(path + '/' + self.name + '_data', 'wb')
        pickle.dump(self, ofile)
        ofile.close

    def match(self, fc, threshold):
        matches = []
        for photo in self.photos:
            photo_matches = photo.match(fc, threshold)
            if len(photo_matches) > 0 :
                matches.append((photo,photo_matches))
        return matches