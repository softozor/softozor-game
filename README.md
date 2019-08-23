# The Softozor game

The intent of this git repository is to learn to use [Unity 3D](www.unity3d.com). This is done by developing [Softozor](www.softozor.ch)'s banner game which is basically a 2D "flappy dinosaur" game. The ansatz is to develop the game following test-driven development (TDD) philosophy.

## Development setup

To support us in our challenge of developing a game following TDD, we use the [Zenject DI framework](https://github.com/modesttree/Zenject) coupled with [Moq](https://github.com/Moq/moq4/wiki/Quickstart) framework.

### Zenject setup

Follow [this useful advice](http://adamsingle.com/unit-testing-in-unity-with-zenject-unirx-and-moq/) except for the part where they get rid of the assembly files. In addition, make sure that your .NET profile has API compatibility level `.NET 4.x`. On Unity3D version 2019.2.2f1, you will need to add `Moq.dll` and `Zenject-usage.dll` to your integration and scene tests' "Assembly References":

![Assembly References](/doc/img/AssemblyReferences.png)

In the unit test projects, you will only need to add the `Moq.dll` reference there.

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

Even in the latter possibility, the `SceneContext` is necessary. Without it, nothing happens. We prefer that latter solution because everything related to the player is grouped at the same place, in the softozor instance. Get an idea how [subcontainers](https://github.com/modesttree/Zenject/blob/master/Documentation/SubContainers.md#using-game-object-contexts) are working [here](https://stackoverflow.com/questions/57286720/zenject-mono-installer-not-called-in-scene-tests-under-some-circumstances/57327521#57327521). Consequence is that the types registered in the game object subcontainer are not directly injectable into the Scene Test.

In the Scene Tests, we might need acccess to the Player's position. This is achieved by creating a `PlayerFacade` script, adding it as a component to the `softozor` game object and binding it to the `SceneContext` with the `Zenject Binding Script` (`Assets/Plugins/Zenject/Source/Install/ZenjectBinding.cs`):

![Zenject binding](/doc/img/ZenjectBinding.png)
