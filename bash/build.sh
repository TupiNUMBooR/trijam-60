#!/usr/bin/env bash
. local.properties

build-one() {
  tail -F ~/.config/unity3d/Editor.log &
  tp=$(echo "$!")
  
  $unity_editor -quit -batchmode -nographics -executeMethod Editor.Builder.BuildDefault
  
  kill $tp
}

git status
#[ ! -z "$(git status --porcelain)" ] && exit 1

echo -e "\e[36m========== Building basic ==========\e[0m"
read -p "continue?"
build-one
