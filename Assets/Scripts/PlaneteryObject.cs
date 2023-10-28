using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlaneteryObject : MonoBehaviour,IPlaneteryObject
{
    private MassClassEnum massClass;
    private double mass;
    
    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private MeshRenderer meshRenderer;
    

    Material asteroidanMaterial;
    Material mercurianMaterial;
    Material subterranMaterial;
    Material terranMaterial;
    Material superterranMaterial;
    Material neptunianMaterial;
    Material jovianMaterial;


    public MassClassEnum MassClass { get =>  massClass; set => massClass = value; }
    public double Mass { get => (double)rb.mass; }
    public Vector3 Position { get => transform.position; set => transform.position = value; }
    public Rigidbody RigidbodyComponent { get => rb; set => rb= value; }
    public Transform Transform { get => transform;  }
    

    private void Awake()
    {
        
        
        
        meshRenderer =   gameObject.GetComponent<MeshRenderer>();
        asteroidanMaterial = Resources.Load<Material>("Materials/Asteroidan");
        mercurianMaterial = Resources.Load<Material>("Materials/Mercurian");
        subterranMaterial = Resources.Load<Material>("Materials/Subterran");
        terranMaterial = Resources.Load<Material>("Materials/Terran");
        superterranMaterial = Resources.Load<Material>("Materials/Superterran");
        neptunianMaterial = Resources.Load<Material>("Materials/Neptunian");
        jovianMaterial = Resources.Load<Material>("Materials/Jovian");
        
        rb = gameObject.AddComponent<Rigidbody>();
        sphereCollider = gameObject.AddComponent<SphereCollider>();
        

    }
    void Start()
    {
        
        rb.useGravity=false;
        SetMaterial();
        SetMass();
        SetRadius();
        float radius = sphereCollider.radius;
        transform.localScale = new Vector3(radius , radius , radius );
        sphereCollider.radius = 0.5f;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetMass()
    {
        if(massClass == MassClassEnum.Asteroidan)
        {
            rb.mass = 0.00001f;

        }
        else if(massClass == MassClassEnum.Mercurian)
        {
            rb.mass = Random.Range(0.00001f, 0.1f);
        }
        else if (massClass == MassClassEnum.Subterran)
        {
            rb.mass = Random.Range(0.1f, 0.5f);
        }
        else if (massClass == MassClassEnum.Terran)
        {
            rb.mass = Random.Range(0.5f, 2f);
        }
        else if (massClass == MassClassEnum.Superterran)
        {
            rb.mass = Random.Range(2f, 10f);
        }

        else if (massClass == MassClassEnum.Neptunian)
        {
            rb.mass = Random.Range(10f,50f);
        }
        else if (massClass == MassClassEnum.Jovian)
        {
            rb.mass = Random.Range(50f, 5000f);
        }
    }
    private void  SetRadius()
    {
        if (massClass == MassClassEnum.Asteroidan)
        {
            sphereCollider.radius = Random.Range(0.01f, 0.03f);
        }
        else if(massClass == MassClassEnum.Mercurian)
        {
            sphereCollider.radius = Random.Range(0.03f, 0.7f) ;
        }
        else if (massClass == MassClassEnum.Subterran)
        {
            sphereCollider.radius = Random.Range(0.5f, 1.2f);
        }
        else if (massClass == MassClassEnum.Terran)
        {
            sphereCollider.radius = Random.Range(0.8f, 1.9f);
        }
        if (massClass == MassClassEnum.Superterran)
        {
            sphereCollider.radius = Random.Range(1.3f, 3.3f);
        }
        else if (massClass == MassClassEnum.Neptunian)
        {
            sphereCollider.radius = Random.Range(2.1f,5.7f) ;
        }
        else if (massClass == MassClassEnum.Jovian)
        {
            sphereCollider.radius = Random.Range(3.5f,27f);
        }
    }
    private void SetMaterial()
    {
        if (massClass == MassClassEnum.Asteroidan)
        {
            meshRenderer.material = asteroidanMaterial;
        }
        else if (massClass == MassClassEnum.Mercurian)
        {
            meshRenderer.material = mercurianMaterial;
        }
        else if (massClass == MassClassEnum.Subterran)
        {
            meshRenderer.material = subterranMaterial;
        }
        else if (massClass == MassClassEnum.Terran)
        {
            meshRenderer.material = terranMaterial;
        }
        if (massClass == MassClassEnum.Superterran)
        {
            meshRenderer.material = superterranMaterial;
        }
        else if (massClass == MassClassEnum.Neptunian)
        {
            meshRenderer.material = neptunianMaterial;
        }
        else if (massClass == MassClassEnum.Jovian)
        {
            meshRenderer.material = jovianMaterial;
        }
    }
}


