using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float changeAmount = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color =Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        this.transform.localEulerAngles = new Vector3(Random.Range(0, 90), 0, Random.Range(0, 90));
        Invoke("Delete", 5);
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - changeAmount, this.transform.position.z);
        this.transform.Rotate(this.transform.up, 2);
        print(this.transform.position);
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
