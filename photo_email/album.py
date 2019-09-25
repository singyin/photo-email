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
            print(img_path)
            if img_path.lower().endswith(('.png', '.jpg', '.jpeg')):
                self.photos.append(photo(self.path+'\\'+img_path))

    def save(self):
        data_name = self.name + '_data'
        ofile = open(self.path+'\\'+data_name, 'wb')
        pickle.dump(self, ofile)
        ofile.close

    def match(self, fc, threshold):
        matches = []

        if isinstance(fc, list):
            for photo in self.photos:
                photo_matches = []
                for f in fc:
                    temp = photo.match(f, threshold)
                    if temp != None: 
                        photo_matches.append(temp)
                if len(photo_matches) >= 1:
                    photo_matches = sorted(photo_matches, key = lambda x: x[0], reverse=False)
                    matches.append((photo, photo_matches[0]))

        else :
            for photo in self.photos:
                photo_match = photo.match(fc, threshold)
                if photo_match != None:
                    matches.append((photo, photo_match))
        return matches

