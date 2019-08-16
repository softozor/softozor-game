using Boundaries;
using Zenject;

namespace Player.Control
{
  public class PlayerMoveHandler : IFixedTickable
  {
    readonly InputState _state;
    readonly IPlayer _player;

    public PlayerMoveHandler(InputState state, IPlayer player)
    {
      _player = player;
      _state = state;
    }

    public void FixedTick()
    {
      if (_state.IsMovingUp)
      {
        _player.Flap();
      }
    }
  }
}