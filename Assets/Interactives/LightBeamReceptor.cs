using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamReceptor : DoorActivator
{
    private List<LightBeamSource> sources;

    private bool receivingLight = false;
    // Start is called before the first frame update
    void Start()
    {
        sources = new List<LightBeamSource>();
        receivingLight = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BeginReceivingLight(LightBeamSource source)
    {
        if (!sources.Contains(source))
        {
            sources.Add(source);
            PressButton();
        }

        receivingLight = true;
    }
}
