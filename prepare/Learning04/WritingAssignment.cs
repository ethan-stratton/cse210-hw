public class WritingAssignment : Assignment{
    private string _title;

    public WritingAssignment(string name, string topic, string title){
        _studentName = name;
        _topic = topic;
        _title = title;
    }

    public string GetWritingInformation(){
        return $"{_title} by {_studentName}";
    }
}

//  public WritingAssignment(string studentName, string topic, string title)
//         : base(studentName, topic)
//     {
//         // Here we set any variables specific to the WritingAssignment class
//         _title = title;
//     }

//     public string GetWritingInformation()
//     {
//         // Notice that we are calling the getter here because _studentName is private in the base class
//         string studentName = GetStudentName();

//         return $"{_title} by {studentName}";
//     }