namespace PlayerInput
{
  public interface IInputController
  {
    bool LeftMouseButtonClicked { get; }
    bool SpaceKeyPressed { get; }
  }
}