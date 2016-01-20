2>&1
cd Ray_Tracer
mdtool build -c:Ray_Tracer.sln > /dev/null
mono Ray_Tracer/bin/Ray_Tracer.exe "../$1" "../$2"
