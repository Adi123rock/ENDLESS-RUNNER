using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] segment;
    [SerializeField] int zPos = 60;
    [SerializeField] bool creatingSegment=false;
    [SerializeField] int segmentNum;
    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 3);//0 to 2 is only generated
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos),Quaternion.identity);
        zPos += 60;
        yield return new WaitForSeconds(3);
        creatingSegment = false;
    }
}
