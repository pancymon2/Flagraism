﻿using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {

    public Rigidbody2D m_Lowwer;
    public Rigidbody2D m_Upper;
    public HingeJoint2D m_LowwerJoint;
    public HingeJoint2D m_UpperJoint;

    private Vector3 lowwerPosition;
    private Vector3 upperPosition;

    private float lowwer_Mass = 0.5f;
    private float upper_Mass = 0.5f;


    // Use this for initialization
    void Start () {
        lowwerPosition = m_Lowwer.transform.position;
        lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
        upperPosition = m_Upper.transform.position;
        upperPosition.y += m_Upper.GetComponent<SpriteRenderer>().bounds.max.y;

        float y = m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y- m_Lowwer.GetComponent<SpriteRenderer>().bounds.min.y;
        m_LowwerJoint.anchor = new Vector2(0, -0.5f * y);

        y = m_Upper.GetComponent<SpriteRenderer>().bounds.max.y - m_Upper.GetComponent<SpriteRenderer>().bounds.min.y;
        m_UpperJoint.anchor = new Vector2(0, -0.5f * y);
        m_UpperJoint.connectedAnchor = new Vector2(0, 0.5f * y);

        lowwer_Mass = m_Lowwer.mass;
        upper_Mass = m_Upper.mass;

        m_Lowwer.AddForceAtPosition(new Vector2(-0.1f * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
    }



	// Update is called once per frame
	void Update () {
        //GetKey();

    }

    void FixedUpdate()
    {
        GetKey();
    }

    void GetKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(-1 * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
            //Debug.Log("space");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(1 * lowwer_Mass, 0), lowwerPosition, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //m_Upper.AddForceAtPosition(new Vector2(-1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //Debug.Log(m_Upper.gameObject.transform.rotation.eulerAngles);
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            Debug.Log(z);
            z += 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate--;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            Debug.Log(z);
            z -= 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //m_Upper.AddForceAtPosition(new Vector2(1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate++;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
    }

    float getKeyMultiplier = 0.1f;

    void GetKey()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(-1 * lowwer_Mass * getKeyMultiplier, 0), lowwerPosition, ForceMode2D.Impulse);
            //Debug.Log("space");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            lowwerPosition = m_Lowwer.transform.position;
            lowwerPosition.y += m_Lowwer.GetComponent<SpriteRenderer>().bounds.max.y;
            m_Lowwer.AddForceAtPosition(new Vector2(1 * lowwer_Mass * getKeyMultiplier, 0), lowwerPosition, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //m_Upper.AddForceAtPosition(new Vector2(-1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //Debug.Log(m_Upper.gameObject.transform.rotation.eulerAngles);
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            //Debug.Log(z);
            z += 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass * getKeyMultiplier;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate--;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float z = m_Upper.gameObject.transform.rotation.eulerAngles.z % 360;
            //Debug.Log(z);
            z -= 90;
            float angle = z / 180 * Mathf.PI;
            float x = -1 * Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            Vector2 force = new Vector2(x, y);
            force = force.normalized * upper_Mass * getKeyMultiplier;
            m_Upper.AddForceAtPosition(force, upperPosition, ForceMode2D.Impulse);
            //m_Upper.AddForceAtPosition(new Vector2(1 * upper_Multiplier, 0), upperPosition, ForceMode2D.Impulse);
            //JointMotor2D motor = new JointMotor2D();
            //rotate++;
            //motor.motorSpeed = rotate * motor_Speed;
            //motor.maxMotorTorque = float.MaxValue;
            //m_Joint.motor = motor;
        }
    }
}