@ECHO OFF
:: == Pack.cmd ================================================================
:: Runs:
::  nuget pack <.csproj> -Output <output> <suffixOption> -Properties Configuration=<configuration> -Symbols -IncludeReferencedProjects -Tool
:: 
:: Input:
::  nupkg = <nupkg>
:: ============================================================================

:: == Input ===================================================================
SET nupkg=ProjectEuler
:: ============================================================================

:: == Setup ===================================================================
SET "base=D:\Git\ProjectEuler\"
SET "configuration=%1"
SET "suffixOption="
IF "%configuration%" == "" (
    SET "configuration=Debug"
    SET "suffixOption=-Suffix alpha"
) ELSE (
    SET "configuration=Release"
)

SET "output=%2"
IF "%output%" == "" (
    SET "output=D:\Git\ProjectEuler\.nupkgs"
)
MD %output% 2>NUL
:: ============================================================================

:: == Main ====================================================================
CALL :%nupkg%
CALL :Pack %projectPath%
CALL :Finish
:: ============================================================================

:: == nupkg ===================================================================
:ProjectEuler
SET projectPath="%base%ProjectEuler\ProjectEuler.csproj"
GOTO :EOF
:: ============================================================================

:Pack
SETLOCAL
SET projectPath=%1
nuget pack "%projectPath%" -Output %output% %suffixOption% -Properties Configuration=%configuration% -Symbols -IncludeReferencedProjects -Tool
ENDLOCAL
GOTO :EOF

:Finish
PAUSE