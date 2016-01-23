mydir=$(dirname "$0")
CURRENT=`pwd`
echo "Coucou"
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.Comparateur > /dev/null
popd
mono $mydir/LanceurRayon/LanceurRayon.Comparateur/bin/comparateur.exe "$CURRENT/$1" "$CURRENT/$2" 2>&1
mv $mydir/LanceurRayon/diff.png $CURRENT/diff.png 