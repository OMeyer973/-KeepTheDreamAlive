using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamReceptor : DoorActivator
{
    private List<LightBeamSource> sources;

    private bool receivingLight {
        get
        {
            return sources.Count > 0;
        }
        set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        sources = new List<LightBeamSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool removedASourceThisFrame = false;

        for (int i = sources.Count - 1; i >= 0; i--)
        {
            if (!sources[i].isMyDestination(this))
            {
                sources.RemoveAt(i);
                removedASourceThisFrame = true;
            }
        }

        if (!receivingLight && removedASourceThisFrame)
        {
            ReleaseButton();
        }
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
