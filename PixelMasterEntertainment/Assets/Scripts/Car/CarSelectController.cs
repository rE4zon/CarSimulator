using UnityEngine;
using UnityEngine.UI;

public class CarSelectController : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private int currentCar;

    private void Start()
    {
        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }

    private void SelectCar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void ChangeCar(int change)
    {
        currentCar += change;

        if (currentCar > transform.childCount - 1)
        {
            currentCar = 0;
        }
        else if (currentCar < 0)
        {
            currentCar = transform.childCount - 1;
        }

        Time.timeScale = 1f;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }
}