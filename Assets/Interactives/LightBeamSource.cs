using UnityEngine;
using System.Collections;

public class LightBeamSource : MonoBehaviour
{

    public int layerMask = 0;
    private LightBeam lightRay;
    private LineRenderer lr;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lightRay = LightBeam.Cast(transform.position, transform.up, LayerMask.NameToLayer("BounceLightBeams"));

        int nBounces = lightRay.endPoints.Count;

        lr.positionCount = nBounces + 1;
        lr.SetPosition(0, transform.position);
        for (int i = 0; i < nBounces; i++)
        {
            lr.SetPosition(i + 1, lightRay.endPoints[i]);
        }
    }
}