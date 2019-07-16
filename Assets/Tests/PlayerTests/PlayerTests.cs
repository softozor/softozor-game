using Boundaries;
using Moq;
using NUnit.Framework;
using PlayerControl;
using UnityEngine;
using Zenject;

namespace PlayerTests
{
  [TestFixture]
  public class PlayerTests : ZenjectUnitTestFixture
  {
    private Mock<IInputController> _inputControllerStub;
    private InputState _inputState;
    private Mock<IPlayer> _playerMock;
    private string _testSettingPath = "PlayerTestsSettingsInstaller";

    [SetUp]
    public void Initialize()
    {
      SettingsInstaller.InstallFromResource(_testSettingPath, Container);
      Installer.Install(Container);

      _inputState = new InputState();
      _inputControllerStub = new Mock<IInputController>();
      _playerMock = new Mock<IPlayer>();
    }

    [TearDown]
    public void UnbindAll()
    {
      Container.UnbindAll();
    }

    /// <summary>
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
      var actualPosition = initialPos;
      _playerMock.SetupSet(softozor => softozor.Position = It.IsAny<Vector2>())
        .Callback<Vector2>(position => actualPosition = position);
      _playerMock.SetupGet(softozor => softozor.Position)
        .Returns(initialPos);
      var moveHandler = new PlayerMoveHandler(_inputState, _playerMock.Object);

      // When
      inputHandler.Tick();
      moveHandler.FixedTick();

      // Then
      Assert.IsTrue(actualPosition.y > initialPos.y);
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
    }

    /*
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SoftozorMoverTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    */
  }
}
