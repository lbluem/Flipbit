using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public float rotationSpeed;
    private Transform _tr;


    // Start is called before the first frame update
    void Start() {
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        
        // Rotate the object if player one presses left, right, or middle button
        // Rotiert das Objekt, wenn Spieler eins die linke, rechte oder mittlere Taste drückt
        if (KutiInput.GetKutiButton(EKutiButton.P1_LEFT)) {
            _tr.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (KutiInput.GetKutiButton(EKutiButton.P1_RIGHT)) {
            _tr.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (KutiInput.GetKutiButton(EKutiButton.P1_MID)) {
            _tr.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
        }

        // Rotate the object if player two presses left, right, or middle button
        // Rotiert das Objekt, wenn Spieler zwei die linke, rechte oder mittlere Taste drückt
        if (KutiInput.GetKutiButton(EKutiButton.P2_LEFT)) {
            _tr.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (KutiInput.GetKutiButton(EKutiButton.P2_RIGHT)) {
            _tr.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (KutiInput.GetKutiButton(EKutiButton.P2_MID)) {
            _tr.Rotate(-rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
}
