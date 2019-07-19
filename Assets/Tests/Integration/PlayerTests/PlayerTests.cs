using Boundaries;
using NUnit.Framework;
using PlayerControl;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

namespace PlayerIntegrationTests
{
  public class PlayerTests : ZenjectIntegrationTestFixture
  {
    // The Resources folder is automatically looked up for asset files
    private const string TEST_SETTINGS_PATH = "Tests/Integration/PlayerTestsSettingsInstaller";

    [Inject]
    private IPlayer _player;

    [Inject]
    private PlayerInputHandler _inputHandler;

    [Inject]
    private PlayerMoveHandler _moveHandler;

    [UnityTest]
    public IEnumerator ShouldAssert()
    {
      //CommonPreInstall();
      //CommonPostInstall();

      Assert.IsTrue(false);
      yield return new WaitForEndOfFrame();
      Assert.IsTrue(false);
    }

    /// <summary>
    /// The Player should fly upwards upon flapping
    /// </summary>
    [UnityTest]
    public IEnumerator ShouldMoveUpwardUponFlapping()
    {
      CommonPreInstall();
      CommonPostInstall();

      // Given
      var initialPos = new Vector2();
      _player.Position = initialPos;

      // When
      // Wait one frame to allow update logic for Player to run
      yield return null;
      //_player.Flap();

      // Then
      Assert.Less(initialPos.y, _player.Position.y);
    }

    /*
    /// <summary>
    /// The Player moves inside of a box that has infinite width but finite height. 
    /// He cannot put his head above the box's upper limit.
    /// </summary>
    [Test]
    public void ShouldStopAtMaxHeight()
    {
      Assert.Inconclusive();
    }

    /// <summary>
    /// The Player moves inside of a box that has infinite width but finite height. 
    /// He cannot put his feet below the box's lower limit.
    /// </summary>
    [Test]
    public void ShouldStopAtMinHeight()
    {
      Assert.Inconclusive();
    }*/

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
  }
}