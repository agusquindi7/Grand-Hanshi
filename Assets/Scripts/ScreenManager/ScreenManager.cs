using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{
    //public static ScreenManager instance;
    //public ScreenTest screenPaused;
    //Stack<IScreen> _screens = new Stack<IScreen>();

    //private void Awake()
    //{
    //    instance = this;
    //}
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if (_screens.Count <= 0)
    //            ActiveScreen(screenPaused);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Escape))
    //        DesactiveScreen();
    //}
    //public void ActiveScreen(IScreen screen)
    //{
    //    screen.Activate();

    //    if(_screens.Count > 0)
    //        _screens.Peek().Hide();


    //        //_screens.Peek().Desactivate();

    //    _screens.Push(screen);
    //}

    //public void DesactiveScreen()
    //{
    //    if(_screens.Count > 0)
    //    {
    //        _screens.Pop().Desactivate();

    //        if(_screens.Count > 0 )
    //            _screens.Peek().Activate();
    //    }
    //}





    public static ScreenManager instance;
    public ScreenTest nextScreen;       //referencio el script del boton
    Stack<IScreen> _screens = new Stack<IScreen>();

    public Button buttonOpenShop;
    public Button buttonCloseShop;

    public GameObject canvasShop;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Aseg�rate de que el bot�n no sea nulo
        if (buttonOpenShop != null)
        {
            buttonOpenShop.onClick.AddListener(OpenShop);  // Asignar el listener al bot�n
        }

        // Aseg�rate de que el bot�n no sea nulo
        if (buttonCloseShop != null)
        {
            buttonOpenShop.onClick.AddListener(CloseShop);  // Asignar el listener al bot�n
            //buttonOpenShop.onClick.ActiveScreen(nextScreen);

        }
    }

    void OpenShop()
    {
        // Hacer visible la imagen
        if (canvasShop != null)
        {
            //canvasShop.SetActive(true);  // Activar la imagen
            ActiveScreen(nextScreen);
        }
    }

    void CloseShop()
    {
        // Hacer visible la imagen
        if (canvasShop != null)
        {
            //canvasShop.SetActive(false);  // Activar la imagen
            DesactiveScreen();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_screens.Count <= 0)
                ActiveScreen(nextScreen);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            DesactiveScreen();
    }
    public void ActiveScreen(IScreen screen)
    {
        screen.Activate();

        if (_screens.Count > 0)
            _screens.Peek().Hide();


        //_screens.Peek().Desactivate();

        _screens.Push(screen);
    }

    public void DesactiveScreen()
    {
        if (_screens.Count > 0)
        {
            _screens.Pop().Desactivate();

            if (_screens.Count > 0)
                _screens.Peek().Activate();
        }
    }





    //public static ScreenManager instance;
    //public ScreenTest nextScreen;  // Pantalla que se muestra si no hay pantallas activas

    //private Stack<IScreen> _screens = new Stack<IScreen>();  // Pila de pantallas activas

    //private void Awake()
    //{
    //    instance = this;  // Aseguramos que solo haya una instancia del ScreenManager
    //}

    //// M�todo p�blico para activar la siguiente pantalla (puedes vincularlo a un bot�n de UI)
    //public void ActiveScreenUI()
    //{
    //    if (nextScreen != null)
    //        ActiveScreen(nextScreen);
    //}

    //// M�todo p�blico para desactivar la pantalla actual (puedes vincularlo a un bot�n de UI)
    //public void DesactiveScreenUI()
    //{
    //    DesactiveScreen();
    //}

    //// M�todo para activar una pantalla (y colocarla en la pila)
    //public void ActiveScreen(IScreen screen)
    //{
    //    screen.Activate();  // Activamos la pantalla

    //    // Si ya hay una pantalla activa, la ocultamos
    //    if (_screens.Count > 0)
    //        _screens.Peek().Hide();

    //    // A�adimos la nueva pantalla a la pila
    //    _screens.Push(screen);
    //}

    //// M�todo para desactivar la pantalla actual (y sacar la �ltima pantalla de la pila)
    //public void DesactiveScreen()
    //{
    //    if (_screens.Count > 0)
    //    {
    //        _screens.Pop().Desactivate();  // Desactivamos la pantalla actual

    //        // Si hay pantallas en la pila, activamos la pantalla anterior
    //        if (_screens.Count > 0)
    //            _screens.Peek().Activate();
    //    }
    //}







}
