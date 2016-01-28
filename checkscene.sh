#!/bin/bash

# Pour connaître l'emplacement du script compare.sh
MYPATH=$(dirname "$0")

# java -Dapple.awt.UIElement=true -cp $MYPATH/bin CheckScene "$1" 2>&1

CURRENT=`pwd`
pushd
cd "$mydir"/LanceurRayon/
mdtool build -p:LanceurRayon.Renderer 2>&1
popd
mono $mydir/LanceurRayon/LanceurRayon.Renderer/bin/renderer.exe "$CURRENT/$1" 2>&1