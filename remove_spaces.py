import os
from os import listdir
from os.path import isfile, join
import sys

for i in listdir(sys.argv[1]):
    s=i.replace(' ','_')
    os.rename(sys.argv[1]+'\\'+i,sys.argv[1]+'\\'+s)
