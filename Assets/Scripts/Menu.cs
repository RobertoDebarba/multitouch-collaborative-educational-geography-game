using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    void OnGUI()
    {


        var screenWidth = Screen.width;
        var screenHeight = Screen.height;

        var groupWidth = 120;
        var groupHeight = 150;

        var groupX = (screenWidth - groupWidth) / 2;
        var groupY = (screenHeight - groupHeight) / 2;

        //GUI.backgroundColor = new Color(168, 201, 255);
        var botaoFacil = GUI.Button(new Rect(screenWidth / 2.5f, screenHeight / 3, screenWidth / 5, screenHeight / 10), "Fácil");

        //GUI.color = new Color(168, 201, 255);
        var botaoMedio = GUI.Button(new Rect(screenWidth / 2.5f, screenHeight / 3 + 80, screenWidth / 5, screenHeight / 10), "Médio");

        //GUI.color = new Color(255, 255, 255);
        var botaoDificil = GUI.Button(new Rect(screenWidth / 2.5f, screenHeight / 3 + 160, screenWidth / 5, screenHeight / 10), "Difícil");

        //GUI.color = new Color(168, 201, 255);
        var botaoSair = GUI.Button(new Rect(screenWidth / 2.5f, screenHeight / 3 + 240, screenWidth / 5, screenHeight / 10), "Sair");

        if (botaoFacil)
        {
            Application.LoadLevel(1);
        }
        if (botaoMedio)
        {
            Application.LoadLevel(2);
        }
        if (botaoDificil)
        {
            Application.LoadLevel(3);
        }
        if (botaoSair)
        {
            Application.Quit();
        }
    }
}
