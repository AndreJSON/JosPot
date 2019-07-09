using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SkiaSharp;

namespace JosPot
{
    public class GameManager
    {
        public GameBackground Background;
        public GameState State;
        public GameTopBar TopBar;
        public GameMenu Menu;
        public GameOverlay Overlay;

        public GameManager(float width, float height)
        {
            float backgroundWidth = width;
            float backgroundHeight = height;
            float backgroundScale = backgroundWidth / 100f;
            Background = new GameBackground(0, 0, 100f, backgroundHeight/backgroundScale, backgroundScale);

            float topBarWidth = backgroundWidth;
            float topBarHeight = backgroundWidth * 0.12f;
            float topBarScale = topBarWidth / 100f;
            TopBar = new GameTopBar(0, 0, 100f, topBarHeight/topBarScale, topBarScale);

            float gameWidth = backgroundWidth;
            float gameHeight = (backgroundWidth * 4) / 3;
            float gameScale = gameWidth / 100f;
            State = new GameState(0, topBarHeight, 100f, gameHeight/gameScale, gameScale);

            float menuWidth = backgroundWidth;
            float menuHeight = backgroundHeight - topBarHeight - gameHeight;
            float menuScale = menuWidth / 100f;
            Menu = new GameMenu(0, topBarHeight + gameHeight, 100f, menuHeight/menuScale, menuScale);

            Overlay = new GameOverlay(0, 0, 100f, backgroundHeight / backgroundScale, backgroundScale);
        }

        public void Draw(SKCanvas c)
        {
            Background.Draw(c);
            State.Draw(c);
            TopBar.Draw(c);
            Menu.Draw(c);
            Overlay.Draw(c);
        }

        public void Tick()
        {
            Background.Tick();
            Overlay.Tick();
        }
    }
}
