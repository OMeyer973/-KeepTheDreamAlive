using System.Collections.Generic;
using UnityEngine;

// Represents a set of bounced rays.
public class LightBeam
{
    // BounceRay result state

    // endPoints for drawing line renderer (including emitter & away 
    public List<Vector2> endPoints;
    // contact points at reflexions
    public List<GameObject> touchedObjects;
    public bool bounced;
    public Vector2 finalDirection;

    // offset the casted ray to prevent self hit
    private static float bounceOffset = 0.01f;


    // Returns all contact points from a bouncing ray at the specified position and moving in the specified direction.
    public static LightBeam Cast(Vector2 position, Vector2 direction, int bounceLayer, int nbReflexions = 100, float magnitude = 1000)
    {
        // Initialize the return data.
        LightBeam lightRay = new LightBeam
        {
            touchedObjects = new List<GameObject>(),
            endPoints = new List<Vector2>(),
            finalDirection = direction.normalized
        };

        lightRay.endPoints.Add(position);

        Vector2 currPosition = position;
        Vector2 currDirection = direction;
        float magnitudeRemaining = magnitude;

        for (int i = 0; i<nbReflexions; i++)
        {
            currDirection.Normalize();

            // Fire out initial vector.
            RaycastHit2D hit = Physics2D.Raycast(currPosition, currDirection, magnitudeRemaining);

            // Calculate our bounce conditions.
            bool hitSucceeded = hit.collider != null && hit.distance > 0;
            bool canReachNextBounce = hit.distance < magnitudeRemaining;

            // we didn't hit anything
            if (!hitSucceeded || !canReachNextBounce)
            {
                currPosition = currPosition + currDirection * magnitudeRemaining;
                lightRay.endPoints.Add(currPosition);
                break;
            }

            // we hit something.

            // Add the contact point & hit object th their lists.
            lightRay.endPoints.Add(hit.point);

            GameObject hitObject = hit.collider.gameObject;
            if (!lightRay.touchedObjects.Contains(hitObject))
            { 
                lightRay.touchedObjects.Add(hitObject);
            }

            // we hit a non reflexive object, no more bounce allowed
            if (hitObject.layer != bounceLayer)
            {
                break;
            }

            // Reflect the hit.
            currDirection = Vector2.Reflect(currDirection.normalized, hit.normal);
            // offset the next emission point to prevent self hit
            currPosition = hit.point + bounceOffset * hit.normal;
        }

        for(int i = 1; i < lightRay.endPoints.Count; i++)
        {
            Debug.DrawLine(lightRay.endPoints[i-1], lightRay.endPoints[i], Color.green);
        }

        // Return the current position & direction as final.
        return lightRay;
    }
}