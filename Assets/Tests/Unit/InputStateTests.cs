using NUnit.Framework;
using Player.Control;
using Zenject;

[TestFixture]
public class InputStateTests : ZenjectUnitTestFixture
{
  [Test]
  public void ShouldBeInitializedAsNotMovingUp()
  {
    var inputState = new InputState();
    Assert.IsFalse(inputState.IsMovingUp);
  }
}