using Boundaries;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Installer", menuName = "Installers/Tests/Integration/PlayerTests")]
public class Installer : ScriptableObjectInstaller<Installer>
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
