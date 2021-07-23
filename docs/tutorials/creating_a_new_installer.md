# Creating a new Xenon Installer

## Prerequisites

Before writing our installer, we'll need the .NET 6.0 SDK and - optionally - Git.

It is also recommended you use Microsoft Visual Studio for this task.

Entry-level programming skill with C# and .NET is required.

## Obtaining the template

The [template installer repository](https://github.com/ExaInsanity/xenon-template-installer) contains everything we need. To start, we can either create a new repository from 
the template - which is ideal if we later want to distribute the installer, since the license forces you to open-source anything you distribute. In this case, select a folder on
your computer and run `git clone https://github.com/yourusername/whateveryounamedyourinstaller`. Alternatively, we can just download the code. 

Now, we have a basic C# project. Before we can do anything, we need to rename our files a bit: Template.Installer.csproj needs to become whatever we want to name the installer,
installer.json needs to be renamed as well.

## Configuring the installer

Next up, open the installer.json file. Its many fields are covered by [the reference](../reference/installers/installer_json.md) - for now, we will only look at the first few:

~~~json
"installerId": "installer",
"installerName": "Template Installer",
"description": "Template Installer for the Xenon Launcher"
~~~

Change these three however you see fit and make sure to remember the ID you gave your installer - it will be important later on.

## Implementing the interface

Now, we need to open the Installer.cs file. For now, we will, again, only look at the first three lines:

~~~cs
public String Id => throw new NotImplementedException();

public Xenon.TypeLib.Version Version => throw new NotImplementedException();

public InstallerEnvironment Environment => throw new NotImplementedException();
~~~

Change it to... whatever you want. It is important that the Id here and the Id specified in the installer.json file match. This could, for example, look like this:

~~~cs
public String Id => "mojangclient";

public Xenon.TypeLib.Version Version => new() { Major = 0, Minor = 0, Hotfix = 1};

public InstallerEnvironment Environment => InstallerEnvironment.Client;
~~~

Now, we need to deal with the methods. For a simple installer, `ListTags` can just return `Array.Empty<String>();` - but both ListVersions overloads must return at least one item.

Disable and Initialize can just return immediately.

The other, and more complex, file we need to deal with is `InstallHandler.cs`. It only requires one method and specifies two, but those are where the work happens.

`Install` must be implemented. Here is where we download the game files - the actual installation process.

`PatchVersionMeta` only needs to be implemented if it is a client installer. It is designed to handle changes to the version.json file or the assets/game libraries - though if it
doesn't need to do any of these, we can just `return;`.

## Building

Now, build your installer. In `bin/Debug/net6.0/installers`, you will find the two files required to distribute. Congratulations!

The internal magic is handled by the template - the .csproj file contains some trickery to only generate those two files and put them in the right folder already.

## Further reading:

- [Installer JSON reference](../reference/installers/installer_json.md)
- [IInstaller reference](../reference/installers/iinstaller.md)
- [IInstallHandler reference](../reference/installers/iinstallhandler.md)
