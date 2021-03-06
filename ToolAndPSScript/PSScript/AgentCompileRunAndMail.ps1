$AutomationDir = "C:\Automation\AppWarp_WP7_SDK\AppWarpWinDesktop"
$TestDir = "C:\Test"

echo "Getting latest code of client"
cd C:\Automation\AppWarp_WP7_SDK\AppWarpWinDesktop
git pull

echo "Compiling AppWarp Client"
msbuild $AutomationDir\AppWarpWinDesktop.sln /t:Rebuild
echo CopyingNewBuilt dll To Test Folder 
Copy $AutomationDir\AppWarpWinDesktop\bin\Debug\AppWarpWinDesktop.dll $TestDir\AppWarpWinDesktop.dll
Copy $AutomationDir\AppWarpWinDesktopTest\bin\Debug\AppWarpWinDesktopTest.dll $TestDir\AppWarpWinDesktopTest.dll

echo RunningUnitTest
cd "C:\Program Files\NUnit 2.6.2\bin"
./nunit-console.exe /xml:$TestDir\newresults.xml $TestDir\AppWarpWinDesktopTest.dll /out:C:\Test\AppWarpTestResult.txt
cd $TestDir
nant
C:\Test\PSScript\SendMailHtmlReport.ps1