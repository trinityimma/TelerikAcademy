using System;

interface IUserInterface
{
    event EventHandler OnLeft;

    event EventHandler OnRight;

    event EventHandler OnRotate;

    event EventHandler OnDrop;

    void ProcessInput();
}
