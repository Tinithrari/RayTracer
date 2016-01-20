mydir=$(dirname "$0")
CURRENT=`pwd`
pushd
cd "$mydir"/Ray_Tracer
mdtool build -c:Ray_Tracer.sln > /dev/null
popd
mono $mydir/Ray_Tracer/Ray_Tracer/bin/Ray_Tracer.exe "$CURRENT/$1" "$CURRENT/$2" 2>&1
mv $mydir/Ray_Tracer/diff.png $CURRENT/diff.png 