using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMadeController : MonoBehaviour
{

    Touch touched = new Touch();
    [SerializeField] private RectTransform canvas;
    Vector3 touchWorldPos;
    Vector3 startPos;
    int padRange = 70;
    Vector3 padPos;
    Vector3 adjustVec;
    [SerializeField] private GameObject player;
    int speed = 3;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            touched = Input.GetTouch(0);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas, touched.position, null, out touchWorldPos);

            if (Vector3.Distance(startPos, touchWorldPos) <= padRange)
            {
                padPos = touchWorldPos;
            }
            else
            {
                adjustVec = (touchWorldPos - startPos).normalized * padRange;
                padPos = startPos + adjustVec;
            }

            transform.position = padPos;
            player.transform.Translate((padPos.x - startPos.x) / padRange * speed * Time.deltaTime, 0, (padPos.y - startPos.y) / padRange * speed * Time.deltaTime);
        }
        else
        {
            transform.position = startPos;
        }
    }
}