using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBeha : MonoBehaviour
{
    // Start is called before the first frame update
    public Player pla;
    float MousX;
    float MousZ;
    float drag=2;
    Vector3 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = pla.getHit().point;
        Vector3 camPos = (pla.transform.position + mousePos) / 2f;

        camPos.x = Mathf.Clamp(camPos.x, -drag + pla.transform.position.x, drag + pla.transform.position.x);
        camPos.y = 12+pla.transform.position.y;
        camPos.z = Mathf.Clamp(camPos.z, -drag + pla.transform.position.z, drag + pla.transform.position.z);
        this.transform.position = camPos;
    }

    public Vector3 getFace()
    {
        return mousePos - pla.transform.position;
    }    
}
