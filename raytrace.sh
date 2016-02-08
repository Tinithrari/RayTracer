#!/bin/bash

# Pour connaître l'emplacement du script compare.sh
MYPATH=$(dirname "$0")
CURRENT=`pwd`

# java -Dapple.awt.UIElement=true -jar $MYPATH/dlbraytracer.jar $1 2>&1

mono $MYPATH/LanceurRayon/LanceurRayon.Lanceur/bin/renderer.exe "$CURRENT/$1"
mv $MYPATH/LanceurRayon/$(echo $1 | cut -d. -f1).png $MYPATH/