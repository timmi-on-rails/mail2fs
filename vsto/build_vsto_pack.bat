set ZIP_EXE=C:\Program Files\7-Zip\7z.exe
set ARCHIVE=vsto-pack.zip

del "%ARCHIVE%"
"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.VisualStudio.Tools.Office.targets" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"

"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.VisualStudio.Tools.Office.BuildTasks.dll" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.BuildTasks.dll"

"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\MSBuild\Microsoft\VisualStudio\v16.0\OfficeTools\Microsoft.VisualStudio.Tools.Applications.BuildTasks.dll"

"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.Office.Tools.Common.v4.0.Utilities.dll"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.Office.Tools.Common.v4.0.Utilities.dll" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.Office.Tools.Common.v4.0.Utilities.dll"

"%ZIP_EXE%" a "%ARCHIVE%" "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.Office.Tools.Outlook.v4.0.Utilities.dll"
"%ZIP_EXE%" rn "%ARCHIVE%" "Microsoft.Office.Tools.Outlook.v4.0.Utilities.dll" "Program Files (x86)\Microsoft Visual Studio\2019\Preview\Common7\IDE\ReferenceAssemblies\v4.0\Microsoft.Office.Tools.Outlook.v4.0.Utilities.dll"
exit

"%7Z_EXE%" a vsto-pack.zip "c:\Program Files (x86)\Microsoft SDKs\Windows\v8.1A\Bootstrapper\Packages\VSTOR40\*"
7z a c:\projects\vsto-pack.zip "Program Files (x86)\MSBuild\Microsoft\VisualStudio\v12.0\OfficeTools\Microsoft.VisualStudio.Tools.Office.targets"
7z a c:\projects\vsto-pack.zip "Program Files\MSBuild\Microsoft.VisualStudio.OfficeTools.targets"
7z a c:\projects\vsto-pack.zip "Program Files\Reference Assemblies\Microsoft\VSTO40\*"
7z a c:\projects\vsto-pack.zip "Program Files (x86)\Microsoft Visual Studio 12.0\Visual Studio Tools for Office\PIA\*"
7z a c:\projects\vsto-pack.zip "Program Files (x86)\Microsoft SDKs\Windows\v8.1A\Bootstrapper\Packages\VSTOR40\*"
