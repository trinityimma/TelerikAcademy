using System;

interface IUserInterface
{
    //creating the event handlers for the user interface
    event EventHandler OnLeft;

    event EventHandler OnRight;

    event EventHandler OnRotate;

    event EventHandler OnDrop;

    void ProcessInput();
}
