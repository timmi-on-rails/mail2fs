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
