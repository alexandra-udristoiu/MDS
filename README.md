# MDS Project
MDS Project is an web application built using **.NET** and **Angular** Framework and it serves as the final project for the course of Software Development Methodologies. The **team** which took part in the development of the app consist of the following members: **[Acatrinei Carmen](https://github.com/carmenacatrinei)**, **[Dascălu Mara](https://github.com/MaraDascalu)**, **[Lupașcu Miruna](https://github.com/LupascuMiruna)**, **[Toader Andi](https://github.com/andidroid2000)** and **[Udriștoiu Alexandra](https://github.com/alexandra-udristoiu)**.

## 1. Application description
This project is a web application that creates an online learning environment for people who want to deepen their knowledge in various fields at university level.

### 1.1 Reasoning for choosing this project
Following the two years of the coronavirus pandemic, everyone who has been involved in some form of education, be it high school or college, has been directly affected by the transition from offline to online. With this transition, shortcomings that made online learning unattractive were soon discovered: learning materials were scarce and disorganized, there was no way to grade and highlight student progress and communication was generally low.

Although the pandemic is over, we can still see an accelerated trend of digitalization of education, so our team found it appropriate to develop in this context an application that would solve the problems we have encountered so far and that could become a real alternative to learning in physical form.

### 1.2 Defining the app - User stories
The next statements are description of features that a possible user of the app would like to have:
 1. *As a user, I want to be able to change my account settings.*
 2. *As a user, I want to have a page where everyone can view my profile .*
 3. *As a student, I want to enroll in different courses, so that I can attend meetings and access courses documents.*
 4. *As a user, I want to be able to ask public questions, so that I can get help from other users.*
 5. *As a user, I want to be able to give a response to a question, so I can help others.*
 6. *As a teacher, I want to add assignments, so that my students can complete them and be evaluated.*
 7. *As an admin, I want to have the right to assign roles to users.*
 8. *As a teacher, I want to be able to add the courses I teach.*
 9. *As an admin, I want to be able to add new organizations.*
10. *As a student, I want to access the course page, so that I can decide if I want to attend it.*
11. *As a student, I want to know what materials I have read so far so that I can easily keep track of my course activity.*

### 1.3 Implementation backbone - UML Scheme
The below scheme shows the main entities of the application and the way they interact:

![uml scheme](/assets/uml.png)

### 1.4 How it works - Application demo
The demo of the application can be found [here](https://drive.google.com/drive/folders/1jIxcQP_lTKMtUCCWOG5n2vF_zL8lFaLq?usp=sharing).

## 2. Project management
We  used Notion in order to manage and organise our tasks during developing the application – access the app [here](https://www.notion.so/e604e6134a0d4cb1a02470417ffd58f9?v=322b68d251af45e185711f40aade8730)

![notion scheme](/assets/notion.png)

## 3. App development

### 3.1 Building tools
Our project was developed using the **Visual Studio Community 2019 IDE** for back-end and **Visual Studio Code IDE** for front-end. One of the building tools used was **Angular CLI** command-line tool to create the front-end project, generate application and library code:
- create the project
```
ng new front-end-project
cd front-end-project
ng serve
```
- create a component 
```
ng generate component courses
```
- create a service to access the database and the routing
```
ng generate service courses
```

### 3.2 Code standards
Code standards and refactoring for backend (C#):
- Class and Method names should always be in Pascal Case
- Method argument and Local variables should always be in Camel Case
- Avoid the use of underscore while naming identifiers 
- Avoid the use of System data types and prefer using the Predefined data types
- Always prefix an interface with letter I
- For better code indentation and readability always align the curly braces vertically
```
public class AssignmentController : Controller
    {
        public readonly IAssignmentManager manager;
        ...

        [HttpGet("Course-Assignment")]
        [Authorize(Policy = "ALL")]
        public async Task<IActionResult> GetCourseAssignments(int courseId)
        {
            var assignments = manager.GetCourseAssignments(courseId);

            return Ok(assignments);
        }     
        ...
     }
```
Code standards and refactoring for front-end:
- Apply the single responsibility principle (SRP) to all components, services, and other symbols.
- Do define small functions
- Folders-by-feature structure

### 3.3 Bug reporting
During development, several [bugs](https://github.com/alexandra-udristoiu/MDS/pull/10/commits/4254c7858a9be3d02293c68fda1c52e969e41949) were encountered:

![bug report image](/assets/bug.png)  

### 3.4 Automatation testing
For the automated testing, we used **xUnit**, the integrated framework for testing in .NET development. The main purpose of unit testing the backend of the project was to **check the flow of data** sent from and into the database by the HTTP requests.
  
In order to achieve this goal, we had to simulate an environment for all the existing controllers in the project. The testing part for the app consists of another project, named **MDS_BE.Tests**, which is linked to the source code from the **MDS_BE project**. Each controller has its own class for testing, with different methods which implement test cases for the HTTP requests. For example, for a **get request** we will check for the **typed returned, whether the action was successful and finally for the actual data returned**. Due to numerous tests needed, in order to keep the code clean and reliable, the tests do not access directly the data from the database and they in fact work on some mock info.

Running the tests will return a **scheme of all the exit status** (whether the test was successful or not) and the time taken to completion, as shown below:

![unit test result](/assets/unittest.png)
