mydir=$(dirname "$0")
pushd
cd "$mydir"/Ray_Tracer
mdtool build -c:Ray_Tracer.sln > /dev/null
popd
mono $mydir/Ray_Tracer/Ray_Tracer/bin/Ray_Tracer.exe `pwd`/"$1" `pwd`/"$2" 2>&1