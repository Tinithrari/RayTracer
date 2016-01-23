#!/bin/bash
mydir=$(dirname "$0")
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.TestMath
popd

mono $mydir/LanceurRayon/LanceurRayon.Calcul/bin/debug/triplet.exe "$1" 2>&1

