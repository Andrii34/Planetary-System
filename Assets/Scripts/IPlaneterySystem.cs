using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPlaneterySystem 
{
     IEnumerable<IPlaneteryObject> PlanetaryObjects { get; set; }

    

}
