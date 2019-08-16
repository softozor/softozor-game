using NUnit.Framework;
using Player;
using System;
using Zenject;

[TestFixture]
public class SoftozorTests : ZenjectUnitTestFixture
{
  [Test]
  public void ShouldThrowIfConstructedWithNullRigidbody()
  {
    Assert.Throws<NullReferenceException>(() => new Softozor(null));
  }
}