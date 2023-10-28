
using UnityEngine;


public interface IPlaneteryObject
{
    
    MassClassEnum MassClass { get; set; }



    double Mass { get; }
    Vector3 Position { get; set; }
    Rigidbody RigidbodyComponent { get; set; }
    Transform Transform { get; }

    
}