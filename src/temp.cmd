
xcopy skm_docs ..\..\skm_docs /s /e /y /i
cd ..
cd ..
cd skm_docs
call publish.cmd
cd ..\SKSimulator\src