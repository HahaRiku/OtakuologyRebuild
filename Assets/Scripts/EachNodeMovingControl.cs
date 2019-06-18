using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachNodeMovingControl : MonoBehaviour {

    private float size_pixel = 50;  //square
    private float direction = 0;    //0~359
    private float speed = 1;

    private bool start = false;
    private RectTransform objRT;
    private Image img;
    private RectTransform parentRT;

    void Start() {

        

    }

	// Update is called once per frame
	void Update () {
        if (start) {
            objRT.localPosition = new Vector3(
                objRT.localPosition.x + speed * Mathf.Cos(direction * Mathf.PI / 180),
                objRT.localPosition.y + speed * Mathf.Sin(direction * Mathf.PI / 180),
                objRT.localPosition.z);
            if (Mathf.Abs(objRT.localPosition.x + parentRT.localPosition.x) >= GlobalVariables.gameWinX / 2 - size_pixel/2 ||
                Mathf.Abs(objRT.localPosition.y + parentRT.localPosition.y) >= GlobalVariables.gameWinY / 2 - size_pixel/2) {
                //print(gameObject.name);
                //print(GlobalVariables.gameWinX / 2 - size_pixel);
                //print(objRT.localPosition.x);
                GlobalVariables.DeleteDanmuElement(gameObject);
                Destroy(gameObject);
            }
        }
	}

    public void Initialize(float s_p, float d, float s, Sprite sprite) {
        objRT = gameObject.GetComponent<RectTransform>();
        objRT.sizeDelta = new Vector2(size_pixel, size_pixel);
        img = gameObject.GetComponent<Image>();
        parentRT = gameObject.transform.parent.gameObject.GetComponent<RectTransform>();
        size_pixel = s_p;
        if (objRT == null) {
            print("not");
        }
        else {
            objRT.sizeDelta = new Vector2(size_pixel, size_pixel);
        }
        direction = d;
        speed = s;
        img.sprite = sprite;
    }

    public void Run() {
        start = true;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.name == "Player") {
            GlobalVariables.playerHP -= 1;
            GlobalVariables.DeleteDanmuElement(gameObject);
            Destroy(gameObject);
        }
    }
}

