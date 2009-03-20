﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Beta
{
    class Menu
    {
        // Enumeration for game states
        enum State
        {
            Menu = 1,
            Tutorial = 2,
            Game = 3,
            Quit = 4
        }

        // Background image
        Image background = new Image();

        // Cursor
        Cursor cursor = new Cursor();

        // Buttons
        // Are animations to handle mouse overs
        Animation gameButton = new Animation();
        Animation tutorialButton = new Animation();
        Animation quitButton = new Animation();

        public Menu()
        {
        }

        public void Initialize()
        {
            // Initialize background
            background.Initialize(Vector2.Zero, new Rectangle(0, 0, 798, 798), Color.White, Vector2.Zero, Vector2.One, 1.0f);
            // Initialize cursor
            cursor.Initialize(Vector2.Zero, new Rectangle(0, 0, 50, 50), Color.White, Vector2.Zero, Vector2.One, 0.0f);
            // Initialize buttons
            gameButton.Initialize(new Vector2(200, 200), new Rectangle(0, 0, 150, 50), Vector2.Zero, 0.5f, 10, 2, false);
            tutorialButton.Initialize(new Vector2(300, 300), new Rectangle(0, 0, 150, 50), Vector2.Zero, 0.5f, 10, 2, false);
            quitButton.Initialize(new Vector2(400, 400), new Rectangle(0, 0, 150, 50), Vector2.Zero, 0.5f, 10, 2, false);
        }

        public void LoadContent(SpriteBatch spriteBatch, Texture2D menuBackground, Texture2D cursorTex, Texture2D gameBtnTex, Texture2D tutorialBtnTex, Texture2D quitBtnTex)
        {
            // Pass content to the background image
            background.LoadContent(spriteBatch, menuBackground);
            // Pass content to the cursor
            cursor.LoadContent(spriteBatch, cursorTex);
            // Pass content to the buttons
            gameButton.LoadContent(spriteBatch, gameBtnTex);
            tutorialButton.LoadContent(spriteBatch, tutorialBtnTex);
            quitButton.LoadContent(spriteBatch, quitBtnTex);
        }

        public void Update(GameTime gameTime, ref int state)
        {
            // Get the mouse state
            MouseState mouseState = Mouse.GetState();
            // Get the keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Change game button on mouse over
            if (mouseState.X > 200 && mouseState.X < 350 && mouseState.Y > 200 && mouseState.Y < 250)
                gameButton.LastFrame();
            else
                gameButton.Reset();

            // Change tutorial button on mouse over
            if (mouseState.X > 300 && mouseState.X < 450 && mouseState.Y > 300 && mouseState.Y < 350)
                tutorialButton.LastFrame();
            else
                tutorialButton.Reset();

            // Change quit button on mouse over
            if (mouseState.X > 400 && mouseState.X < 550 && mouseState.Y > 400 && mouseState.Y < 450)
                quitButton.LastFrame();
            else
                quitButton.Reset();

            // Update Cursor position
            cursor.Update();
            // Update the buttons
            gameButton.Update(gameTime);
            tutorialButton.Update(gameTime);
            quitButton.Update(gameTime);
        }

        public void Click(MouseState mouseState, ref int state)
        {
            // Check if clicked on tutorial button
            if (mouseState.X > 300 && mouseState.X < 450 && mouseState.Y > 300 && mouseState.Y < 350)
            {
                // No tutorial state yet
                // Uncomment this line after implemented
                //state = (int)State.Tutorial;
            }

            // Check if clicked on game button
            if (mouseState.X > 200 && mouseState.X < 350 && mouseState.Y > 200 && mouseState.Y < 250)
            {
                // Set the state to the game state
                state = (int)State.Game;
            }

            // Check if clicked on quit button
            if (mouseState.X > 400 && mouseState.X < 550 && mouseState.Y > 400 && mouseState.Y < 450)
            {
                state = (int)State.Quit;
            }
        }

        public void Draw()
        {
            // Draw background
            background.Draw();

            // Draw buttons
            gameButton.Draw();
            tutorialButton.Draw();
            quitButton.Draw();

            // Draw cursor
            cursor.Draw();
        }
    }
}
