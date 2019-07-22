using Boundaries;
using Moq;
using PlayerControl;
using UnityEngine;
using Zenject;

namespace PlayerIntegrationTests
{
  [CreateAssetMenu(fileName = "Installer", menuName = "Installers/Tests/Integration/PlayerTests")]
  public class Installer : ScriptableObjectInstaller<Installer>
  {
    public Settings _settings;

    public override void InstallBindings()
    {
      var player = Instantiate(_settings.PlayerPrefab);
      Container.BindInterfacesTo<Softozor>()
        .AsSingle()
        .WithArguments(player.GetComponent<Rigidbody2D>());
      Container.BindInstance(GetStubbedInputController()).AsSingle();
      Container.Bind<InputState>().AsSingle();
      // we would not bind Self to the following objects in the game installer;
      // we do that here because we want to get these objects with these class names 
      // in the integration tests
      Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle();
    }

    private static IInputController GetStubbedInputController()
    {
      var inputControllerStub = new Mock<IInputController>();
      inputControllerStub.Setup(controller => controller.LeftMouseButtonClicked)
        .Returns(true);
      return inputControllerStub.Object;
    }
  }
}