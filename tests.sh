#!/bin/bash

set -e

. assert.sh

echo "Tests du comparateur d'images"

assert "./compare.sh TEST1/image1.png TEST1/image1.png" "OK\n0\n"
assert "./compare.sh TEST1/image2.png TEST1/image2.png" "OK\n0\n"
assert "./compare.sh TEST1/image1.png TEST1/image2.png" "OK\n879\n"
assert "cp diff.png localdiff.png"
assert "./compare.sh TEST1/diff.png localdiff.png" "OK\n0\n"

assert_end regression
