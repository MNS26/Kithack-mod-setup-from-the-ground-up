# THIS REPO IS AN UNOFFICIAL ONE (USE AT YOUR OWN RISK... IT MAY NOT WORK AT ALL)
Now that thats out of the way... lets setup a semi-automated enviorment for making and updating mods (and have intelli sense work as well)


### software/tools needed
* **An operating system (ghasp)**<br/>
    Windows and Linux (what i use) will work.
    I dont have any macOS system to test it on but should be very similair to the linux steps (since its basically the same but overpriced and w/o repair options)<br/>
    *now that the apple fanboys(or girls... i wont judge) are riled up let's continue*

* **KitHack (obviously)**<br/>
    <sup>(Oh dont worry this isnt the end of me yet)</sup><br/>
    *Whoever wrote this i will find you and install Windows on your PC and delete all your drivers*

* **Visual Studio/VSCode**<br/>
    **Windows:** You can choose either one, I wont be able to help setup Visual Studio since thats not available for me but there are thousands of guides for installing and setting up C#
    **Linux/macOS:** I would reccomend VSCode since thats what i used to set this up with. (there are online guides on how to set it up for C# development)

* **command prompt/terminal**</br>
    We will use this later on to link the build folder(s) to one output folder so its easy to make new mods.


## Setup the enviorment

### 1. Folder prep
Open up you file browser and make a folder where you want to set this up.
(On Windows i would reccomend NOT having it in the `Documents` folder since its usually connected to OneDrive and it might break stuff.)<br/>
<sup>Dont listen to him... you can put it whhheeereeever you want</sup><br/>
*I WILL install Windows......*

The initial folder structure should be as follows (i would also reccomend naming it the same too):
```
KitHack Mods
|-External
```

### 2. Linking mod export and mod dependencies
Now its time to get the terminal/command prompt out.<br/>
<sup>Dont worry i wont be installing a backdoor on ya system... thats what the NSA already did</sup><br/>
_... You know what. Im going to deal with you **later**..._<br/>
<sup>oh shit</sup>

**Windows:** In your file browser go to the folder where you installed the game and open the `KitHash Model Club_Data` folder.
    In there should be a folder called `Managed` keep note of this folder.
    Now open another window and go to the folder called `External` that we just created.
    *time to enter hacker mode with the command prompt*<br/>
    <sup>awww look at him getting all excited about Windows</sup><br/>
    _.... **ONE** more word and i **WILL** nuke your ass back to the stone age and make that "homework" folder of yours public to the whole world_<br/>
    <sup>wait what!? How do you know about my...</sup><br/>
    _Oh dont worry..... be quiet and nothing will happen. ok? ^\_^_<br/>
    <sup>.......</sup><br/>
    _Now with that taken care of lets continue_<br/>
    Type in `mklink /j` and add a space.
    Next drag the folder called `Managed` into the command prompt. 
    Next add a space after this and drag the folder called `External` that we made into the command prompt and press enter.
    <br/>
    (breakdown of the command)
    | part | Description |
    | :---: | :--- |
    | `mklink` | Creates a directory or file symbolic or hard link |
    | `/j` | Creates a Directory Junction |
    | `source` | Specifies the name/path (relative or absolute) that the link refers to |
    | `destination` | Specifies the name/path (relative or absolute) of the symbolic link being created |

**Linux/macOS:** It's _almost_ the same as for windows but the terminal command is different.
    Type in `ln -s` and add a space.
    Now drag the game's `Managed` folder into the terminal and add a space.
    Add the `External` folder we just made to it as well.
    <br/>
    (breakdown of the command)
    | part | Description |
    | :---: | :--- |
    | `ln` | make links between files |
    | `-s` | make symbolic links instead of hard links |
    | `source` | Specifies the file path of the item being linked |
    | `destination` | Specifies target file path where it will make the link |

With this the folder structure _should_ look like this
```
KitHack Mods
|-External
| |-Mods (symlink)
| |-Managed (symlink)
```

## Making mods

### 1. The example-mod
There is a folder called `example-mod` included here, put it in the `KitHack Mods` folder.
In the example mod there are a few files `exmaple-mod.csproj`  `exmaple-mod.modcfg`  `Loader.cs`  `main.cs`  `modexport.cfg`  `obj`.
`example-mod.csproj` has all settings for the C# project, it is one of them you need to edit when you make a new one. (will come up later)
`example-mod.modcfg` is used by the game to know what plugins to load, from where and in what order and whatr game version is supported, (yes mod**S**... you can chain mod dll files in order)
`modexport.cfg` has all the settings that make it show up in the mods list.
`Loader.cs` has the "loader" that the game uses to run the mod.
`Main.cs` has a example print function in it

This example should print `Hello im an example` when built (and enabled in the game)

By now the folder structure should be
```
KitHack Mods
|-External
| |-Mods (symlink)
| |-Managed (symlink)
|-example-mod
```
if you open the `example-mod` folder in VSCode or Visual Studio it should be picked up automatically.
In VSCode open a terminal (should be under run) and trype `dotnet build` it will build and put it in the mods folder
In Visual Studio there should be a button at the top to build it too.

### 2. A "NEW" mod
Since we export to the linked folders we can just copy, paste and edit this template as needed to make new ones. (YAY)

Start by making a copy and renaming it, open it in VSCode or VS.
In VSCode double click the `.csproj` file on the right.
Find the line that has `<OutputPath>../External/Mods/example-mod</OutputPath>` this line tels it where to put the built file, as you can see its in the Mods folder.
Change the name of the folder it makes by renaming it.

You also need to modify the folder in `.modcfg`.
Look for `asmpath = Mods\example-mod\example-mod.dll` and change both the folder **AND** file name.
To compile the mod with the new file name we need to rename the `.csproj` file name too

Finally edit the `.cfg` file and update the `ModFolderName = example-mod` line and `Title = example-mod`

**YOU NOW MADE YOUR OWN MOD YAY**

## Automating builds
TODO
