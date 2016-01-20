mydir=$(dirname "$0")
pushd
cd "$mydir"/Ray_Tracer
mdtool build -c:Ray_Tracer.sln
popd
pwd
mono $mydir/Ray_Tracer/Ray_Tracer/bin/Ray_Tracer.exe "$1" "$2"
