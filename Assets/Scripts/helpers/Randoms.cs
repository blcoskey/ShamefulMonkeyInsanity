
using UnityEngine;

public static class Randoms{
    public static Sprite GetRandomSprite(Sprite[] spriteArray){
        return spriteArray[Random.Range(0, spriteArray.Length)];
    }
}