using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager :BaseUi
{
    public static UIManager Instance;
    public List<BaseUi> screens;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this);
        }
        
    }

    public void ActivateScreen<T>() where T:BaseUi{
        BaseUi screen =screens.Find(t=>t.GetType().Name==typeof(T).Name);
       if(screen!=null)
        {
            screen.EnableScreen();
        }}
     
    

    public void DeactivateScreen<T>()where T :BaseUi{
        BaseUi screen=screens.Find(t=>t.GetType().Name==typeof(T).Name);
        if(screen!=null)
        screen.DisableScreen();
    }
   
}
