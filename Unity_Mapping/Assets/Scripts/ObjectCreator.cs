using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject objectPrefab;
    void Start()
    {
        InvokeRepeating("Create", 1, 0.01f);
    }

    void Create()
    {
        Instantiate(objectPrefab, new Vector3(Random.Range(-20,20),0, Random.Range(-20, 20)), Quaternion.identity);
    }

    void Delete() { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
