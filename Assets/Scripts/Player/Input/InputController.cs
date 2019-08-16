using Boundaries;

namespace Player.Input
{
  using UnityEngine;

  public class InputController : IInputController
  {
    public bool LeftMouseButtonClicked => Input.GetMouseButtonDown(0);
    public bool SpaceKeyPressed => Input.GetKeyDown(KeyCode.Space);
  }
}