from matplotlib import pyplot as plt
import face_recognition as fr
import numpy as np
import importlib
import pickle
import os
from photo import photo

class album:
    def __init__(self, folder_path):
        self.name = folder_path.split('\\')[-1]
        self.path = folder_path
        self.photos = []
        self.process()
        
    def load(path):
        ifile = open(path, 'rb')
        album = pickle.load(ifile)
        ifile.close()
        return album

    def process(self):
        img_paths = os.listdir(self.path)
        for img_path in img_paths:
            self.photos.append(photo(os.path.join(self.path, img_path)))

    def save(self, path):
        data_name = self.name + '_data'
        ofile = open(os.path.join(path, data_name), 'wb')
        pickle.dump(self, ofile)
        ofile.close

    def match(self, fc, threshold):
        matches = []
        for photo in self.photos:
            photo_matches = photo.match(fc, threshold)
            if len(photo_matches) > 0:
                matches.append((photo,photo_matches))
        return matches
