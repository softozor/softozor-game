using UnityEngine;

namespace PlayerIntegrationTests
{
  [CreateAssetMenu(menuName = "Test/PlayerTestsSettings")]
  public class Settings : ScriptableObject
  {
    [SerializeField]
    private GameObject _playerPrefab;

    public GameObject PlayerPrefab { get => _playerPrefab; }
  }
}