mydir=$(dirname "$0")

cd Ray_Tracer
mdtool build -c:Ray_Tracer.sln > /dev/null
cd ../
mono $mydir/Ray_Tracer/Ray_Tracer/bin/Ray_Tracer.exe "$1" "$2"
