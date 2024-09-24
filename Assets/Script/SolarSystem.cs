using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
   public Transform SunTrans;
   public Transform Sat1Trans;
   public Transform Sat2Trans;
   public Transform cameraM;

    void Start()
    {
        SunTrans.position = new Vector3(10, 10, 10);
        Sat1Trans.position = new Vector3(SunTrans.position.x + 5, SunTrans.position.y + 5, SunTrans.position.z + 5);
        Sat2Trans.position = new Vector3(Sat1Trans.position.x + 2, Sat1Trans.position.y + 2, Sat1Trans.position.z + 2);

    }


    void Update()
    {
        //Sol
        SunTrans.RotateAround(new Vector3(0, 0, 0), Vector3.forward, 30f * Time.deltaTime);
        SunTrans.LookAt(new Vector3(0, 0, 0));

        //Sat1
        Sat1Trans.RotateAround(SunTrans.position, Vector3.up, 90f * Time.deltaTime);

        //Sat2
        Sat2Trans.RotateAround(Sat1Trans.position, Vector3.right, 45f * Time.deltaTime);
        Sat2Trans.LookAt(Sat1Trans.position);

        //Camera
        cameraM.LookAt(SunTrans.position);

        //DrawLines
        Debug.DrawLine(SunTrans.position, new Vector3(0, 0, 0), Color.blue);
        Debug.DrawLine(SunTrans.position, Sat1Trans.position, Color.red);
        Debug.DrawLine(SunTrans.position, Sat2Trans.position, Color.yellow);
        Debug.DrawLine(Sat1Trans.position, Sat2Trans.position, Color.green);

        //Para intentar hacer que sat2 cambie su tamaño mientras gira debemos mantener la posicion, y cambiar la escala. 
        //Haz que Sat2 cambie de tamaño a la vez que gira. Si el ángulo entre su eje X y el eje X global es menor que 90 (usando Vector3.Angle), reducirá su tamaño. Si no, aumentará su tamaño.
        Vector3 posSatelite = new Vector3(Sat2Trans.position.x, Sat2Trans.position.y, Sat2Trans.position.z);
        Vector3 satelite2X = new Vector3(90, Sat2Trans.position.y, Sat2Trans.position.z);

        if (posSatelite.x < satelite2X.x)
        {
            Vector3.Angle(posSatelite, satelite2X);
        }
    }
}
