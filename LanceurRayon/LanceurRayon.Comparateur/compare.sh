cd Ray_Tracer
mdtool build -c:Ray_Tracer.sln
cd ..
mono bin/Ray_Tracer.exe "$1" "$2"
