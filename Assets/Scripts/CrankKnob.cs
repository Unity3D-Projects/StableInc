using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrankKnob : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Transform baseCrank;
    public Transform numberWheel;
    private bool isHeldDown;

    private float targetAngle;

    public float prevAngle;
    public float changeInAngle;

    public float wheelSpeed;

    public AudioClip crankSound;
    public float lastPlayedAngle;

    // Start is called before the first frame update
    void Start()
    {
        prevAngle = baseCrank.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (isHeldDown)
        {
            Vector3 offset = baseCrank.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetAngle = Mathf.Rad2Deg * -Mathf.Atan2(offset.y, -offset.x);
            baseCrank.eulerAngles = new Vector3(0, 0, targetAngle);
            changeInAngle = baseCrank.eulerAngles.z - prevAngle;
            if(Mathf.Abs(changeInAngle) >= 300)
            {
                changeInAngle = 0;
            }
            prevAngle = baseCrank.eulerAngles.z;
        }
        else
        {
            changeInAngle = 0;
        }

        if(Mathf.Abs(targetAngle - lastPlayedAngle) > 15)
        {
            AudioManager.player.PlayOneAtATime(crankSound);
            lastPlayedAngle = targetAngle;
        }

        numberWheel.eulerAngles = new Vector3(0, 0, numberWheel.eulerAngles.z - changeInAngle / wheelSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeldDown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isHeldDown = false;
    }
}
