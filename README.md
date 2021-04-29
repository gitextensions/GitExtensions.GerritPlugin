
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

Use the following pattern to link revision data to gerrit:

Search in `Message` with search pattern `(Change-Id: )#?I\w+` and nested pattern `I\w{2,}` to establish the link in your commit info as related link.

## GitExtensions Plugin Template infomration

The [GitExtensions Plugin Template](https://github.com/gitextensions/gitextensions.plugintemplate) gives additional information about the pluign development.
