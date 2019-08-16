using NUnit.Framework;
using Player;
using Player.Input;
using System.Collections;
using UnityEngine.TestTools;
using WindowsInput;
using WindowsInput.Native;
using Zenject;

public class InputControllerTests : ZenjectIntegrationTestFixture
{
  InputSimulator _inputSimulator;

  [SetUp]
  public void Setup()
  {
    _inputSimulator = new InputSimulator();
  }

  [UnityTest]
  public IEnumerator ShouldHaveSpaceKeyPressedWhenSpaceKeyDown()
  {
    PreInstall();
    PostInstall();

    // Given
    var controller = new InputController();

    // When
    _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.SPACE);
    yield return null;

    // Then
    Assert.IsTrue(controller.SpaceKeyPressed);
  }

  [UnityTest]
  public IEnumerator ShouldHaveLeftMouseButtonClickedWhenLeftMouseButtonDown()
  {
    PreInstall();

    Container.Bind<PlayerFacade>().FromNewComponentOnNewGameObject().AsSingle();

    PostInstall();

    // Given
    var controller = new InputController();

    // When
    _inputSimulator.Mouse.XButtonDown(0);
    yield return null;

    // Then
    Assert.IsTrue(controller.LeftMouseButtonClicked);
  }
}