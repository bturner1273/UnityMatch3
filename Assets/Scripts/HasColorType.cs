using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{
    NONE, BLUE, GREEN, ORANGE, PURPLE, RED, WHITE, YELLOW
}

public class HasColorType : MonoBehaviour
{
    [SerializeField] private ColorType colorType;

    public void SetColorType(ColorType ColorType)
    {
        colorType = ColorType;
    }

    public ColorType getColorType()
    {
        return colorType;
    }
}
