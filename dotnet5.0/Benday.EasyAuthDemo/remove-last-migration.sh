#!/bin/bash

base="$PWD"

cd src/Benday.EasyAuthDemo.Api

dotnet ef migrations remove

cd $base