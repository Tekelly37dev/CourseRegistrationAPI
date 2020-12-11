using System;
using CourseRegistration.Repository;

namespace CourseRegistration.Models
{
    public class CourseOffering: IComparable<CourseOffering>
    {
        public Course TheCourse {get;set;}
        public string Semester {get;set;}
        public string Section {get;set;}
   

        public override String ToString() {
            return $"{TheCourse} Section {Section} offered ({Semester})n";

        }
        public int CompareTo(CourseOffering other) {
            return this.Semester.CompareTo(other.Semester);
        }
    }
}