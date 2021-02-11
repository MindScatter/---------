﻿using System.Collections;
using UnityEngine;

//https://youtu.be/xzFsq7W4sJc
//Stealth game tutorial - 304 - Double Door Animation - Unity Official Tutorials

public class LiftDoorsTracking : MonoBehaviour
{
    public float doorSpeed;

    private Transform leftOuterDoor;
    private Transform rightOuterDoor;
    private Transform leftInnerDoor;
    private Transform rightInnerDoor;
    private float leftClosedPosX;
    private float rightClosedPosX;

    void Awake()
    {
        leftOuterDoor = GameObject.Find("door_exitOuter_left_001").transform;
        rightOuterDoor = GameObject.Find("door_exitOuter_right_001").transform;
        leftInnerDoor = GameObject.Find("door_exitInner_left_001").transform;
        rightInnerDoor = GameObject.Find("door_exitInner_right_001").transform;

        leftClosedPosX = leftInnerDoor.position.x;
        rightClosedPosX = rightInnerDoor.position.x;
    }

    void MoverDoors(float newLeftXTarget, float newRightXTarget)
    {
        float newX = Mathf.Lerp(leftInnerDoor.position.x, newLeftXTarget, doorSpeed * Time.deltaTime);
        leftInnerDoor.position = new Vector3(newX, leftInnerDoor.position.y, leftInnerDoor.position.z);

        newX = Mathf.Lerp(rightInnerDoor.position.x, newRightXTarget, doorSpeed * Time.deltaTime);
        rightInnerDoor.position = new Vector3(newX, rightInnerDoor.position.y, rightInnerDoor.position.z);
    }

    public void DoorFollowing()
    {
        MoverDoors(leftOuterDoor.position.x, rightOuterDoor.position.x);
    }

    public void CloseDoors()
    {
        MoverDoors(leftClosedPosX, rightClosedPosX);
    }
}
