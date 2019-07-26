using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Boundaries;

public class PlayerTests : SceneTestFixture
{
  [Inject]
  private IPlayer _player;

  [UnityTest]
  public IEnumerator TestScene()
  {
    yield return LoadScene("Main");

    // TODO: we will need to Flap until a certain position has been reached
    var i = 0;
    while (i < 100)
    {
      //var position = _player.Position;
      _player.Flap();
      ++i;
      yield return new WaitForSeconds(0.01f);
    }

    // TODO: Add assertions here now that the scene has started
    //yield return new WaitForSeconds(1.0f);

    // Note that you can use SceneContainer.Resolve to look up objects that you need for assertions
    Assert.Inconclusive();
  }

  /// <summary>
  /// The Player moves inside of a box that has infinite width but finite height. 
  /// He cannot put his head above the box's upper limit.
  /// </summary>
  [UnityTest]
  public void ShouldStopAtMaxHeight()
  {
    Assert.Inconclusive();
  }

  /// <summary>
  /// The Player moves inside of a box that has infinite width but finite height. 
  /// He cannot put his feet below the box's lower limit.
  /// </summary>
  [UnityTest]
  public void ShouldStopAtMinHeight()
  {
    Assert.Inconclusive();
  }
}