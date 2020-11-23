#!/bin/bash

base="$PWD"

cd src/Benday.EasyAuthDemo.Api

dotnet ef migrations add InitialSetup

cd $base