mydir=$(dirname "$0")
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.TestMath > /dev/null
popd
mono $mydir/LanceurRayon/LanceurRayon.Calcul/bin/triplet.exe "$1" 2>&1