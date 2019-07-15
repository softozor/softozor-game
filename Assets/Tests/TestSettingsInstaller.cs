using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TestSettingsInstaller", menuName = "Installers/TestSettingsInstaller")]
public class TestSettingsInstaller : ScriptableObjectInstaller<TestSettingsInstaller>
{
  public TestSettings _settings;

  public override void InstallBindings()
  {
    Container.BindInterfacesAndSelfTo<TestSettings>().FromInstance(_settings).AsSingle();
  }
}