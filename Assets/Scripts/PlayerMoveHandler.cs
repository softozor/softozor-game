using Zenject;

public class PlayerMoveHandler : IFixedTickable
{
  readonly InputState _state;
  readonly ISoftozor _player;

  public PlayerMoveHandler(InputState state, ISoftozor player)
  {
    _player = player;
    _state = state;
  }

  public void FixedTick()
  {
    throw new System.NotImplementedException();
  }
}
