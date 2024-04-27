using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAppear : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject helper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        spawnPoint.transform.position = transform.position;
        spawnPoint.transform.rotation = Quaternion.identity;

        Instantiate(helper, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
