using System.Linq;
using UnityEngine;
using Zenject;

public class TestInstaller : Installer<TestInstaller>
{
  [Inject]
  private TestSettings settings;

  public override void InstallBindings()
  {
    Container.Bind<Vector2>().WithId("PlayerInitialPosition").FromMethod(() => GetPlayerInitialPosition(settings));
  }

  private static Vector2 GetPlayerInitialPosition(TestSettings settings)
  {
    var front = GameObject.Find(settings.NameOfGameObjectWithColliders);
    var frontEdgeColliders = front.GetComponents<EdgeCollider2D>();
    var xMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.x));
    var xMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.x));
    var yMin = frontEdgeColliders.Min(collider => collider.points.Min(point => point.y));
    var yMax = frontEdgeColliders.Max(collider => collider.points.Max(point => point.y));
    return new Vector2((xMin + xMax / 2), (yMin + yMax) / 2);
  }
}