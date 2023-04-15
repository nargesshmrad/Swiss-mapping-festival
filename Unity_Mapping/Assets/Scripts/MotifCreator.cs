using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public struct MotifSurface
{
    public GameObject surface;
    public List<GameObject> motifs;
}
[System.Serializable]
public struct MotifCube
{
    public MotifSurface right;
    public MotifSurface left;
    public MotifSurface front;
    public MotifSurface back;
    public MotifSurface top;
    public MotifSurface bottom;

}

public class MotifCreator : MonoBehaviour
{
    public GameObject myPrefab;
    public int numRows = 100;
    public int numCols = 100;
    [SerializeField]
    private MotifCube cube;

    private void Awake()
    {
    }

    void Start()
    {
        cube = new MotifCube();
        makeSurface(ref cube.front, transform.forward, transform.forward, transform.up);
        makeSurface(ref cube.back, -transform.forward,transform.forward, transform.up);
        makeSurface(ref cube.right, transform.right, transform.right, transform.up);
        makeSurface(ref cube.left, -transform.right, transform.right, transform.up);
        makeSurface(ref cube.top, transform.up, transform.up, transform.right);
        makeSurface(ref cube.bottom, -transform.up, transform.up, transform.right);

    }

    void Update()
    {


    }

    private void FixedUpdate()
    {

        
    }

    void makeSurface(ref MotifSurface motifSurface, Vector3 direction, Vector3 forward, Vector3 up)
    {
        GameObject surface = new GameObject("surface");
        motifSurface = new MotifSurface();
        motifSurface.motifs = new List<GameObject>();
        motifSurface.surface = surface;
        print(motifSurface.surface);
        surface.transform.parent=transform;
        float size = myPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x * 2;
        float surfaceSize = size * numRows;
        //print(surfaceSize);
        for (int row = -numRows/2 +1 ; row <= numRows/2; row++)
        {
            //print(string.Format("row {0}",row));
            for (int col = -numCols/2+1; col <= numCols/2; col++)
            {
                GameObject motif = Instantiate(myPrefab);
                motifSurface.motifs.Add(motif);
                motif.transform.GetChild(0).GetComponent<Rigidbody>().Sleep();
                motif.transform.localPosition = new Vector3(row * size - size / 2, col * size - size / 2, 0);
                motif.transform.parent = surface.transform;
                //print(string.Format("col {0}", col));
            }
        }
        
        surface.transform.localPosition = direction * surfaceSize/2;
        //forward = forward + surface.transform.right * surfaceSize / 2 + surface.transform.up * surfaceSize / 2;
        surface.transform.localRotation = Quaternion.LookRotation(forward,up);
        //print(surface.transform.position);   
        
    }
}
