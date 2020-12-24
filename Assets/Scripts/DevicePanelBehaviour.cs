using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevicePanelBehaviour : MonoBehaviour
{

    public GameObject text;
    public TextMesh textMesh;
    public GameObject AirPlaneForText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMesh = (TextMesh)text.transform.GetComponent(typeof(TextMesh));
        if (Input.GetKey("k"))
        {
            textMesh.text = "Для того, чтобы что-то сделать, Вам необходимо что-то сделать и тогда Вы что-то сделаете";
        }
        if (Input.GetKey("l"))
        {
            textMesh.text = "Здесь какой-то другой текст может быть";
        }
        if (Input.GetKey("o"))
        {
            textMesh.text = "Тут написано другая надпись";
        }
        float positionX = round(AirPlaneForText.transform.position.x, 1);
        float positionY = round(AirPlaneForText.transform.position.y, 1);
        float positionZ = round(AirPlaneForText.transform.position.z, 1);
        float rotationX = round(AirPlaneForText.transform.rotation.x, 3);
        float rotationY = round(AirPlaneForText.transform.rotation.y, 3);
        float rotationZ = round(AirPlaneForText.transform.rotation.z, 3);
        string readyToPrint = " ";
        readyToPrint += "Position: latitude = ";
        readyToPrint += positionX.ToString();
        readyToPrint += ", longitude = ";
        readyToPrint += positionZ.ToString();
        readyToPrint += "; Height: ";
        readyToPrint += positionY.ToString();
        readyToPrint += ";\n Pitch: ";
        readyToPrint += rotationX.ToString();
        readyToPrint += " Scour: ";
        readyToPrint += rotationY.ToString();
        readyToPrint += " Bank: ";
        readyToPrint += rotationZ.ToString();
        readyToPrint += ";\n Speed: ";
        readyToPrint += PlayerController.speed.ToString();
        readyToPrint += ";\n System OK";
        textMesh.text = readyToPrint;
    }
    private static float round(float number, int scale)
    {
        int pow = 10;
        for (int i = 1; i < scale; i++)
            pow *= 10;
        float tmp = number * pow;
        return (float)(int)((tmp - (int)tmp) >= 0.5f ? tmp + 1 : tmp) / pow;
    }
}
