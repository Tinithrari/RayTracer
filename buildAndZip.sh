#!/bin/bash

# Pour connaître l'emplacement du script compare.sh
MYPATH=$(dirname "$0")

# crée un répertoire bin si il n'existe pas

if [ ! -d "$MYPATH/bin" ]; then
   mkdir $MYPATH/bin
fi

# récupère les fichiers à compiler pour Java

# find $MYPATH/src -name *.java -print >$MYPATH/tocompile

# javac -d $MYPATH/bin @$MYPATH/tocompile

CURRENT=`pwd`
pushd $CURRENT
cd "$MYPATH"/LanceurRayon/
mdtool build -p:LanceurRayon.Comparateur 2>&1 > /dev/null
mdtool build -p:LanceurRayon.TestMath 2>&1 > /dev/null
mdtool build -p:LanceurRayon.Renderer 2>&1 > /dev/null
mdtool build -p:LanceurRayon.Lanceur 2>&1 > /dev/null
zip -r LanceurDeRayon.zip LanceurRayon.Lanceur/bin/x86/Release #zip le fichier
mv LanceurDeRayon.zip "$MYPATH"/
popd