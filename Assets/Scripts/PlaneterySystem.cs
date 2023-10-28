

using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneterySystem : MonoBehaviour, IPlaneterySystem
{
    const double G = 100f;
    [SerializeField] private float deltaTime = 1f;
    
     public IEnumerable<IPlaneteryObject> PlanetaryObjects { get; set; }


    private void Start()
    {
       
        StratPozPlaneteryObjects();
       SetInitialVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
        Time.timeScale = deltaTime;
    }
    private void Gravity()
    {
        foreach (IPlaneteryObject planetaryObject in PlanetaryObjects)
        {

            foreach (IPlaneteryObject anotherPlanetaryObject in PlanetaryObjects)
            {
                if (!planetaryObject.Equals(anotherPlanetaryObject))
                {
                    double m1 = planetaryObject.Mass/60; 
                    double m2 = anotherPlanetaryObject.Mass/60;
                    double r = Vector3.Distance(planetaryObject.Position, anotherPlanetaryObject.Position);
                    Vector3 direction = anotherPlanetaryObject.Position - planetaryObject.Position;
                    Vector3 force = direction.normalized * System.Convert.ToSingle(G * (m1 * m2) / (r * r));
                    
                    planetaryObject.RigidbodyComponent.AddForce(force);


                }
            }
        }
    }
    private void SetInitialVelocity()
    {
        foreach (IPlaneteryObject planetaryObject in PlanetaryObjects)
        {
            foreach (IPlaneteryObject anotherPlanetaryObject in PlanetaryObjects)
            {
                if (!planetaryObject.Equals(anotherPlanetaryObject))
                {
                    double m2 = anotherPlanetaryObject.Mass;
                    double r = Vector3.Distance(planetaryObject.Position, anotherPlanetaryObject.Position);

                    planetaryObject.Transform.LookAt(anotherPlanetaryObject.Transform);




                    Vector3 direction = (anotherPlanetaryObject.Position - planetaryObject.Position).normalized;
                    if(planetaryObject.MassClass!=MassClassEnum.Jovian)
                    {

                    planetaryObject.RigidbodyComponent.velocity = planetaryObject.Transform.right * Mathf.Sqrt(System.Convert.ToSingle((G * m2) / r));
                    }

                }
            }
        }
    }
    private void StratPozPlaneteryObjects()
    {

        Transform centerObject = PlanetaryObjects.FirstOrDefault()?.Transform;

        if (centerObject == null)
        {
            Debug.LogWarning("Не удалось найти центральный объект.");
            return;
        }

        float radius = 49f; 
        float angleIncrement = 360f / (PlanetaryObjects.Count() - 1); 

        int i = 0;
        foreach (IPlaneteryObject planetaryObject in PlanetaryObjects)
        {
            if (i == 0)
            {
                
                i++;
                continue;
            }

            
            float angle = i * angleIncrement;

            
            float angleInRadians = Mathf.Deg2Rad * angle;

            
            float posX = centerObject.position.x + radius * Mathf.Cos(angleInRadians);
            float posZ = centerObject.position.z + radius * Mathf.Sin(angleInRadians);

            
            planetaryObject.Transform.position = new Vector3(posX, 0, posZ);

            i++;
        }
    }

}




