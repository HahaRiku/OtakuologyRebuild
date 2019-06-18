using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    public float bulletSize_w = 5;
    public float bulletSize_h = 20;
    public float bulletSpeed = 1;
    public Sprite bulletSprite;
    public GameObject bulletPrefab;

    private RectTransform playerRT;

	// Use this for initialization
	void Start () {
        playerRT = gameObject.GetComponent<RectTransform>();
        GlobalVariables.PlayerLocalPosition = playerRT.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GlobalVariables.gameOver && !GlobalVariables.win) {
            if (Input.GetKey(KeyCode.RightArrow) && playerRT.localPosition.x < GlobalVariables.gameWinX / 2 - playerRT.sizeDelta.x / 2) {
                playerRT.localPosition = new Vector3(playerRT.localPosition.x + speed, playerRT.localPosition.y, playerRT.localPosition.z);
                GlobalVariables.PlayerLocalPosition = playerRT.localPosition;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && playerRT.localPosition.x > (GlobalVariables.gameWinX / 2 - playerRT.sizeDelta.x / 2) * -1) {
                playerRT.localPosition = new Vector3(playerRT.localPosition.x - speed, playerRT.localPosition.y, playerRT.localPosition.z);
                GlobalVariables.PlayerLocalPosition = playerRT.localPosition;
            }

            if (Input.GetKey(KeyCode.UpArrow) && playerRT.localPosition.y < GlobalVariables.gameWinY / 2 - playerRT.sizeDelta.y / 2) {
                playerRT.localPosition = new Vector3(playerRT.localPosition.x, playerRT.localPosition.y + speed, playerRT.localPosition.z);
                GlobalVariables.PlayerLocalPosition = playerRT.localPosition;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && playerRT.localPosition.y > (GlobalVariables.gameWinY / 2 - playerRT.sizeDelta.y / 2) *-1) {
                playerRT.localPosition = new Vector3(playerRT.localPosition.x, playerRT.localPosition.y - speed, playerRT.localPosition.z);
                GlobalVariables.PlayerLocalPosition = playerRT.localPosition;
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                Bullet bullet = Instantiate(bulletPrefab, new Vector3(playerRT.position.x, playerRT.position.y + playerRT.sizeDelta.x / 2), Quaternion.Euler(0, 0, 0), gameObject.transform.parent).GetComponent<Bullet>();
                //print(playerRT.localPosition.x);
                //print(playerRT.localPosition.y + playerRT.sizeDelta.x);
                bullet.Initialize(bulletSize_w, bulletSize_h, 90, bulletSpeed, bulletSprite);
                bullet.Run();
            }

            if (Input.GetKeyDown(KeyCode.X)) {
                foreach (GameObject danmu in GlobalVariables.DanmuElement) {
                    Destroy(danmu);
                }
                GlobalVariables.RushDanmus();
            }
        }
    }
}
