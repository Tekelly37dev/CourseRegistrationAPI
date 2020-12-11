using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseRegistration.Repository;
using CourseRegistration.Models;
using CourseRegistration.Services;

namespace CourseRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("courses")]// use this string in the url to access this get method
    public class CoursesController:ControllerBase

    {
        private ICourseServices _courseServices;
       

       
        public CoursesController(ICourseServices courseServices)
        {
            
            _courseServices = courseServices;

            
           
        }
        [HttpGet]
        public IActionResult GetAllCourses()// list of course objects 
        {
            try 
            {
                IEnumerable<Course> list = _courseServices.getCourses();

                if(list != null) return Ok(list);

                else return BadRequest();

               


            }

            catch (Exception )
            {
                return StatusCode(500, "Internal serval error"); 
            }


            
        }


       
       
        [HttpGet("{name}")]
        public IActionResult GetCoursesByName(string name )

        {
          try 
            {
                IEnumerable<Course> list = _courseServices.getCoursesByName(name);
                

                if(list != null) return Ok(list);

                else return BadRequest();


            }

            catch (Exception)
            {
                return StatusCode(500, "Internal serval error"); 
            }

    }


        
        

        [HttpGet("search/")]// accesed by ../courses/search?dept="ART"
          public IActionResult GetCoursesByDept(string dept )
        {
          try 

            {

                IEnumerable<Course> list = _courseServices.getCoursesByDept(dept);
                

                // if(list != null) return Ok(list);

                // else return BadRequest();
                return Ok(list);


            }

            catch (Exception )
            {
                return StatusCode(500, "Internal serval error"); 
            }

    }

        [HttpGet("{course}/offerings")]//ARTD 105/offerings?semester="Fall 2021"

        

            public IActionResult GetCourseOfferingsByCourseAndSemester(string course, string semester )

            {

             try 

                {

                     IEnumerable<CourseOffering> list = _courseServices.getOfferingsByCourseAndSemester(course, semester);
                

                       
                        
                        return Ok(list);


                }

                catch (Exception )

                {
                return StatusCode(500, "Internal serval error"); 
                }

            }




            [HttpPut("{name}")] 
             public IActionResult UpdateCourse(string name, Course courseIn){

              IEnumerable<Course> list = _courseServices.getCourses();

                     try{
                  
                    foreach(Course m in list){
                        if (m.Name.Equals(name)){
                            m.Name = courseIn.Name;
                            m.Title=courseIn.Title;
                            m.Credits=courseIn.Credits;
                            return NoContent();
                        }
                    }
                    return BadRequest();
                   

            }catch (Exception ){
                return StatusCode(500);

            }
           



           } 


           [HttpPost]
          
            public IActionResult AddCourse(Course m){
            try{
                   IEnumerable<Course> list = _courseServices.AddCourse(m);

                    return Ok();
            }catch (Exception){
                return StatusCode(500);

            }

        }
           
           


           [HttpDelete("{name}")] 
           public IActionResult DeleteCourse(string name){

                try {

                     List<Course> list = _courseServices.RemoveCourse(name);

                     if(list != null) return Ok(list);

                else return BadRequest();

               


       

            }catch (Exception ){
                return StatusCode(500);

            }
           

                
        } 


            [HttpGet("{course}/goals")]
            public IActionResult getCoreGoalsByCourse(string course){

            try 

            {

             IEnumerable<CoreGoal> list = _courseServices.getCoreGoalsByCourse(course);
              return Ok(list);


            }

            catch (Exception)
            {
                return StatusCode(500, "Internal serval error"); 
            }




        }




           




        
        }

           



}
