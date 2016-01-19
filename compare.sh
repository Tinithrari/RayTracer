#!/bin/bash
IMAGE1=$1
IMAGE2=$2

# Pour connaître l'emplacement du script compare.sh
MYPATH=$(dirname "$0")

# java -cp $MYPATH/bin CompareImage $IMAGE1 $IMAGE2
mdtool build -c:Ray_Tracer/Ray_Tracer.sln
mono ../bin/Ray_Tracer.exe "$1" "$2"
