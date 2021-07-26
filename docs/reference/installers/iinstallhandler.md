# The IInstallHandler interface

`Xenon.InstallerLoader.IInstallHandler` one of the two interfaces every installer must implement.

## Methods

`public void Install(String version)`: Called asynchronously. Proceed with mild caution. Downloads and installs all necessary files.

`public void PatchVersionMeta(String version)`: Called synchronously, in strict order. Changes the version.json file to this installations' needs.
