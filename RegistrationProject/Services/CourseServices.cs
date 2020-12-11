using System;
using System.Collections.Generic;
using CourseRegistration.Repository;
using CourseRegistration.Models;

namespace CourseRegistration.Services
{
    public class CourseServices:ICourseServices
    {

                       private CourseRepository repo = new CourseRepository();

        

       
         public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester) {
         
            List<CoreGoal> theGoals = repo.Goals;

            List<CourseOffering> theOfferings = repo.Offerings;

        

            CoreGoal theGoal=null;

            foreach(CoreGoal cg in theGoals) {

                if(cg.Id.Equals(theGoalId)) {

                    theGoal=cg; break;

 

                }

            }

            if(theGoal==null) throw new Exception("Didn't find the goal");

           
            List<CourseOffering> courseOfferingsThatMeetGoal = new List<CourseOffering>();

            

            foreach(CourseOffering c in theOfferings) {

                if(c.Semester.Equals(semester) 

                    && theGoal.Courses.Contains(c.TheCourse) ) 

                {

                        courseOfferingsThatMeetGoal.Add(c);

                }

 

            }

            return courseOfferingsThatMeetGoal;

        }





        public List<Course> getCourses(){

        List<Course> allCourses = repo.Courses; 
        List<Course> courseOfferings = new List<Course>(); 

        foreach(Course d in allCourses) 

        {
          courseOfferings.Add(d);

        }
            return courseOfferings;



       }

        public List<Course> getCoursesByName(string name){

        List<Course> allCourses = repo.Courses; 
        List<Course> courseOfferings = new List<Course>(); 

        foreach(Course d in allCourses) 

        {
          if (d.Name.Equals(name)){

              courseOfferings.Add(d);

          }
              

        }
            return courseOfferings;



       }



        public List<CourseOffering> getCourseOfferingsBySemester(String semester) {

        List<CourseOffering> theOfferings = repo.Offerings; 

        List<CourseOffering> courseOfferingsThatMeetSemester = new List<CourseOffering>();
           

            CourseOffering theGoal = null;

            foreach(CourseOffering f in theOfferings) {

                if(f.Semester.Equals(semester)) {

                    theGoal=f;

                    courseOfferingsThatMeetSemester.Add(theGoal);

                    
                    break;


                }

            }

            if(theGoal==null) throw new Exception("Didn't find any offerings for this semester");


                

           
                return courseOfferingsThatMeetSemester;
            

        }

        public List<CourseOffering> getCourseOfferingsBySemesterAndDept( String semester, String Dept){

           

            List<CourseOffering> theOfferings = repo.Offerings;

            List<Course> courses = repo.Courses;
            List<CourseOffering>  MeetSemAndDept = new List<CourseOffering>(); 


            Course theName = null;

            foreach (Course f in courses){


            
                if(f.Name.Contains(Dept)){

                    theName = f;
                    break;


                }
                

            }if(theName == null) throw new Exception("Didn't find any offerings for this Department");

            foreach (CourseOffering z in theOfferings)
            {
                if(z.TheCourse.Equals(theName) && z.Semester.Equals(semester))
                
                {
                        MeetSemAndDept.Add(z);


                }

              
            }


                    return MeetSemAndDept;
        } 

        public List<Course> getCoursesByGoalId(String userGoalId) {

        List<CoreGoal> byGoalIDOnly = repo.Goals; 
        List<Course> byGoal = repo.Courses;

        List<Course> corseThatMeetGoalID = new List<Course>();
           



            CoreGoal theGoal3 = null;

            foreach(CoreGoal f in byGoalIDOnly) {

                if(f.Id.Equals(userGoalId)) {
                       
                            theGoal3 = f;
                

                              break;
                        }
               
                        

                }if(theGoal3==null)throw new Exception("There are no matches for this goal");

                 foreach(Course f in byGoal) 
                 {

                     if (theGoal3.Courses.Contains(f))
                     {

                            corseThatMeetGoalID.Add(f);         

                     }

 

                 }

                return  corseThatMeetGoalID;

            }


        public List<Course> getCoursesByGoalIds(String userGoalId1, String userGoalId2 ) {

        List<CoreGoal> byGoalIDsOnly = repo.Goals; 
        List<Course> byGoals = repo.Courses;

        List<Course> courseThatMeet2GoalID = new List<Course>();
           



            CoreGoal theGoal4 = null;
            CoreGoal theGoal5 = null;

            foreach(CoreGoal f in byGoalIDsOnly) {

                if(f.Id.Equals(userGoalId1)) 
            {

                    theGoal4 = f;// deafult 
                

                    break;

                }
            }if(theGoal4==null)throw new Exception("Goal not found");


            foreach (CoreGoal g in byGoalIDsOnly) {

                if(g.Id.Equals(userGoalId2) )
            {

                         theGoal5 = g ;
                

                     break;

                }
                
            }if(theGoal5==null)throw new Exception("Goal not found");
                

        foreach(Course z in byGoals) 
        {

                     if (theGoal4.Courses.Contains(z)
                     && theGoal5.Courses.Contains(z))

                     {


                            courseThatMeet2GoalID.Add(z);         

                     }

 

            }

            return courseThatMeet2GoalID;
    }


        public List<CoreGoal> getCoreGoalsThatAreNotCoveredBySemester(String semester){

            List<CoreGoal> theGoals = repo.Goals;

            List<CourseOffering> theOfferings = repo.Offerings;

            List<CoreGoal> goalsWithoutOfferings = new List<CoreGoal>();

                    CourseOffering theGoal1 = null;

            foreach(CourseOffering f in theOfferings) {

                if(f.Semester.Equals(semester))

                {

                    theGoal1 = f; // deafult 
        

                    break;

                }

            }if(theGoal1==null)throw new Exception("Didn't find any core goals without offerings for this semester");



            foreach(CoreGoal z in theGoals) 

             {

                if(z.Courses.Contains(theGoal1.TheCourse) == false){

                    goalsWithoutOfferings.Add(z);


                }

            

            }
                return goalsWithoutOfferings;
    
        
    
        }


        public List<CoreGoal> getCoreGoalsByCourse(String course){

            List<Course> allCourses = repo.Courses;
            List<CoreGoal> checkingGoals = repo.Goals;
            List<CoreGoal> GoalsByCourse = new List<CoreGoal>();


             Course theCourse = null;

            foreach(Course f in allCourses) {

                if(f.Name.Equals(course))

                {

                    theCourse = f; 
        

                    break;

                }

            }if(theCourse==null)throw new Exception("Didn't find any courses matching this name");



             foreach(CoreGoal z in checkingGoals) 

             { 
                 if( z.Courses.Contains(theCourse)){

                     GoalsByCourse.Add(z);


                 }

                


                }

            return GoalsByCourse;

            }
                
    
    


         public List<Course> getCoursesByDept(String Dept){
            
            List<Course> courses = repo.Courses;

            List<Course>  MeetDept = new List<Course>(); 


            foreach (Course f in courses){


                if(f.Name.Contains(Dept)){
                    
                    MeetDept.Add(f);
                   

                }

               
                

            }

            
                return MeetDept;
              
        }




        public List<Course> RemoveCourse(string name){

        List<Course> allCourses = repo.Courses; 
        List<Course> courseOfferings = new List<Course>(); 

        foreach(Course d in allCourses) 

        {
            foreach(Course m in allCourses){
                if(m.Name.Equals(name)){

                      courseOfferings.Remove(m);

                }
            }
          courseOfferings.Add(d);

        }
            return courseOfferings;



       }


       public List<Course> AddCourse(Course course){

        List<Course> allCourses = repo.Courses; 
        List<Course> courseOfferings = new List<Course>(); 

        

        Course l = new Course();
        l = course;
        l.Name = course.Name;
        l.Title = course.Title;
        l.Description = course.Description;

  
        allCourses.Add(course);

        foreach(Course h in allCourses){
            courseOfferings.Add(h);



        }


        return  courseOfferings;

       }



        public List<CourseOffering> getOfferingsByCourseAndSemester(String course, String semester) {
          
            List<Course> courses = repo.Courses;

            List<CourseOffering> theOfferings = repo.Offerings;

            List<CourseOffering> OfferingsBySemesterAndCourse = new List<CourseOffering> ();

            
            Course theCourse=null;

            foreach(Course c in courses) {

                if(c.Name.Equals(course)) {

                    theCourse=c; break;

 

                }

            }

            if(theCourse==null) throw new Exception("Didn't find the course");

            //search list of courses, then for each course, search offerings

           

            

            foreach(CourseOffering c in theOfferings) {

                if(c.Semester.Equals(semester) 

                &&c.TheCourse.Equals(theCourse))

                   

                {

                       OfferingsBySemesterAndCourse.Add(c);

                }

 

            }

            return OfferingsBySemesterAndCourse;

        }

       

    }

        
}
                   
  







    
