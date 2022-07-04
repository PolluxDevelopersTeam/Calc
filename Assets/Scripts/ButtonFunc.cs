using UnityEngine;

[ExecuteInEditMode]
public class ButtonFunc : MonoBehaviour {

    public enum func {
        d0,
        d1,
        d2,
        d3,
        d4,
        d5,
        d6,
        d7,
        d8,
        d9,
        plus,
        minus,
        multiply,
        divide,
        result,
        reset
    }

    public func myFunc;

#if UNITY_EDITOR
    private void Update() {
        transform.name = $"btn_func( {myFunc} )";
    }
#endif
}
