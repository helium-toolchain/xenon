# The IInstaller interface

`Xenon.InstallerLoader.IInstaller` is one of the two interfaces every installer is required to implement.

## Properties

`public String Id { get; }`: The string ID of the installer. It must match the ID specified in the installer.json file.

`public Xenon.TypeLib.Version Version { get; }`: The semantic version of the installer. It must match the version specified in the installer.json file.

`public InstallerEnvironment Environment { get; }`: The installer environment - Client or Server.

## Methods

`public void Initialize()`: Designed to load required data, such as an external list of versions. This is called asynchronously and in no particular order. 
Proceed with mild caution.

`public void Disable()`: Designed to unload all data, close connections etc. This is called asynchronously and in no particular order.

`public String[] ListTags()`: Lists all allowed tags, such as `snapshot`, `legacy` etc. This is not required to return anything.

`public String[] ListVersions()`: Lists all versions supported by this installer, such as `1.15.1` or `1.15.1-pre1`.

`public String[] ListVersions(params String[] tags)`: Lists all versions supported by this installer that match the specified tags. Output can be the same as the 
parameterless overload.
