using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField] private stackPartController[] _stackPartControllers = null;

    public void shatterAllParts()
    {
        if (transform.parent!=null)
        {
            transform.parent = null;
        }

        foreach (stackPartController o in _stackPartControllers)
        {
            o.shatter();
        }

        StartCoroutine(RemoveParts());
    }

    IEnumerator RemoveParts()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
