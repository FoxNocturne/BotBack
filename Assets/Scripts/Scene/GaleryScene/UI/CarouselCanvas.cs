using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarouselCanvas : MonoBehaviour
{
    [SerializeField] private List<CanvasRenderer> _listCanvas;
    [SerializeField] private int _defaultSelectedId = 0;

    private int _selectedId;

    void Awake()
    {
        this.FocusCanvas(this._defaultSelectedId);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToNext()
    {
        this._selectedId = (this._selectedId + 1) % this._listCanvas.Count;
        this.FocusCanvas(this._selectedId);
    }

    public void GoToPrevious()
    {
        this._selectedId = (this._selectedId == 0 ? this._listCanvas.Count : this._selectedId) - 1;
        this.FocusCanvas(this._selectedId);
    }

    public void FocusCanvas(int id)
    {
        this._selectedId = id;
        int currentId = 0;
        foreach (CanvasRenderer canvas in this._listCanvas) { 
            canvas.gameObject.SetActive(currentId == this._selectedId);
            currentId++;
        }
    }
}
