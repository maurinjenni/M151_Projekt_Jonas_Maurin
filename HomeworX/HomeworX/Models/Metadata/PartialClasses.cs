using System.ComponentModel.DataAnnotations;
using HomeworX.Models.Metadata;

namespace HomeworX.Models
{
    [MetadataType(typeof(AppointmentMetadata))]
    public partial class Appointment
    {

    }

    [MetadataType(typeof(ExamMetadata))]
    public partial class Exam
    {

    }

    [MetadataType(typeof(HomeworkMetadata))]
    public partial class Homework
    {

    }


    [MetadataType(typeof(TopicMetadata))]
    public partial class Topic
    {

    }

    [MetadataType(typeof(SubjectMetadata))]
    public partial class Subject
    {

    }
}