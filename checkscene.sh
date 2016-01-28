mydir=$(dirname "$0")
CURRENT=`pwd`
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.Renderer > /dev/null
popd
mono $mydir/LanceurRayon/LanceurRayon.Renderer/bin/comparateur.exe "$CURRENT/$1" "$CURRENT/$2" 2>&1
