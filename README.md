# The Softozor game

The intent of this git repository is to learn to use [Unity 3D](www.unity3d.com). This is done by developing [Softozor](www.softozor.ch)'s banner game which is basically a 2D "flappy dinosaur" game. The ansatz is to develop the game following test-driven development (TDD) philosophy.

## Development setup

To support us in our challenge of developing a game following TDD, we use the [Zenject DI framework](https://github.com/modesttree/Zenject) coupled with [Moq](https://github.com/Moq/moq4/wiki/Quickstart) framework.

### Zenject setup

Follow [this useful advice](http://adamsingle.com/unit-testing-in-unity-with-zenject-unirx-and-moq/) except for the part where they get rid of the assembly files. 

## Software design

Following Zenject philosophy, our scripted objects are organized like this:

![UML diagram](/doc/img/UML.png)