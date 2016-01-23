mydir=$(dirname "$0")
CURRENT=`pwd`
pushd
cd "$mydir"/LanceurRayon/
mdtool build -c:LanceurRayon.sln
popd
mono $mydir/LanceurRayon/LanceurRayon.Comparateur/bin/comparateur.exe "$CURRENT/$1" "$CURRENT/$2" 2>&1
mv $mydir/LanceurRayon/diff.png $CURRENT/diff.png 