
@echo off
echo dotnet build
dotnet build ../SKSimulator/src/SKSimulator.sln
echo docfx metadata
docfx metadata
echo docfx build
docfx build

if exist docs (
    echo Copying docs to ..\SKSimulator\docs
    xcopy docs ..\SKSimulator\docs /s /e /y /i
) else (
    echo docs directory does not exist.
)

cd ..\SKSimulator
echo git add .
git add .
echo git commit -m "update docs"
git commit -m "update docs"
echo git push
git push
echo cd ..\skm_docs
cd ..\skm_docs