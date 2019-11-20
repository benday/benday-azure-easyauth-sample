#!/bin/bash

base="$PWD"

cd src/Benday.EasyAuthDemo.Api

if [ -z "$1" ] 
  then
    dotnet ef database update
else
    dotnet ef database update $1
fi

cd $base