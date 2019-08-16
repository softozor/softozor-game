using Boundaries;
using Moq;
using NUnit.Framework;
using Player.Control;
using Zenject;

[TestFixture]
public class PlayerMoveHandlerTests : ZenjectUnitTestFixture
{
  private InputState _inputState;
  private Mock<IPlayer> _playerMock;
  private PlayerMoveHandler _handler;

  [SetUp]
  public void CommonInstall()
  {
    // here we don't use the Zenject container because of the player mock;
    // would the IPlayer instance be a stub then it wouldn't be a problem;
    // but as a matter of fact we need to verify that a particular method 
    // is called on the IPlayer interface making the use of the _playerMock.Object 
    // not the only use of the mock
    _inputState = new InputState();
    _playerMock = new Mock<IPlayer>();
    _handler = new PlayerMoveHandler(_inputState, _playerMock.Object);
  }
  
  [Test]
  public void PlayerShouldFlapIfMovingUp()
  {
    // Given
    _inputState.IsMovingUp = true;

    // When
    _handler.FixedTick();

    // Then
    _playerMock.Verify(player => player.Flap(), Times.Once);
  }
}
