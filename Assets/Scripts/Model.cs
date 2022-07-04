using System;
using UnityEngine;

public class Model : MonoBehaviour {

    public float GetResult(float digitOne, float digitTwo, ButtonFunc.func bFunc) {
        float result = 0;
        try {
            switch(bFunc) {
                case ButtonFunc.func.plus:
                    result = digitOne + digitTwo;
                    break;
                case ButtonFunc.func.minus:
                    result = digitOne - digitTwo;
                    break;
                case ButtonFunc.func.multiply:
                    result = digitOne * digitTwo;
                    break;
                case ButtonFunc.func.divide:
                    if(digitTwo != 0) {
                        result = digitOne / digitTwo;
                    } else {
                        result = 0;
                    }
                    break;
            }
        } catch(Exception) { }
        return result;
    }

}
