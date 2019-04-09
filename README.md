# Photo Email
A platform written in Python with opencv and face_recognition library, which recognizes students' faces on official photos, and sends their photos to them individually through email.

## Installation
The platform uses the [face_recognition](https://github.com/ageitgey/face_recognition) and [opencv](https://github.com/opencv/opencv) for Python to recognition faces, and uses [Gmail API](https://developers.google.com/gmail/api/) to send emails.

Some libraries are written in C++ and required a C++ compiler and `cmake` to build and link to Python. The steps are as follows:

1. Install Python 3.7
1. Install C++ compiler
1. Install cmake
1. Install libraries by the following commands:

```
pip install opencv-python
pip install dlib
pip install face_recognition
pip install --upgrade google-api-python-client google-auth-httplib2 google-auth-oauthlib
```

## How to Use
...
