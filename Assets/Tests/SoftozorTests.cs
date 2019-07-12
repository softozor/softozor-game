using Moq;
using NUnit.Framework;
using System.Linq;
using UnityEngine;

namespace Tests
{
  public class SoftozorTests
  {
    /// <summary>
    /// The Player can make Softozor fly upwards upon left mouse button clicked
    /// </summary>
    [Test]
    public void ShouldMoveUpwardUponLeftMouseButtonClick()
    {
      // Given
      var inputState = new InputState();      
      var inputControllerStub = new Mock<IInputController>();
      inputControllerStub.Setup(controller => controller.LeftMouseButtonClicked())
        .Returns(true);
      var inputHandler = new PlayerInputHandler(inputState, inputControllerStub.Object);

      var front = GameObject.Find("front");
      var frontEdgeColliders = front.GetComponents<EdgeCollider2D>();
      var xMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.x));
      var xMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.x));
      var yMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.y));
      var yMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.y));
      var softozorMock = new Mock<ISoftozor>();
      var initialPos = new Vector2((xMin + xMax / 2), (yMin + yMax) / 2);
      var actualPosition = initialPos;
      softozorMock.SetupSet(softozor => softozor.Position = It.IsAny<Vector2>())
        .Callback<Vector2>(position => actualPosition = position);
      softozorMock.SetupGet(softozor => softozor.Position)
        .Returns(initialPos);

      var moveHandler = new PlayerMoveHandler(inputState, softozorMock.Object);

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
