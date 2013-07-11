if "%~1"=="" or "%~2"=="" goto ignore
@echo Start copy all dll in Bin folder of module to Bin folder of Main Web App
robocopy %1\bin %2\bin %3.dll /tee /log+:DeployModules.log /XO 
@echo Start copy all views to views in Main Web App
robocopy %1\Views %2\Views *.cshtml /s /tee /log+:DeployModules.log
@echo Start copy all scripts to Scripts/Modules in Main Web App
robocopy %1\Scripts %2\Scripts\Modules *.js /s /tee /log+:DeployModules.log /XF jquery*.js json2.js json2.min.js knockout*.js modernizr*.js r.js ko*.js infuser*.js require.js TrafficCop*.js _references.js
goto end
:ignore
@echo Error : Invalid destination folder
exit 1
:end

