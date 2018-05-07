REM ~ copy binaries
xcopy /I /Y "trunk\WebExtras.DemoApp\bin\WebExtras*.*" "dist\lib\net45"
xcopy /I /Y "trunk\WebExtras.Nancy\bin\WebExtras*.*" "dist\lib\net45"
del "dist\lib\net45\*.pdb"

REM ~ copy styles
xcopy /I /Y "trunk\WebExtras.DemoApp\Content\webextras.bootstrap*.css" "dist\Content\Css"
xcopy /I /Y "trunk\WebExtras.DemoApp\Content\webextras.gumby*.css" "dist\Content\Css"
xcopy /I /Y "trunk\WebExtras.DemoApp\Content\webextras.jqueryui*.css" "dist\Content\Css"
xcopy /I /Y "trunk\WebExtras.DemoApp\Content\bootstrap*datetimepicker*.css" "dist\Content\Css"
xcopy /I /Y "trunk\WebExtras.DemoApp\Content\jquery.datatables.bootstrap3.css" "dist\Content\Css"

REM ~ copy scripts
xcopy /I /Y "trunk\WebExtras.DemoApp\Scripts\bootstrap*datetimepicker*.js" "dist\Scripts"
xcopy /I /Y "trunk\WebExtras.DemoApp\Scripts\*datatables.bootstrap*.js" "dist\Scripts"
xcopy /I /Y "trunk\WebExtras.DemoApp\Scripts\jquery.flot.axislabels.js" "dist\Scripts"
xcopy /I /Y "trunk\WebExtras.DemoApp\Scripts\jquery.flot.curvedlines.js" "dist\Scripts"
xcopy /I /Y "trunk\WebExtras.DemoApp\Scripts\jquery.flot.dashes.js" "dist\Scripts"

REM ~ copy views
xcopy /I /Y "trunk\WebExtras.DemoApp\Views\Shared\*Datatable*.*" "dist\Views\Shared"

REM ~ create archive
7z a artifacts\WebExtras.zip dist

REM ~ build nuget packages
cd build
nuget pack WebExtras.nuspec -OutputDirectory ..\artifacts
nuget pack WebExtras.Mvc.nuspec -OutputDirectory ..\artifacts
nuget pack WebExtras.Mvc.T4.nuspec -OutputDirectory ..\artifacts
nuget pack WebExtras.Nancy.nuspec -OutputDirectory ..\artifacts
cd ..

REM ~ cleanup
REM ~ rmdir /S /Q dist
