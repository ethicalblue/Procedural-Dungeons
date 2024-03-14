using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float Speed = 5.00f;
    public GameObject target;

    float x, y, z;
    
    // Start is called before the first frame update
    void Start()
    {
        x = UnityEngine.Random.Range(-1f, 1f);
        y = UnityEngine.Random.Range(-1f, 1f);
        z = UnityEngine.Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(x, y, z), Speed * Time.deltaTime);
    }
}
