using Boundaries;
using Zenject;

namespace PlayerControl
{
  public class PlayerInputHandler : ITickable
  {
    readonly InputState _state;
    readonly IInputController _controller;

    public PlayerInputHandler(InputState state, IInputController controller)
    {
      _controller = controller;
      _state = state;
    }

    public void Tick()
    {
      _state.IsMovingUp = _controller.LeftMouseButtonClicked || _controller.SpaceKeyPressed;
    }
  }
}