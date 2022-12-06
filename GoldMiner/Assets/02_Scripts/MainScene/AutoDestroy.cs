using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float curTime;
    public float coolTime=1f;

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= coolTime)
        {
            Destroy(gameObject);
        }
    }
}
