import smtplib
import os
import sys
from resize import resize
from email.mime.text import MIMEText
from email.mime.image import MIMEImage
from email.mime.multipart import MIMEMultipart
from email.header import Header

class sender:
    def __init__(self,ls_of_photos,to,password):
        self.list_of_photos = ls_of_photos
        self.receiver = to
        self.pw = password
    
    def send_email(self):
        gmail_user = 'noreply.photosender@gmail.com'
        gmail_password = self.pw # your gmail password
        msg = MIMEMultipart()
        msg['Subject'] = 'SYSS Photos'
        msg['From'] = gmail_user
        msg['To'] = self.receiver
        msg.attach(MIMEText("""
        The photos selected are listed below. Thank you for using the system!
        If you have any enquiry, please contact Computer Club.
        
        We would appreciate it if you could give me some advice about the User Experience.
        Please spare a little time and fill in the questionnaire below.
        """))
        msg.attach(MIMEText(u'<a href="https://docs.google.com/forms/d/e/1FAIpQLSc98pWBdyFoooQjyEq33VAw3UjJORW6gJIudiN2j5IaP6nwPw/viewform?usp=sf_link">Click Here</a>','html'))
        msg.attach(MIMEText("""
		
        Kind regards
        SYSS Computer Club William and Hardy
        """, 'plain', 'utf-8'))

        for fl in self.list_of_photos:
            resize(fl)
            path=fl
            while path[-1]!='\\':
                path = path[:-1]
            att = MIMEImage(open(path+"___temp.jpg", 'rb').read())
            name = os.path.basename(fl)
            att["Content-Disposition"] = 'attachment; filename='+name
            msg.attach(att)
        try:
            os.remove(path+"___temp.jpg")
        except OSError:
            pass
        server = smtplib.SMTP_SSL('smtp.gmail.com', 465)
        server.ehlo()
        try:
            server.login(gmail_user, self.pw)
        except smtplib.SMTPAuthenticationError:
            print("Wrong Password")
            return False
        server.send_message(msg)

        # try:
        #     smtpObj = smtplib.SMTP('localhost')
        #     smtpObj.sendmail(sender, receivers, message.as_string())
        # except smtplib.SMTPException:
        #     print("ERROR.")
        server.quit()
        return True