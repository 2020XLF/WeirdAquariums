using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStaticUtil
{
    public Transform leftDownPos;
    public Transform rightUpPos;
    private static GameStaticUtil _instance = null;
    public static GameStaticUtil Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new GameStaticUtil();
            }
            return _instance;
        }
    }
    public void setSwimScope(Transform LDPos,Transform RUPos)
    {
        this.leftDownPos = LDPos;
        this.rightUpPos = RUPos;
    }
    public Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
}
