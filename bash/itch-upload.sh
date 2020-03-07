#!/bin/bash
. local.properties
basic="../Builds/Basic"

if [ ! -d $basic ]; then
  echo -e "\e[91mbuild not found\e[0m"
  exit 1
fi

read -p "work with \"$basic\"?"

while getopts "wl" o; do
  case $o in
  w)
    $itch_butler push "$basic/Windows64" "$itch_target:win-x64"
    ;;
  l)
    $itch_butler push "$basic/Linux64" "$itch_target:linux-x64"
    ;;
  esac
done
