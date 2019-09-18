import pyperclip
kk= input()
pyperclip.copy(kk.replace('\\','/')+'/'+kk.split('\\')[-1]+'_data')