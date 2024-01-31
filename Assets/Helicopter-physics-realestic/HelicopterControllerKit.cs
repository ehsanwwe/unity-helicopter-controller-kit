using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterControllerKit : MonoBehaviour
{
    public float weight = 1500;
    public float enginePower = 2000;
    public Transform topSolidBlade;
    public Transform taleSolidBlade;
    public Material[] bladeSolidMaterials;
    public Material bladeBlureMaterial;
    private float enginRPM;
    private float bladePitch = 0;
    private float pitch = 0;
    private float roll = 0;
    private float yaw = 0;
    private Rigidbody body;
    private GameObject centerOfMass;
    private Vector3 engineForce;
    private Vector3 bodyTorque;
    void Start()
    {
        init();
    }
    void init()
    {
        if (enginePower / weight < 500)
            Debug.Log("for this weight you need More Engine power in HP");
        body = gameObject.AddComponent<Rigidbody>();
        body.drag = 3;
        body.mass = weight;
    }
    void Update()
    {
        checkInputs();
        checkEngine();
        engineAcceleration();
        helicopterAngleSystem();
    }
    void checkInputs()
    {
        if (Input.GetKey(KeyCode.Q))
            bladePitch = Mathf.Lerp(bladePitch, 1, Time.deltaTime * 3f);
        else if (Input.GetKey(KeyCode.E))
            bladePitch = Mathf.Lerp(bladePitch, 0.5f, Time.deltaTime * 5f);
        else
            bladePitch = Mathf.Lerp(bladePitch, 0.8f, Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            if (pitch < 1.57f)
                pitch += Time.deltaTime/3;            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (pitch > -1.57f)
                pitch -= Time.deltaTime / 3;
        }
        else 
            pitch = Mathf.Lerp(pitch, 0, Time.deltaTime);


        if (Input.GetKey(KeyCode.A))
        {
            if (roll < 1.57f)
                roll += Time.deltaTime / 3;
        }            
        else if (Input.GetKey(KeyCode.D))
        {
            if (roll > -1.57f)
                roll -= Time.deltaTime / 3;
        }            
        else
            roll = Mathf.Lerp(roll, 0, Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            yaw = Mathf.Lerp(yaw, 3f, Time.deltaTime /3);
        else if (Input.GetKey(KeyCode.LeftArrow))
            yaw = Mathf.Lerp(yaw, -3f, Time.deltaTime /3);
        else
            yaw = Mathf.Lerp(yaw, 0, Time.deltaTime );
    }
    void checkEngine()
    {
        body.AddRelativeForce(engineForce, ForceMode.Force);
        transform.localEulerAngles = bodyTorque;
        topSolidBlade.Rotate(new Vector3(0, enginRPM, 0), Space.Self);
    }
    void engineStart()
    {

    }
    void engineOff()
    {

    }
    
    void engineAcceleration()
    {
        if (enginePower > enginRPM)
            enginRPM += Time.deltaTime*5;
        engineForce = new Vector3(0, (/*acceleration */Time.deltaTime * enginRPM * (2200) * bladePitch), 0);
    }
    void helicopterAngleSystem()
    {
        bodyTorque = new Vector3(Mathf.Sin(pitch)*30,transform.localEulerAngles.y+ yaw*2, Mathf.Sin(roll)*30);
    }
}
public class HelicopterStatus
{

}
