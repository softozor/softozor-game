using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using Boundaries;

namespace PlayerIntegrationTests
{
  public class PlayerTests : ZenjectIntegrationTestFixture
  {
    // The Resources folder is automatically looked up for asset files
    private const string TEST_SETTINGS_PATH = "Tests/Integration/PlayerTestsSettingsInstaller";

    [Inject]
    private IPlayer _player;

    [UnityTest]
    public IEnumerator ShouldMoveUpwardUponLeftMouseButtonClick()
    {
      CommonPreInstall();
      CommonPostInstall();

      var position = _player.Position;

      // Add test assertions for expected state
      // Using Container.Resolve or [Inject] fields
      yield break;
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
      FillCommonContainer();
      PostInstall();
    }

    /// <summary>
    /// Call Container.Bind methods
    /// </summary>
    private void FillCommonContainer()
    {
      Installer.InstallFromResource(TEST_SETTINGS_PATH, Container);
    }

    /*/// <summary>
    /// The Player can make Softozor fly upwards upon left mouse button clicked
    /// </summary>
    [Test]
    public void ShouldMoveUpwardUponLeftMouseButtonClick()
    {
      // Given
      _inputControllerStub.Setup(controller => controller.LeftMouseButtonClicked)
        .Returns(true);
      var inputHandler = new PlayerInputHandler(_inputState, _inputControllerStub.Object);
      var initialPos = Container.ResolveId<Vector2>(BindingIds.EnvironmentCenter);
      //var actualPosition = initialPos;
      //_playerMock.SetupSet(softozor => softozor.Position = It.IsAny<Vector2>())
      //  .Callback<Vector2>(position => actualPosition = position);
      //_playerMock.SetupGet(softozor => softozor.Position)
      //  .Returns(initialPos);
      _player = new Softozor()
      {
        Position = initialPos
      };
      var moveHandler = new PlayerMoveHandler(_inputState, _player);

      // When
      // TODO: you don't want to call those tick methods, you rather want to skip a frame
      inputHandler.Tick();
      moveHandler.FixedTick();
      _player.Flap();

      // Then
      Assert.IsTrue(_player.Position.y > initialPos.y);
    }

    /// <summary>
    /// The Player can make Softozor fly upwards upon space key pressed
    /// </summary>
    [Test]
    public void ShouldMoveUpwardUponSpaceKeyPressed()
    {
      Assert.Inconclusive();
    }

    /// <summary>
    /// Softozor moves inside of a box that has infinite width but finite height. 
    /// He cannot put his head above the box's upper limit.
    /// </summary>
    [Test]
    public void ShouldStopAtMaxHeight()
    {
      Assert.Inconclusive();
    }

    /// <summary>
    /// Softozor moves inside of a box that has infinite width but finite height. 
    /// He cannot put his feet below the box's lower limit.
    /// </summary>
    [Test]
    public void ShouldStopAtMinHeight()
    {
      Assert.Inconclusive();
    }*/
  }
}