using UnityEngine;

[CreateAssetMenu(menuName = "TestSettigs")]
public class TestSettings : ScriptableObject
{
  [SerializeField]
  private string _nameOfGameObjectWithColliders;

  public string NameOfGameObjectWithColliders { get => _nameOfGameObjectWithColliders; }
}
