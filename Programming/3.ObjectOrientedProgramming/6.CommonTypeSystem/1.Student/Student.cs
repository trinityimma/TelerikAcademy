using System;
using System.Linq;
using System.Text;

class Student : Person, ICloneable, IComparable<Student>
{
    public string SocialSecurityNumber { get; private set; }

    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public string CourseSpecialty { get; private set; }
    public string University { get; private set; }
    public string Faculty { get; private set; }

    public Student(
        string firstName, string middleName, string lastName,
        string socialSecurityNumber,
        string address = "", string email = "", string phone = "",
        string courseSpecialty = "", string university = "", string faculty = ""
    )
        : base(firstName, middleName, lastName)
    {
        this.SocialSecurityNumber = socialSecurityNumber;

        this.Address = address;
        this.Email = email;
        this.Phone = phone;

        this.CourseSpecialty = courseSpecialty;
        this.University = university;
        this.Faculty = faculty;
    }

    public object Clone()
    {
        return new Student(
            this.FirstName, this.MiddleName, this.LastName,
            this.SocialSecurityNumber,
            this.Address, this.Email, this.Phone,
            this.CourseSpecialty, this.University, this.Faculty
        );
    }

    // TODO: Optimize
    public int CompareTo(Student other)
    {
        if (Student.Equals(this, other)) return 0;

        return Student.Equals(
            new Student[] { this, other }
            .OrderBy(
                student => student.FirstName
            ).ThenBy(
                student => student.MiddleName
            ).ThenBy(
                student => student.LastName
            ).ThenBy(
                student => student.SocialSecurityNumber
            ).First()
        , this) ? -1 : 1;
    }

    public override bool Equals(Object other)
    {
        return this.SocialSecurityNumber == (other as Student).SocialSecurityNumber;
    }

    public override int GetHashCode()
    {
        return SocialSecurityNumber.GetHashCode();
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(base.ToString());

        if (!String.IsNullOrEmpty(this.SocialSecurityNumber))
            info.AppendLine("SocialSecurityNumber: " + this.SocialSecurityNumber);

        if (!String.IsNullOrEmpty(this.Address))
            info.AppendLine("Address: " + this.Address);

        if (!String.IsNullOrEmpty(this.Email))
            info.AppendLine("Email: " + this.Email);

        if (!String.IsNullOrEmpty(this.Phone))
            info.AppendLine("Phone: " + this.Phone);

        if (!String.IsNullOrEmpty(this.CourseSpecialty))
            info.AppendLine("CourseSpecialty: " + this.CourseSpecialty);

        if (!String.IsNullOrEmpty(this.University))
            info.AppendLine("University: " + this.University);

        if (!String.IsNullOrEmpty(this.Faculty))
            info.AppendLine("Faculty: " + this.Faculty);

        return info.ToString().TrimEnd();
    }
}
