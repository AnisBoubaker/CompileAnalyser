# README: Loc collection script

The powershell script (data_collection.ps1) is invoked for each VS compilation as a PostBuildEvent. 
For this script to be present in project files, a PreBuildEvent check its existence and if necessary downloads it from a web server. 

(see Project1.vcxproj PreBuild and PostBuild events, from Template directory). 
