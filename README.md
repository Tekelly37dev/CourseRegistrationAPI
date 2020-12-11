# Course Regsitation CRUD

## Description 
- - -

 
This test application uses a layered architecture codebase and dependency injection in C# to create REST web services that will allow a student to easily schedule courses for an upcoming semester based on availability and alignment of core goals. 



## Installation
- - -

* If unfamiliar with creating web API's with ASP.NET Core please refer to [Microsofts creating a web API with ASP.NET Core tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio) for guidance. 
* Once you have created your webapi application in complete with scaffolding, you may add the necessary files found in this repo to run the application.


## Usage
- - - 
All 'Get' requests can be viewed from the localhost browser started upon running the application and entering the correct URL(see below), however the full capabilities, of creating, retrieving, updating, and deleting course data are only accessible using [Postman](https://www.postman.com/downloads/Postman), a free software allows you to configure http requests in finer detail in comparison to the browser.

Once you have installed Postman, you should be able to use each CRUD request i.e.

* Get all courses - ex. http://localhost:5000/courses 
* Get courses by name - ex. http://localhost:5000/courses/ARTD 105
* Search courses by department - ex. http://localhost:5000/courses/search?dept="ARTS"
* Add a new course - ex. http://localhost:5000/courses
* Update an existing course - ex. http://localhost:5000/courses/ARTD 105
* Delete an existing course - ex. http://localhost:5000/courses/ARTD 105
* Get all core goals that are met by a particular course - ex. http://localhost:5000/courses/ARTD 105/goals
* Get all course offerings for a particular course by semester - ex. http://localhost:5000/courses/ARTD 105/offerings?semester="Fall 2021"


This is accomplished simply changing the dropdown on the left to GET PUT, POST, or DELETE and changing the URL to match the correct endpoint. please note the 'ARTD 105' and 'Fall 2021' in the URL can be replaced with different courses and semesters that can be found in the CourseRepository.cs file.

 To update and create a course, be sure that in the body tab that 'raw' is selected and from the 'Text' drop-down, JSON is selected. 

To make your changes, copy a single-entry Ex)
``` JSON 
{
        "name": "ARTD 201",
        "title": "graphic design",
        "credits": 3,
        "description": "graphic design descr"
    }
 

 ```
 then, click Put (if you have created a course) or Post(if you have updated a pre-existing course) to confirm your edits.

 
