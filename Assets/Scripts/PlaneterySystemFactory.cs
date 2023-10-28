using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneterySystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    


   private  GameObject planeterySystem;

    [SerializeField] private GameObject camera; 




   public  List<IPlaneteryObject> planetaryObjects = new List<IPlaneteryObject>();


    public void Create(double mass)
    {
        
        planeterySystem = new GameObject("PlaneterySystem");
        planeterySystem.AddComponent<PlaneterySystem>().PlanetaryObjects = planetaryObjects; ;

    }

    
    void Start()
    {
        PlaneteryFactory();
        Create(20f);
        camera.AddComponent<CameraFollower>();
    }
    private void PlaneteryFactory()
    {


        CreateSphere("Jovian", MassClassEnum.Jovian);
        CreateSphere("Neptunian", MassClassEnum.Neptunian);
        CreateSphere("SuperTerran", MassClassEnum.Superterran);
        CreateSphere("Terran", MassClassEnum.Terran);
        CreateSphere("Subterran", MassClassEnum.Subterran);
        CreateSphere("Mercurian", MassClassEnum.Mercurian);
        CreateSphere("Asteroidan", MassClassEnum.Asteroidan);

    }
    void CreateSphere(string name, MassClassEnum massClass)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = name; 

        PlaneteryObject planeteryObject = sphere.AddComponent<PlaneteryObject>();
        planeteryObject.MassClass = massClass;
        planetaryObjects.Add(planeteryObject);
    }
}

