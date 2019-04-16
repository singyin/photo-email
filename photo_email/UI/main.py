from kivy.app import App
from kivy.properties import StringProperty
from kivy.config import Config
from kivy.core.text import LabelBase
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.screenmanager import ScreenManager, Screen, SlideTransition
import os
from connected import Connected
LabelBase.register(name='adventpro',fn_regular="adventpro-bold.ttf")
Config.set('graphics', 'resizable', False)
class Login(Screen):
    def do_login(self, loginText):
        app = App.get_running_app()
        app.username = loginText
        self.manager.transition = SlideTransition(direction="left")
        if (app.username.isdigit()):
            self.manager.current = 'connected'
        app.config.read(app.get_application_config())
        app.config.write()

    def resetForm(self):
        self.ids['login'].text = ""

class LoginApp(App):
    username = StringProperty(None)

    def build(self):
        manager = ScreenManager()

        manager.add_widget(Login(name='login'))
        manager.add_widget(Connected(name='connected'))

        return manager

    def get_application_config(self):
        if(not self.username):
            return super(LoginApp, self).get_application_config()

        conf_directory = self.user_data_dir + '/' + self.username

        if(not os.path.exists(conf_directory)):
            os.makedirs(conf_directory)

        return super(LoginApp, self).get_application_config(
            '%s/config.cfg' % (conf_directory)
        )

if __name__ == '__main__':
    LoginApp().run()