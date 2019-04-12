# from urllib.parse import urlparse

# from email.mime.multipart import MIMEMultipart
# from email.mime.base import MIMEBase
# from email.mime.image import MIMEImage
# from email.mime.text import MIMEText
# import os
# from mimetypes import MimeTypes
# import base64
# def create_message_with_attachment(sender, to, subject, message_text, file):
#   """Create a message for an email.

#   Args:
#     sender: Email address of the sender.
#     to: Email address of the receiver.
#     subject: The subject of the email message.
#     message_text: The text of the email message.
#     file: The path to the file to be attached.

#   Returns:
#     An object containing a base64url encoded email object.
#   """
#   message = MIMEMultipart()
#   message['to'] = to
#   message['from'] = sender
#   message['subject'] = subject

#   msg = MIMEText(message_text)
#   message.attach(msg)
#   # content_type = 'image', encoding = MimeTypes.guess_type(file,None)
#   # if content_type is None or encoding is not None:
#   content_type = 'application/octet-stream'
#   main_type, sub_type = content_type.split('/', 1)
#   fp = open(file, 'rb')
#   msg = MIMEImage(fp.read(), _subtype=sub_type)
#   fp.close()
#   filename = os.path.basename(file)
#   msg.add_header('Content-Disposition', 'attachment', filename=filename)
#   message.attach(msg)

#   return {'raw': base64.urlsafe_b64encode(message.as_string())}

# create_message_with_attachment('sy9660@syss.edu.hk', 'sy9711@syss.edu.hk', 'Test', 'Testing', r'C:\FaceRecongnition\photo-email\tests\blackhole.jpg')

from __future__ import print_function
import httplib2
import os

from apiclient import discovery
from oauth2client import client
from oauth2client import tools
from oauth2client.file import Storage

try:
    import argparse
    flags = argparse.ArgumentParser(parents=[tools.argparser]).parse_args()
except ImportError:
    flags = None

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
CLIENT_SECRET_FILE = r'C:\FaceRecongnition\photo-email\photo_email\mail\credentials.json'
APPLICATION_NAME = 'Gmail API Python Quickstart'
authInst = auth.auth(SCOPES,CLIENT_SECRET_FILE,APPLICATION_NAME)
credentials = authInst.get_credentials()

http = credentials.authorize(httplib2.Http())
service = discovery.build('gmail', 'v1', http=http)

import send_email

sendInst = send_email.send_email(service)
message = sendInst.create_message_with_attachment('sy9711@syss.edu.hk','sy9711@syss.edu.hk','Testing 123','Hi there, This is a test from Python!', r'C:\FaceRecongnition\photo-email\tests\blackhole.jpg' )
sendInst.send_message('me',message)