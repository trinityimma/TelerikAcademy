using System;

class Discipline : ICommentable, IComparable<Discipline>
{
    public int NumberOfLectures { get; private set; }
    public int NumberOfExercises { get; private set; }

    public string Topic { get; private set; }

    public string Comment { get; set; }

    public Discipline(string topic, int numberOfLectures = 0, int numberOfExercises = 0)
    {
        this.Topic = topic;
        this.NumberOfLectures = numberOfLectures;
        this.NumberOfExercises = numberOfExercises;
    }

    public int CompareTo(Discipline other)
    {
        return this.Topic.CompareTo(other.Topic);
    }

    public override string ToString()
    {
        return String.Format("Topic: {0}; Number of Lectures: {1}; Number of Exercises: {2}",
            this.Topic, this.NumberOfLectures, this.NumberOfExercises);
    }
}
