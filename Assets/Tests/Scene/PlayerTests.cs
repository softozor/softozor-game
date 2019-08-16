using NUnit.Framework;
using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using WindowsInput;
using WindowsInput.Native;
using Zenject;

public class PlayerTests : SceneTestFixture
{
  [Inject]
  private PlayerFacade _facade;

  private InputSimulator _inputSimulator;

  [SetUp]
  public void Setup()
  {
    _inputSimulator = new InputSimulator();
  }

  /// <summary>
  /// The Player moves inside of a box that has infinite width but finite height. 
  /// He cannot flap above the box's upper limit.
  /// </summary>
  [UnityTest]
  public IEnumerator ShouldStopAtMaxHeight()
  {
    yield return LoadScene("Main");

    float yMax = BoxUpperLimit();
    _facade.Position = new Vector2(_facade.Position.x, yMax);

    // wait one frame for user input
    yield return null;

    yield return Flap();

    Assert.Less(_facade.Position.y, yMax);
  }

  private static float BoxUpperLimit()
  {
    var front = GameObject.Find("front");
    var renderer = front.GetComponent<Renderer>();
    var bounds = renderer.bounds;
    var size = bounds.size;
    var transform = front.transform;
    var pos = transform.position;
    var yMax = pos.y + size.y / 2;
    return yMax;
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

  private IEnumerator Flap()
  {
    _inputSimulator.Keyboard.KeyPress(VirtualKeyCode.SPACE);
    // wait for Flapping
    yield return null;
    yield return null;
  }
}