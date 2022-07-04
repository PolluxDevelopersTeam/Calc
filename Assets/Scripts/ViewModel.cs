using System;
using UnityEngine;

public class ViewModel : MonoBehaviour {

    bool funcUsed;
    string digitOne, digitTwo;
    public static string result;
    ButtonFunc.func cFunc;
    Model model;
    public Observer observer;
    bool saveMode = true;

    void Awake() {
        if(observer == null) observer = new Observer();
    }

    void Start() {
        model = FindObjectOfType<Model>();
        if(saveMode) {
            if(PlayerPrefs.HasKey("result")) {
                result = PlayerPrefs.GetString("result");
                if(!result.Equals("0")) digitOne = result;
            }
        }
        observer.Invoke(result);
    }

    // как альтернативу данную функцию можно сделать через switch, будет более универсально, но объемнее код
    // если планировать добавлять калькулятору функционал, то лучше делать через switch
    public void SetData(ButtonFunc bFunc) {
        if(!funcUsed) {
            if((int)bFunc.myFunc < 10) {
                var s = string.Concat(digitOne, (int)bFunc.myFunc);
                try {
                    int.Parse(s);
                    digitOne = s;
                    result = digitOne;
                } catch(Exception) { }
            } else {
                if((int)bFunc.myFunc < 14) {
                    cFunc = bFunc.myFunc;
                    funcUsed = true;
                    if(digitOne == "") digitOne = "0";
                }
            }
        } else {
            if((int)bFunc.myFunc < 10) {
                var s = string.Concat(digitTwo, (int)bFunc.myFunc);
                try {
                    int.Parse(s);
                    digitTwo = s;
                    result = digitTwo;
                } catch(Exception) { }
            }
        }
        switch(bFunc.myFunc) {
            case ButtonFunc.func.reset:
                ResetData();
                break;
            case ButtonFunc.func.result:
                try {
                    result = model.GetResult(float.Parse(digitOne), float.Parse(digitTwo), cFunc).ToString();
                } catch(Exception) { }
                digitOne = result;
                digitTwo = "";
                funcUsed = false;
                break;
        }
        observer.Invoke(result);
    }

    void ResetData() {
        digitOne = "";
        digitTwo = "";
        result = "0";
        funcUsed = false;
    }

    void OnDestroy() {
        PlayerPrefs.SetString("result", result);
    }
}
