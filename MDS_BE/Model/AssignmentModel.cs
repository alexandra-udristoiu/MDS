namespace MDS_BE.Model
{
    public class AssignmentModel
    {
        public int AssignmentId { get; set; }
        public string CourseName { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public int CourseId { get; set; }
    }
}
