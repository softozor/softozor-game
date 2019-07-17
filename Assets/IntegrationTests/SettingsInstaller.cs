using Boundaries;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TestSettingsInstaller", menuName = "Installers/Test/PlayerTestsSettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
  public Settings _settings;

  public override void InstallBindings()
  {
    Container.Bind<IPlayer>()
      .To<Softozor>()
      .AsSingle()
      .WithArguments(_settings.Rigidbody);
  }
}
