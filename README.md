# GitExtensions.GerritPlugin

GitExtensions.GerritPlugin is a plugin for GitExtensions to work with a [Gerrit](https://www.gerritcodereview.com/) as Git server.

## Features

* Gerrit hook installation
* Patchset publish
* Patchset download

## Usage

The cloned repository requires a `.gitreview` file, which is in use for the plugin to identify the gerrit server.
This file must be located in root foilder of the repository.
Get more information about this file [here](https://docs.openstack.org/infra/git-review/installation.html#gitreview-file-format)

### Revision link

Using [Git Extensions revision links](https://git-extensions-documentation.readthedocs.io/settings.html#git-extensions-revision-links) you can configure how to convert parts of a revision data into clickable links.

Use the following pattern to link revision data to Gerrit:
* Search in: `Message`.
* Search pattern: `(Change-Id: )#?I\w+`.
* Nested pattern: `I\w{2,}`.

## Compatibility Version Matrix

| Git Extensions      | Gerrit Plugin       |
|---------------------|---------------------|
| v <= 3.5.x          | v <= 1.3.2          |
| 3.5.x < v <= 4.0.0  | 2.0.0 <= v <= 2.0.1 |
| 4.0.1 <= v <= 4.0.2 | 2.0.5               |
| 4.1 <= v            | master-branch       |

## GitExtensions Plugin Template information

The [GitExtensions Plugin Template](https://github.com/gitextensions/gitextensions.plugintemplate) gives additional information about the pluign development.
