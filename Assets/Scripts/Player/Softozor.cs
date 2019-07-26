using Boundaries;
using System;
using UnityEngine;

public class Softozor : IPlayer
{
  readonly private Rigidbody2D _rigidbody;
  // TODO: make this parameter configurable from Unity's settings!
  private float _force = 200f;

  public Softozor(Rigidbody2D rigidbody)
  {
    _rigidbody = rigidbody ?? throw new NullReferenceException("Cannot initialize Softozor with null rigidbody object");
  }
  
  public Vector2 Position
  {
    get => _rigidbody.position;
    set
    {
      _rigidbody.position = value;
    }
  }

  public void Flap()
  {
    // TODO: set velocity to zero!
    _rigidbody.AddForce(Vector2.up * _force);
    Debug.Log("Flap");
  }
}
