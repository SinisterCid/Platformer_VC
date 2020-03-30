using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class StickStuff : MonoBehaviour
{

    //grab 3d fx
    public GameObject hit;

    int hitSkuas = 0;

    private void OnCollisionEnter(Collision col)
    {
        
        //if stick hits skua, instantiate fx
        if (col.gameObject.tag == "Skua")
        {

            Instantiate(hit, col.gameObject.transform.position, Quaternion.identity);

            // Analytics for skua hits
            hitSkuas++;
            ReportSkuaHit(hitSkuas);
        }
    }

    public void ReportSkuaHit(int hits)
    {
        Analytics.CustomEvent("skuaHit", new Dictionary<string, object>
        {
            {"numHits", hits}
        });
    }
}
