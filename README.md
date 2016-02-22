UO-International Repository
=====

This is a custom fork of the open source RunUO emulator project that i built.

* Only Felucca facet.
* Pre-Aos expansion status, no insurance, no stats on weapons other than Force, Power, Vanq and accuracy bonus etc.
* No Precasting.
* Redone combat system.
* No Bod. Instead the rewards are craftable.
* No Factions. Only Order/Chaos.

And many more, to see a general view, visit <http://www.ultimaonline.international>

###Build

I did not tested to build on any other system other than Ubuntu amd64 14.10 and greater.

Requirements:

    - mono-complete
    - zlib
    - Ultima Online client files from version 7.0.15.1 or 7.0.15.0 (could work with 7.0.x versions)

zlib is required for certain functionality. Windows zlib builds are packaged with releases and can also be obtained separately here: https://github.com/msturgill/zlib/releases/latest

In the root of the project folder check for the file <https://github.com/emirozer/uo-international/blob/master/RunUO.exe.config> and change the path to libz accordingly.

Compile:

    dmcs -optimize+ -unsafe -t:exe -out:RunUO.exe -win32icon:Server/runuo.ico -nowarn:219,414 -d:MONO -recurse:Server/*.cs

Than you need to set 3 environment variables:

    export UOPATH=/path/to/uo/rootfoolder
    export UOMASTER=masteraccountname
    export UOPASS=masterpassword


You are all set, time to launch the server:

    mono RunUO.exe (while debugging)
    nohup mono RunUO.exe &  (process launch it completely in the background)


Credits;

Thanks to everyone who has been involved in the RunUO emulator development.
This freeshard couldn't have been existed without them..
