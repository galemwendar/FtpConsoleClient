# FtpConsoleClient

Это небольшой консольный клиент для ftp.

FtpConsoleClient.txt - обязательный текстовый файл с настройками, он должен лежать в одной папке с FtpConsoleClient.exe

Вот его содержание:

-- Это файл настроек программы FtpConsoleClient. Он обязательно должен лежать в одной папке с FtpConsoleClient.exe
-- Клиент умеет проверять и докачивать файлы
-- Кидаться тапками, сообщать об ошибках и сказать спасибо можно в телеграмм @galemwendar
-- сюда писать хост, логин и пароль в соответстующие строки
host:ftp.iiko.ru
user:partners
password:ваш_пароль

-- сюда корневую папку, куда качаете файлы. Указав, например С:\DownloadsForIiko, файл или папка ьудт скачана в С:\DownloadsForIiko\release_iiko\номер версии\...
C:\DownloadsForIiko

-- Сюда писать папку или файл, которую хотите скачать, например /release_iiko/8.2.6007.0/Plugins/Front/Plugin.Front.Api.CustomerScreen
-- Путь до файла или папки обязательно начинать со слэша, как показано на примере, вводить нужно полный путь без хоста.
/release_iiko/8.2.6007.0/Plugins/Front/Plugin.Front.Api.CustomerScreen
/release_iiko/8.2.6007.0/Setup/Offline
