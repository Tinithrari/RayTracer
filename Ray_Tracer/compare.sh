cd Ray_Tracer/Ray_Tracer
mdtool build -c:Ray_Tracer.sln > /dev/null
mono bin/Ray_Tracer.exe "../../$1" "../../$2"
