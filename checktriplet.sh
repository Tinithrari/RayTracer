mydir=$(dirname "$0")
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.TestCalcul 2>&1
popd
echo "DLB special"
mono $mydir/LanceurRayon/LanceurRayon.Calcul/bin/debug/triplet.exe "$1" 2>&1
