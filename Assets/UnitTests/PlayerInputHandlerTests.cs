using Boundaries;
using Moq;
using NUnit.Framework;
using PlayerControl;
using Zenject;

[TestFixture]
public class PlayerInputHandlerTests : ZenjectUnitTestFixture
{
  private Mock<IInputController> _inputControllerStub;
  private InputState _inputState;

  [SetUp]
  public void CommonInstall()
  {
    // In this test class, we are stubbing the IInputController;
    // however, we need a different stub configuration in each test,
    // making the use of a common install within the Zenject container 
    // difficult
    _inputState = new InputState();
    _inputControllerStub = new Mock<IInputController>();
  }

  [Test]
  public void StateShouldBeMovingUpUponLeftMousButtonClick()
  {
    // Given
    _inputControllerStub.Setup(controller => controller.LeftMouseButtonClicked)
      .Returns(true);
    var inputHandler = new PlayerInputHandler(_inputState, _inputControllerStub.Object);

    // When
    inputHandler.Tick();

    // Then
    Assert.IsTrue(_inputState.IsMovingUp);
  }

  [Test]
  public void StateShouldBeMovingUpUponSpaceKeyPressed()
  {
    // Given
    _inputControllerStub.Setup(controller => controller.SpaceKeyPressed)
      .Returns(true);
    var inputHandler = new PlayerInputHandler(_inputState, _inputControllerStub.Object);

    // When
    inputHandler.Tick();

    // Then
    Assert.IsTrue(_inputState.IsMovingUp);
  }
}
