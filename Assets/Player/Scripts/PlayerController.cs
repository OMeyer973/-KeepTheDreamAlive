using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform transporterRed;
    private Transform transporterBlue;
    private bool steeringRed = false;

    public float walkingSpeed = 1;
    public float rotationOffset = 1;
    public float acceleration = .2f;
    public float deceleration = 1f;

    private float eps = .01f; // epsilon on the target speed to determine if we use acceleration or deceleration factor

    private Vector2 currSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        transporterRed = transform.GetChild(0);
        if (transporterRed.name != "TransporterRed") Debug.Log("Player child 0 must be TransporterRed");
        transporterBlue = transform.GetChild(1);
        if (transporterBlue.name != "TransporterBlue") Debug.Log("Player child 1 must be TransporterBlue");
        transporterBlue.GetComponent<Transporter>().BeginSteering();
        currSpeed = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        if (Game.Instance.gameState != GameState.PlayingALevel) return;

        float directionSign = steeringRed ? 1 : - 1;
        Vector3 mirrorDirection = directionSign * (transporterRed.position - transporterBlue.position).normalized;
        Vector3 mirrorNormal = Quaternion.Euler(0, 0, 90) * mirrorDirection;

        Vector3 targetSpeed = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * walkingSpeed;

        // accelerate or decelerate toward input speed
        if (targetSpeed.magnitude <= eps)
            currSpeed = Vector2.Lerp(currSpeed, targetSpeed, deceleration);
        else currSpeed = Vector2.Lerp(currSpeed, targetSpeed, acceleration);

        Vector3 rotationPoint = steeringRed ? transporterBlue.position : transporterRed.position;
        Vector3 steeringPoint = steeringRed ? transporterRed.position : transporterBlue.position;

        Vector3 translationComponent = Vector3.Project(targetSpeed, mirrorDirection);
        Vector3 rotationComponent = Vector3.Project(targetSpeed, mirrorNormal);

        float rotationAngle = Vector3.Dot(rotationComponent, mirrorNormal);
        
        transform.position += translationComponent * Time.fixedDeltaTime;

        transform.RotateAround(rotationPoint, Vector3.forward, rotationAngle * 360f / walkingSpeed * Time.fixedDeltaTime);
    }

    /*
    // old control scheme
        void FixedUpdate()
    {
        if (Game.Instance.gameState != GameState.PlayingALevel) return;

        float directionSign = steeringRed ? 1 : - 1;
        Vector3 mirrorDirection = directionSign * (transporterRed.position - transporterBlue.position).normalized;

        float targetTranslation = -Input.GetAxis("Vertical") * walkingSpeed;
        float targetRotationAngle = Input.GetAxis("Horizontal") * rotationSpeed;

        // accelerate or decelerate toward target translation & rotation speeds
        if (targetTranslation <= eps)
            currWalkingSpeed = Mathf.Lerp(currWalkingSpeed, targetTranslation, deceleration);
        else currWalkingSpeed = Mathf.Lerp(currWalkingSpeed, targetTranslation, acceleration);
        if (targetRotationAngle <= eps)
        currRotationSpeed = Mathf.Lerp(currRotationSpeed, targetRotationAngle, deceleration);
        else currRotationSpeed = Mathf.Lerp(currRotationSpeed, targetRotationAngle, acceleration);

        Vector3 rotationPoint = steeringRed ? transporterBlue.position : transporterRed.position;
        Vector3 steeringPoint = steeringRed ? transporterRed.position : transporterBlue.position;
        transform.position += mirrorDirection * currWalkingSpeed * Time.fixedDeltaTime;

        transform.RotateAround(rotationPoint, Vector3.forward, currRotationSpeed * Time.fixedDeltaTime);
    }
    */

    // Update is called once per frame (after built in physics)
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) ChangeSteering();
    }

    private void ChangeSteering()
    {
        steeringRed = !steeringRed;
        if (steeringRed)
        {
            transporterBlue.GetComponent<Transporter>().EndSteering();
            transporterRed.GetComponent<Transporter>().BeginSteering();
        } else
        {
            transporterBlue.GetComponent<Transporter>().BeginSteering();
            transporterRed.GetComponent<Transporter>().EndSteering();
        }
    }
}
