cls
Remove-Item C:\Test\AppWarpDesktopOld.log
Rename-Item C:\Test\AppWarpDesktop.log AppWarpDesktopOld.log
New-Item C:\Test\AppWarpDesktop.log -type file