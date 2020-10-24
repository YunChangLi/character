using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    public GameObject Ball;
    public Transform StartPoint, EndPoint;

    private void Start()
    {
        var startPos = StartPoint.position;
        GameObject ball = Instantiate(Ball, startPos, Quaternion.identity);

        var endPos = EndPoint.position;

        RotateTo(ball, endPos);
    }

    private void RotateTo(GameObject obj, Vector3 destination)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
