using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAsteroid : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Deleted");
        Destroy(gameObject);
    }
}
