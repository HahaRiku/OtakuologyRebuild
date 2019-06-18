using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private float size_pixel_w = 5;
    private float size_pixel_h = 20;
    private float direction = 0;    //0~359
    private float speed = 2;

    private bool start = false;
    private RectTransform objRT;
    private Image img;
    private RectTransform parentRT;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (start) {
            objRT.localPosition = new Vector3(
                objRT.localPosition.x + speed * Mathf.Cos(direction * Mathf.PI / 180),
                objRT.localPosition.y + speed * Mathf.Sin(direction * Mathf.PI / 180),
                objRT.localPosition.z);
            if (Mathf.Abs(objRT.localPosition.x/* + parentRT.localPosition.x*/) >= GlobalVariables.gameWinX / 2 - size_pixel_w / 2 ||
                Mathf.Abs(objRT.localPosition.y/* + parentRT.localPosition.y*/) >= GlobalVariables.gameWinY / 2 - size_pixel_h / 2) {
                //print(gameObject.name);
                //print(parentRT.localPosition.x);
                //print(objRT.localPosition.x + parentRT.localPosition.x);
                //print(GlobalVariables.gameWinX / 2 - size_pixel_w/2);
                //print(objRT.localPosition.x);
                //print("123");
                //Destroy(gameObject);
            }
        }
    }

    public void Initialize(float s_p_w, float s_p_h, float d, float s, Sprite sprite) {
        objRT = gameObject.GetComponent<RectTransform>();
        objRT.sizeDelta = new Vector2(size_pixel_w, size_pixel_h);
        img = gameObject.GetComponent<Image>();
        parentRT = transform.parent.GetComponent<RectTransform>();
        size_pixel_w = s_p_w;
        size_pixel_h = s_p_h;
        if (objRT == null) {
            print("not");
        }
        else {
            objRT.sizeDelta = new Vector2(size_pixel_w, size_pixel_h);
        }
        direction = d;
        speed = s;
        img.sprite = sprite;
    }

    public void Run() {
        start = true;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.name == "Boss") {
            GlobalVariables.bossHP -= GlobalVariables.bulletDamage;
            GlobalVariables.score += 100;
            Destroy(gameObject);
        }
        else if (coll.name == "Danmu_element(Clone)") {
            GlobalVariables.score += 3;
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
