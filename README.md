# Photo Email
A platform written in Python with opencv and face_recognition library, which recognizes students' faces on official photos, and sends their photos to them individually through email.

## Installation
The platform uses the [face_recognition](https://github.com/ageitgey/face_recognition) and [opencv](https://github.com/opencv/opencv) for Python to recognition faces, and uses [Gmail API](https://developers.google.com/gmail/api/) to send emails.

Some libraries are written in C++ and required a C++ compiler and `cmake` to build and link to Python. The steps are as follows:

1. https://cmake.org/download/ - Install CMake
2. Visual Studio import installation config : project.vsconfig - Install necessary modules for C#
3. pip install dlib matplotlib numpy importlib pickle-mixin pillow opencv-python smtp-mail pyperclip face_recognition - Install necessary modules for Python

## How to Use

-**Initialization**:
Input path of **Python3** to photo-email/paths/default_python_path

-**Preloading the photos**:
Preload the photos by pasting the directory on the *Preloader*
Input the encodings file to photo-email/paths/photo_collection_path

-**Choosing the photos**:
Start *UICSharp* and enter the school ID (eg sy12345 -> 12345)
Press **c** to take face photos, for **3** times

-**Sending emails**:
Run *send_queue.py* and enter password

-**Redirect the paths**:
Replace photo-email/photo_email/mail/data.json with the new data.json
In order to redirect the paths, run **changelistpath.py** and paste the directory that contains the photos into it.
After that you can just run **send_queue.py** to send the emails

## Classes

The major classes and their interface are shown below:

**Face** represents a face and its encoding.
```python
Face
  # Constructor and factory methods
  __init__(path, pos, encoding)   # Intantiates a face

  # Attributes
  path          # Path of the image file
  pos           # Position of the face in the image
  encoding      # Encoding of the face

  # Methods
  compare(face) # Compares this face with another face and return the dist
```

**Photo** represents a photo and all the faces and encodings in it.
```python
Photo
  # Constructor and factory methods
  __init__(path)          # Constructs a photo from an image file and locates all faces and encodings
  load(path)              # Loads a photo from an object file 

  # Attributes
  name                    # Name of the image file
  path                    # Path of the image file
  faces: [...face]        # A list of faces located in the photo

  # Methods
  save(path)              # Saves this object to path
  match(face, threshold)  # Matches the face and returns a list of dists and faces within threshold
    => [...(dist, face)]
```

**Album** represents an album which contains a list of photos.
```python
Album
  # Constructor and factory methods
  __init__(folder)        # Constructs an album from an image folder and locates all faces and encodings in the images
  load(path)              # Loads an album from an object file

  # Attributes
  name                    # Name of the album
  path                    # Path of the image folder
  photos: [...photo]      # A list of photos constructed from the image files

  # Methods
  save(path)              # Saves this object to path
  match(face, threshold)  # Matches the face and returns a list of photos with dists and faces within threshold
    => [...(photo, matches: [...(dist, face)]) ]
```

**Group** represents a group of photos contains single faces for training and matching.
```python
Group
  # Constructor and factory methods
  __init__(folder)        # Constructs a group from an image folder and locates all faces and encodings in the images
  load(path)              # Loads a group from an object file

  # Attributes
  name                    # Name of the group
  path                    # Path of the image folder
  photos: [...photo]      # A list of photos constructed from the image files
  faces: [...face]        # A list of faces from the image

  # Methods
  save(path)              # Saves this object to path
```

**Mail** represents an email client which sends matched photos to user through email.
```python
Mail
  # Constructor and factory methods
  __init__()              # Constructs an email client

  # Attributes
  service                 # Gmail API service

  # Methods
  send(name, email, photos)   # Send email
```

**Client** represents a user-interface to use the system.

## Roadmap
...