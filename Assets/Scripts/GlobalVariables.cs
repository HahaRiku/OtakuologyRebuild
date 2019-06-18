using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables {

    public const float wholeGameX = 800;
    public const float wholeGameY = 600;
    public const float gameWinX = 425;
    public const float gameWinY = 500;
    public const float bossHPBar_totalW = 180;

    public static int playerHP = 5;
    public static float bossHP = 100;
    public static int bulletDamage = 10;
    public static int ultimateTimes = 5;
    public static bool gameOver = false;
    public static bool win = false;
    public static int score = 0;
    public static Vector3 PlayerLocalPosition;

    public static List<GameObject> DanmuElement = new List<GameObject>() ;

    public static void AddDanmuElement(GameObject obj) {
        DanmuElement.Add(obj);
    }

    public static void RushDanmus() {
        DanmuElement.Clear();
    }

    public static void DeleteDanmuElement(GameObject obj) {
        DanmuElement.Remove(obj);
    }
}
