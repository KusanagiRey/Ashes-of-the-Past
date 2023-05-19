using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [Header("Menu Navigation")]
   [SerializeField] private SaveSlotsMenu saveSlotsMenu;

   public void OnNewGameClicked()
   {
      saveSlotsMenu.ActivateMenu(false);
      this.DeactivateMenu();
   }

   public void OnLoadGameClicked()
   {
      saveSlotsMenu.ActivateMenu(true);
      this.DeactivateMenu();
   }

   public void QuitGame()
   {
        Application.Quit();
   }

   public void ActivateMenu()
   {
      this.gameObject.SetActive(true);
   }

   public void DeactivateMenu()
   {
      this.gameObject.SetActive(false);
   }
}
