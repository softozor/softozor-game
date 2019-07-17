using UnityEngine;

[CreateAssetMenu(menuName = "Test/PlayerTestsSettings")]
public class Settings : ScriptableObject
{
  [SerializeField]
  private GameObject _playerPrefab;
  
  public Rigidbody2D Rigidbody { get => _playerPrefab.GetComponent<Rigidbody2D>(); }
}