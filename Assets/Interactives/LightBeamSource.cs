using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LightBeamSource : MonoBehaviour
{

    public int layerMask = 0;
    private LightBeam lightRay;
    private LineRenderer lr;
    // Use this for initialization

    private List<LightBeamReceptor> destinations;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        destinations = new List<LightBeamReceptor>();
    }

    // Update is called once per frame
    void Update()
    {
        lightRay = LightBeam.Cast(transform.position, transform.up, LayerMask.NameToLayer("BounceLightBeams"));

        int nBounces = lightRay.endPoints.Count;

        lr.positionCount = nBounces + 1;
        lr.SetPosition(0, transform.position + new Vector3(0,0,-1f));
        for (int i = 0; i < nBounces; i++)
        {
            lr.SetPosition(i + 1, new Vector3(lightRay.endPoints[i].x, lightRay.endPoints[i].y, -1));
        }

        destinations.Clear();
        foreach (GameObject touchedObject in lightRay.touchedObjects)
        {
            LightBeamReceptor receptor = touchedObject.GetComponent<LightBeamReceptor>();
            if (receptor != null)
            {
                destinations.Add(receptor);
                receptor.BeginReceivingLight(this);
            }
        }
    }
    public bool isMyDestination(LightBeamReceptor receptor)
    {
        return destinations.Contains(receptor);
    }
}