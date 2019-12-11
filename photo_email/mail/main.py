from __future__ import print_function
import httplib2
import sys
import os

from apiclient import discovery
from oauth2client import client
from oauth2client import tools
from oauth2client.file import Storage


# try:
#     import argparse
#     flags = argparse.ArgumentParser(parents=[]).parse_args()
# except ImportError:
#     flags = None
flags=None
import auth
def get_labels():
    results = service.users().labels().list(userId='me').execute()
    labels = results.get('labels', [])
    if not labels:
        print('No labels found.')
    else:
        print('Labels:')
        for label in labels:
            print(label['name'])

SCOPES = 'https://mail.google.com/'
CLIENT_SECRET_FILE = r'credentials.json'
APPLICATION_NAME = 'Gmail API Python Quickstart'
authInst = auth.auth(SCOPES,CLIENT_SECRET_FILE,APPLICATION_NAME)
credentials = authInst.get_credentials()

http = credentials.authorize(httplib2.Http())
service = discovery.build('gmail', 'v1', http=http)

import send_email
sender = "sy9711@syss.edu.hk"
# receiver = "sy9660@syss.edu.hk"
receiver = sys.argv[2]
subject = "SYSS Photos"
content = """
The photos selected are listed below. Thank you for using the system!
If you have any enquiry, please contact Computer Club.

Kind regards
SYSS Computer Club William and Hardy
"""
# python main.py C:\FaceRecongnition\photo-email\ui-csharp\bin\SourcePic\__5.jpg sy9660@syss.edu.hk
# photo_list = [r"C:\FaceRecongnition\photo-email\ui-csharp\bin\SourcePic\__5.jpg"]
photo_list=sys.argv[1].split(';')
# print(photo_list)
# for i in range(len(photo_list)):
#     print(photo_list[i])
#     photo_list[i]=photo_list[i].replace('\\','/')
sendInst = send_email.send_email(service)
message = sendInst.create_message_with_attachment(sender,receiver,subject,content, photo_list)
sendInst.send_message('me',message)