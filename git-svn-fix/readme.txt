When using the git svn fetch you may encounter the error "can't locate config_heavy.pl in @INC ... at /usr/lib/perl5/5.8.8/msys/Config.pm line 66".

You can fix the error by downloading the zip-file and extracting it into the following folder: C:\Program Files (x86)\Git

You can check if the installation succeeded by making sure that the file Config_heavy.pl exists in the folder C:\Program Files (x86)\Git\lib\perl5\5.8.8\msys