using Boundaries;
using Moq;
using NUnit.Framework;
using PlayerControl;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class PlayerTests : ZenjectIntegrationTestFixture
{
  private const string PLAYER_PREFAB_NAME = "Softozor";

  [Inject]
  private IPlayer _player;

  [Inject]
  private PlayerInputHandler _inputHandler;

  [Inject]
  private PlayerMoveHandler _moveHandler;

  /// <summary>
  /// The Player should fly upwards upon flapping
  /// </summary>
  [UnityTest]
  public IEnumerator ShouldMoveUpwardUponFlapping()
  {
    CommonPreInstall();

    var inputControllerStub = new Mock<IInputController>();
    inputControllerStub.Setup(controller => controller.LeftMouseButtonClicked)
      .Returns(true);
    Container.BindInstance(inputControllerStub.Object).AsSingle();
    Container.Bind<InputState>().AsSingle();
    Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();
    Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle();

    CommonPostInstall();

    // Given
    // wait one frame for user input https://forum.unity.com/threads/why-is-fixedupdate-called-before-update.458503/
    yield return null;
    // we take the player's initial position after the first frame, because, upon game starting, 
    // the player falls down a bit until user input has been got
    var initialPos = _player.Position;

    // When
    // wait one frame to allow update logic for Player to run
    yield return null;

    // Then
    Assert.Greater(_player.Position.y, initialPos.y);
  }

  private void CommonPreInstall()
  {
    SetupCommonInitialState();
    PreInstall();
  }

  /// <summary>
  /// Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc
  /// </summary>
  private void SetupCommonInitialState()
  {
  }

  private void CommonPostInstall()
  {
    CommonFillContainer();
    PostInstall();
  }

  /// <summary>
  /// Fill Container with common bindings
  /// </summary>
  private void CommonFillContainer()
  {
    var prefab = Resources.Load(PLAYER_PREFAB_NAME, typeof(GameObject)) as GameObject;
    var player = Object.Instantiate(prefab);
    Container.BindInterfacesTo<Softozor>()
      .AsSingle()
      .WithArguments(player.GetComponent<Rigidbody2D>());
  }
}
