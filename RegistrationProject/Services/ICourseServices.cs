using System;
using System.Collections.Generic;
using CourseRegistration.Repository;
using CourseRegistration.Models;


namespace CourseRegistration.Services{


    public interface ICourseServices
    
    {
       
        public List <CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester);
        public List<Course> getCourses();
        public List<CourseOffering> getCourseOfferingsBySemester(String semester);
        public List<CourseOffering> getCourseOfferingsBySemesterAndDept(String semester, String Dept);
        public List<Course> getCoursesByGoalId(String userGoalId); 
        public List<Course> getCoursesByGoalIds(String userGoalId1, String userGoalId2);
        public List<CoreGoal> getCoreGoalsThatAreNotCoveredBySemester(String semester);
        public List<Course> getCoursesByName(string name);
        public List<Course> getCoursesByDept(String Dept);
        public List<Course> RemoveCourse(string name);
        public List<Course> AddCourse(Course name);
        public List<CoreGoal> getCoreGoalsByCourse(String course);
        public List<CourseOffering> getOfferingsByCourseAndSemester(String course, String semester);

           
    }
}
