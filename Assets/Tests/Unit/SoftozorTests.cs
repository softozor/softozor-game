using Zenject;
using NUnit.Framework;
using System;

[TestFixture]
public class SoftozorTests : ZenjectUnitTestFixture
{
  [Test]
  public void ShouldThrowIfConstructedWithNullRigidbody()
  {
    Assert.Throws<NullReferenceException>(() => new Softozor(null));
  }
}