using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************
 * 
 * 進行一次華麗的彈幕(???
 * 
 * *****************************/


public class DanmuDesign : MonoBehaviour {

    public enum Type {
        圓形散開,
        螺旋,
        散彈,
        狙擊
    }

    public Type type = Type.圓形散開;
    public Sprite 彈幕的圖;
    public GameObject Danmu_element;
    public float elementSize= 50;
    public float elementSpeed = 1;
    public int 彈幕顆數 = 10;

    private bool start;
    private RectTransform DanmuDesignRT;

    // Use this for initialization
    void Start () {
        DanmuDesignRT = gameObject.GetComponent<RectTransform>();
	}

    // Update is called once per frame
    void Update() {
        if (start && !GlobalVariables.gameOver && !GlobalVariables.win) {
            start = false;
            if (type == Type.圓形散開) {
                for (int i = 0; i < 彈幕顆數; i++) {
                    EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    obj.Initialize(elementSize, 360 / 彈幕顆數 * i, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);
                    obj.Run();
                }
            }
            else if (type == Type.螺旋) {
                for (int i = 0; i < 10; i++) {
                    /*EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    obj.Initialize(elementSize, 360 / 彈幕顆數 * i, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);*/
                    StartCoroutine(WaitAndBornAndRun(i * 0.2f, type, i));
                }
            }
            else if (type == Type.散彈) {
                for (int i = 0; i < 10; i++) {
                    EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    obj.Initialize(elementSize, 90 / (彈幕顆數 - 1) * i + 225, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);
                    obj.Run();
                }
            }
            else if (type == Type.狙擊) {
                for (int i = 0; i < 10; i++) {
                    //EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    /*float tempAngle = (Mathf.Asin((GlobalVariables.PlayerLocalPosition.y - DanmuDesignRT.localPosition.y) /
                        Mathf.Sqrt(Mathf.Pow(GlobalVariables.PlayerLocalPosition.x - DanmuDesignRT.localPosition.x, 2) +
                        Mathf.Pow(GlobalVariables.PlayerLocalPosition.y - DanmuDesignRT.localPosition.y, 2)))) * 180 / Mathf.PI;*/
                    /*if (GlobalVariables.PlayerLocalPosition.x - DanmuDesignRT.localPosition.x < 0) {
                        if (tempAngle < 0) {
                            tempAngle = 180 - tempAngle;
                        }
                        else {
                            tempAngle = 180 + tempAngle;
                        }
                    }
                    obj.Initialize(elementSize, tempAngle, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);*/
                    StartCoroutine(WaitAndBornAndRun(i * 0.1f, type, i));
                }
            }
        }
    }

    public void StartDanmu() {
        start = true;
    }

    private IEnumerator WaitAndBornAndRun(float seconds, Type t, int index) {
        yield return new WaitForSeconds(seconds);

        if (t == Type.狙擊) {
            EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
            float tempAngle = (Mathf.Asin((GlobalVariables.PlayerLocalPosition.y - DanmuDesignRT.localPosition.y) /
                            Mathf.Sqrt(Mathf.Pow(GlobalVariables.PlayerLocalPosition.x - DanmuDesignRT.localPosition.x, 2) +
                            Mathf.Pow(GlobalVariables.PlayerLocalPosition.y - DanmuDesignRT.localPosition.y, 2)))) * 180 / Mathf.PI;
            if (GlobalVariables.PlayerLocalPosition.x - DanmuDesignRT.localPosition.x < 0) {
                if (tempAngle < 0) {
                    tempAngle = 180 - tempAngle;
                }
                else {
                    tempAngle = 180 + tempAngle;
                }
            }
            obj.Initialize(elementSize, tempAngle, elementSpeed, 彈幕的圖);
            GlobalVariables.AddDanmuElement(obj.gameObject);
            obj.Run();
        }
        else if (t == Type.螺旋) {
            EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
            obj.Initialize(elementSize, 360 / 彈幕顆數 * index, elementSpeed, 彈幕的圖);
            GlobalVariables.AddDanmuElement(obj.gameObject);
            obj.Run();
        }
        //print("123");
    }
}
