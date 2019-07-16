using UnityEngine;

namespace PlayerTests
{
  [CreateAssetMenu(menuName = "Test/PlayerTestsSettings")]
  public class Settings : ScriptableObject
  {
    [SerializeField]
    private string _nameOfMainCamera;

    public string NameOfMainCamera { get => _nameOfMainCamera; }
  }
}