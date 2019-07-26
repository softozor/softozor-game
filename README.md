# The Softozor game

The intent of this git repository is to learn to use [Unity 3D](www.unity3d.com). This is done by developing [Softozor](www.softozor.ch)'s banner game which is basically a 2D "flappy dinosaur" game. The ansatz is to develop the game following test-driven development (TDD) philosophy.

## Development setup

To support us in our challenge of developing a game following TDD, we use the [Zenject DI framework](https://github.com/modesttree/Zenject) coupled with [Moq](https://github.com/Moq/moq4/wiki/Quickstart) framework.

### Zenject setup

Follow [this useful advice](http://adamsingle.com/unit-testing-in-unity-with-zenject-unirx-and-moq/) except for the part where they get rid of the assembly files. 

## Software design

Following Zenject philosophy, our scripted objects are organized like this:

![UML diagram](/doc/img/UML.png)

## Scene configuration

To install the necessary logic behind the Player, i.e. the `PlayerControl`, `PlayerInput`, and `Softozor` components, add an empty game object as a child to the softozor prefab instance in the Hierarchy view. Drag and drop the `PlayerInstaller.cs` script in that empty game object. 

In order for the `PlayerInstaller` Mono Installer to have its `InstallBindings()` method called upon game start, you need to add a `SceneContext` to the scene: in the Hierarchy view:

  * right-click on the hierarchy view
  * select Zenject -> Scene Context

Then, either

  * add the `PlayerInstaller` to the list of Mono Installers of the `SceneContext`

![PlayerInstaller in SceneContext](/doc/img/PlayerInstallerInSceneContext.png)

or 

  * drag'n'drop the `Assets/Plugins/Zenject/Source/Install/Contexts/GameObjectContext.cs` script in to the softozor prefab instance
  * drag'n'drop the Installer game object in to the Mono Installers list of softozor's Game Object Context

![PlayerInstaller in GameObjectContext](/doc/img/PlayerInstallerInGameObjectContext.png)

Even in the latter possibility, the `SceneContext` is necessary. Without it, nothing happens. We prefer that latter solution because everything related to the player is grouped at the same place, in the softozor instance. However, it does not work for our Scene Tests, as mentioned [here](https://github.com/modesttree/Zenject/issues/647). Therefore, we're better off with the first possibility. 
