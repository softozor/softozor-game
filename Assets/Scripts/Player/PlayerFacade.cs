using Boundaries;
using UnityEngine;
using Zenject;

public class PlayerFacade : MonoBehaviour
{
  private IPlayer _player;

  public Vector2 Position { get => _player.Position; set => _player.Position = value; }

  [Inject]
  public void Construct(IPlayer player)
  {
    _player = player;
  }

  private void Start()
  {
    //Debug.Log("Start");
  }

  private void Update()
  {
    //Debug.Log("Update");
    //Debug.Log($"key down = {Input.GetKeyDown(KeyCode.Space)}");
    //Debug.Log($"left mouse down = {Input.GetMouseButtonDown(0)}");
    //Debug.Log($"y = {Position.y.ToString()}");
  }

  private void FixedUpdate()
  {
    //Debug.Log("FixedUpdate");
    //Debug.Log($"key down = {Input.GetKeyDown(KeyCode.Space)}");
    //Debug.Log($"left mouse down = {Input.GetMouseButtonDown(0)}");
    //Debug.Log($"y = {Position.y.ToString()}");
  }
}
