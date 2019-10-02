set ZIP_EXE=C:\Program Files\7-Zip\7z.exe
set ARCHIVE=vsto-pack.zip

del "%ARCHIVE%"
"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.VisualStudio.Tools.Office.targets" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
exit
"%ZIP_EXE%" a vsto-pack.zip "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
exit

"%7Z_EXE%" a vsto-pack.zip "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll"

"%7Z_EXE%" a vsto-pack.zip "C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualStudio.Tools.Office.BuildTasks\v4.0_14.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll"



"%7Z_EXE%" a vsto-pack.zip "c:\Program Files\MSBuild\Microsoft.VisualStudio.OfficeTools.targets"

"%7Z_EXE%" a vsto-pack.zip "c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\Bootstrapper\Packages\VSTOR40\*"


7z a c:\projects\vsto-pack.zip "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll"
7z a c:\projects\vsto-pack.zip "C:\Windows\Microsoft.NET\assembly\GAC_MSIL\Microsoft.VisualStudio.Tools.Office.BuildTasks\v4.0_12.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll"

7z a c:\projects\vsto-pack.zip "Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
7z a c:\projects\vsto-pack.zip "Program Files\MSBuild\Microsoft.VisualStudio.OfficeTools.targets"
7z a c:\projects\vsto-pack.zip "Program Files\Reference Assemblies\Microsoft\VSTO40\*"
7z a c:\projects\vsto-pack.zip "Program Files (x86)\Microsoft Visual Studio 12.0\Visual Studio Tools for Office\PIA\*"
7z a c:\projects\vsto-pack.zip "Program Files (x86)\Microsoft SDKs\Windows\v8.1A\Bootstrapper\Packages\VSTOR40\*"
