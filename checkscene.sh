#!/bin/bash

# Pour connaître l'emplacement du script compare.sh
MYPATH=$(dirname "$0")

# java -Dapple.awt.UIElement=true -cp $MYPATH/bin CheckScene "$1" 2>&1

CURRENT=`pwd`
mono $MYPATH/LanceurRayon/LanceurRayon.Renderer/bin/renderer.exe "$CURRENT/$1" 2>&1