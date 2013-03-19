using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

partial class Engine
{
    private const int DefaultDelay = 125; // 30
    private const int TurboDelay = DefaultDelay / 5;

    private int animationDelay = DefaultDelay;

    private bool isGameOver = false;

    private int fieldStartCol = 0;
    private int fieldEndCol = 0;

    private MovingObject controlledObject = null;

    private readonly List<GameObject> allObjects = new List<GameObject>();
    private readonly List<MovingObject> movingObjects = new List<MovingObject>();

    private readonly IRenderer renderer = null;
    private readonly IUserInterface userInterface = null;

    public event EventHandler<int> OnClearedRows = null; // Number of cleared rows
    public event EventHandler OnMoveEnd = null;
    public event EventHandler OnGameOver = null;

    public Engine(IRenderer renderer, IUserInterface userInterface)
    {
        this.renderer = renderer;
        this.userInterface = userInterface;

        this.OnMoveEnd += this.ResetAnimationDelay;
        this.OnMoveEnd += this.CheckForClearedRows;
    }

    public void InitializeField(int fieldStartCol, int fieldEndCol)
    {
        this.fieldStartCol = fieldStartCol;
        this.fieldEndCol = fieldEndCol;
    }

    public void AddControlled(MovingObject obj)
    {
        this.controlledObject = obj;

        this.Add(obj);

        if (GetCollidedObject(this.controlledObject) != null)
        {
            this.isGameOver = true;

            this.OnGameOver(this, new EventArgs());
        }
    }

    public void Add(params MovingObject[] objects)
    {
        foreach(MovingObject obj in objects)
        {
            this.allObjects.Add(obj);

            this.movingObjects.Add(obj);
        }
    }

    public void Add(params GameObject[] objects)
    {
        foreach (GameObject obj in objects)
            this.allObjects.Add(obj);
    }

    private void RenderAll()
    {
        foreach (IDrawable obj in this.allObjects)
            this.renderer.Add(obj);

        this.renderer.RenderAll();
    }

    public void Run()
    {
        while (!this.isGameOver)
        {
            this.RenderAll();

            Thread.Sleep(animationDelay);

            this.userInterface.ProcessInput();

            if (GetCollidedObject(this.controlledObject) != null)
                this.OnMoveEnd(this, new EventArgs());

            foreach (MovingObject obj in this.movingObjects)
                if (GetCollidedObject(obj) == null)
                    obj.Update();

            this.allObjects.RemoveAll(
                obj => obj.IsDestroyed
            );

            this.movingObjects.RemoveAll(
                obj => obj.IsDestroyed
            );
        }
    }
}
