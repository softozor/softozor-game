using Zenject;
using NUnit.Framework;
using PlayerControl;

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