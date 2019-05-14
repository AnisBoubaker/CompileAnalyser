<#
Log Collector
Author: Anis Boubaker - École de Technologie Supérieure

This script is intended to collect log related information in C/C++ projects
compiled on Visual Studio (tested on VS2015 & VS2017).

Collected files include all necessary information in order to analyze student
code within and in between compilations. The information include the full source
code (.c, .cpp and .h), as well as any found log file. 

To use this script, we need to make use of the pre/post-compilation hooks in 
Visual Studio. Explanation follows.

Script Arguments: 
1. Project's root directory
2. Project's debug directory 
3. Log ID: unique log identifier. Ex.: username_timestamp.

-- Pre-compile event: -- 
In order to ease the deployment and updates of this script, the pre-compile hook
should verify script existence. In case the script had never been added to the project, 
it should be downloaded from a given URI. 

    If Not Exist "$(IntDir)data_collection.ps1" 
        powershell -Command "Invoke-WebRequest https://URI/data_collection.txt -OutFile $(IntDir)data_collection.ps1"

Note that the script should be stored as a text file on the server for the download
to proceed, as per security restrictions (if we are using IIS as a webserver, not 
tested with other webservers) 

-- Post-compile event: --
powershell -ExecutionPolicy bypass -File $(IntDir)data_collection.ps1 "." 
    "$(IntDir)\" 
    "$([System.Environment]::UserName)_$([System.DateTime]::Now.Year.ToString())$([System.DateTime]::Now.Month.ToString().PadLeft(2, '0'))$([System.DateTime]::Now.Day.ToString().PadLeft(2, '0'))$([System.DateTime]::Now.Hour.ToString().PadLeft(2, '0'))$([System.DateTime]::Now.Minute.ToString().PadLeft(2, '0'))$([System.DateTime]::Now.Second.ToString().PadLeft(2, '0'))"
    >> $(IntDir)data_collection_log.txt
#>

# Project's root folder (1st script argument)
$source = $args[0]
# Location to where all the uploaded information will be moved, prior to compression
# and upload 
$upload_folder = "$($source)\upload"
# Projects's debug directory (2nd script argument)
$debug_dir = $args[1]
# String that uniquely identifies the log collection instance
$log_id = $args[2]
# Uploaded file name (including the extension)
$zip_file_name = "$($log_id).zip"
# Location where the to-be-uploaded file will be stored prior to upload
$zip_file_path = "$($source)\$($zip_file_name)"
# URI of the upload script on the webserver. The script should be able to handle
# POST uploads. Data submitted will include a single file (field name:  "file").
$UploadUri = 'PUT YOUR URL HERE'

# Debug output (should be stored in a log file)
Write-Host "******************************************************************`r"
Write-Host "Source= $source`r";
Write-Host "Debug Folder= $debug_dir`r";
Write-Host "LogId= $log_id`r";
Write-Host "Zip File Path= $zip_file_path`r";

# Collect all compilation related information and store them in the upload folder.
# The folder will be created. If it already exists, it'll be overwritten (-Force).
New-Item -ItemType Directory -Force -Path $upload_folder
#Empty upload folder
Remove-Item -Path $upload_folder\*.*
Copy-Item -Path $source\*.c -Destination $upload_folder
Copy-Item -Path $source\*.cpp -Destination $upload_folder
Copy-Item -Path $source\*.h -Destination $upload_folder
Copy-Item -Path $source\*.xml -Destination $upload_folder
Copy-Item -Path "$($source)\$($debug_dir)*.log" -Destination $upload_folder

# Compress the newly created forder
Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($upload_folder, $zip_file_path)

# Upload the zip file through HTTP
Add-Type -AssemblyName System.Net
Add-Type -AssemblyName System.Net.Http
Try
{
    $http = [System.Net.WebClient]::new()
    $response = $http.UploadFile($UploadUri, $zip_file_path)

    #Delete Log files included in the upload folder
    Remove-Item -Path "$($source)\$($debug_dir)*.log" -ErrorAction SilentlyContinue
}
Catch 
{
    $ErrorMessage = $_.Exception.Message
    $FailedItem = $_.Exception.ItemName
    Write-Host "Error: $ErrorMessage `r"
}
