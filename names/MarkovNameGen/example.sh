#!/usr/bin/env bash

seed=$1
if [ "$seed" = "" ]; then
    seed=1024
fi
echo "seed=$seed"
# dotnet run \
#     --sets=american_forenames,american_surnames,clothing,body_parts,colours,breads,irish_forenames,german_forenames,french_forenames,dutch_forenames,norse_deity_forenames,professions,roman_deities,roman_emperor_forenames,russian_forenames,scottish_surnames,theological_demons,theological_angels,werewolf_forenames \
#     --count=40
#     --seed=$seed

dotnet run \
    --sets=websites,cryptocurrencies,unix_commands,american_companies \
    --ignoreSpecial \
    --count=45 \
    --seed=$seed
