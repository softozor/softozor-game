using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
      //var inputController = new Mock<IInputController>();
      //inputController.Setup(controller => controller.LeftMouseButtonClicked())
      //  .Returns(true);
      //var softozor = new Mock<ISoftozor>();
      //// TODO: set softozor's initial position!
      //var mover = new SoftozorMover(inputController.Object, softozor.Object);
      //var initialSoftozorPosition = softozor.Position;
      //mover.Flap();
      //Assert.IsTrue(softozor.Position.y > initialSoftozorPosition.y);
      Assert.Inconclusive();
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
