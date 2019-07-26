using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using WindowsInput;
using WindowsInput.Native;
using NUnit.Framework;

public class InputControllerTests : ZenjectIntegrationTestFixture
{
  [Inject]
  PlayerFacade _facade;

  [UnityTest]
  public IEnumerator ShouldHaveSpaceKeyPressedWhenSpaceKeyDown()
  {
    PreInstall();
    PostInstall();

    // Given
    var controller = new InputController();

    // When
    var inputSimulator = new InputSimulator();
    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.SPACE);
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
    var inputSimulator = new InputSimulator();
    inputSimulator.Mouse.XButtonDown(0);
    yield return null;

    // Then
    Assert.IsTrue(controller.LeftMouseButtonClicked);
  }
}