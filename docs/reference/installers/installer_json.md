# The Installer.json file

`installerId`: Unique, string ID of the installer. There may not be two installers of the same ID loaded at the same time.

`installerName`: Displayed name of the installer. Used in Xenon's various user interfaces.

`description`: Displayed installer description. Used in Xenon's various user interfaces.

`version`: Semantic, three-digit version number. Version numbers are required to be listed as Major.Minor.Hotfix.

`sources`: Required link to the installer's source code.

`issues`: Required link to the installer's issue page.

`homepage`: Optional link to the project home page.

`depends`: String array of IDs this installer depends on. For example, `fabricclient` will depend on `mojangclient` and should therefore add `mojangclient` as dependency.

`breaks`: String array of IDs this installer is incompatible with. For example, `sodiummod` would be incompatible with `optifinemod` and should specify this.

`recommends`: String array of IDs this installer recommends to be used as well. For example, `sodiummod` could recommend `lithiummod` and `phosphormod` and should specify so.

`authors`: Optional string array crediting the installer authors.

## Remarks

- `installerId` and `version` must match their IInstaller counterparts.
- `sources` and `issues` should always be specified, even though they are not technically required.
