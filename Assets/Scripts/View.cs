using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {

    [SerializeField]
    Text field;
    ViewModel viewModel;

    private void Start() {
        viewModel = FindObjectOfType<ViewModel>();
        viewModel.observer.AddListener(SetToField);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    void SetToField(string result) {
        field.text = result;
    }

    public void buttonPressed(ButtonFunc bFunc) {
        viewModel.SetData(bFunc);
    }
}
