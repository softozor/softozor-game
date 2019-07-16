using UnityEngine;
using Zenject;

namespace PlayerTests
{
  public class Installer : Installer<Installer>
  {
    [Inject]
    private Settings settings;

    public override void InstallBindings()
    {
      Container.Bind<Vector2>().WithId(BindingIds.EnvironmentCenter).FromMethod(() => GetGameCenterPosition(settings));
    }

    private static Vector2 GetGameCenterPosition(Settings settings)
    {
      var front = GameObject.Find(settings.NameOfMainCamera);
      var envCenter = front.transform.position;
      return new Vector2(envCenter.x, envCenter.y);
    }

    //private static Vector2 GetPlayerInitialPosition(Settings settings)
    //{
    //  var front = GameObject.Find(settings.NameOfGameObjectWithColliders);
    //  var envCenter = front.transform.position;
    //  var renderer = front.GetComponent<Renderer>();
    //  var envSize = renderer.bounds.size;
    //  var envWidth = envSize.x;
    //  var envHeight = envSize.y;
    //  var frontEdgeColliders = front.GetComponents<EdgeCollider2D>();
    //  var xMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.x));
    //  var xMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.x));
    //  var yMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.y));
    //  var yMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.y));
    //  return new Vector2((xMin + xMax / 2), (yMin + yMax) / 2);
    //}
  }
}