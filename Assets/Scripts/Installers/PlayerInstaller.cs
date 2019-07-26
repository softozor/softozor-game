using PlayerControl;
using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
  [SerializeField]
  Settings _settings;

  public override void InstallBindings()
  {
    Container.BindInterfacesTo<Softozor>()
      .AsSingle()
      .WithArguments(_settings.Rigidbody);
    Container.BindInterfacesTo<InputController>().AsSingle();
    Container.Bind<InputState>().AsSingle();
    Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
    Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
  }

  [Serializable]
  public class Settings
  {
    public Rigidbody2D Rigidbody;
  }
}