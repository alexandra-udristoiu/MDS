# MDS Project

## I. App demo
https://drive.google.com/drive/folders/1jIxcQP_lTKMtUCCWOG5n2vF_zL8lFaLq?usp=sharing

## II. Project management
We  used Notion in order to manage and organise our tasks during developing the application –https://www.notion.so/e604e6134a0d4cb1a02470417ffd58f9?v=322b68d251af45e185711f40aade8730

##III. User stories
 1. “As a user, I want to be able to change my account settings.”
 2. “As a user, I want to have a page where everyone can view my profile .”
 3. “As a student, I want to enroll in different courses, so that I can attend meetings and access courses documents.”
 4. “As a user, I want to be able to ask public questions, so that I can get help from other users.”
 5. “As a user, I want to be able to give a response to a question, so I can help others.”
 6. “As a teacher, I want to add assignments, so that my students can complete them and be evaluated.”
 7. “As an admin, I want to have the right to assign roles to users.”
 8. “As a teacher, I want to be able to add the courses I teach.”
 9. “As an admin, I want to be able to add new organizations.”
10. “As a student, I want to access the course page, so that I can decide if I want to attend it.”
11. “As a student, I want to know what materials I have read so far so that I can easily keep track of my course activity.”

## IV. UML

## V. Backlog

### Building tools:
  Our project was developed in Visual Studio(back-end) and Visual Studio Code(front-end) and the building tool which
### Bug reporting:
  We have encountered the following bugs:

## VI. Automatation testing:
  For the automated testing, we used xUnit, the integrated framework for testing in .NET development. The main purpose of unit testing the backend of the project was to check the flow of data sent from and into the database by the HTTP requests.
  In order to achieve this goal, we had to simulate an environment for all the existing controllers in the project. The testing part for the app consists of another project, named MDS_BE.Tests, which is linked to the source code from the MDS_BE project. Each controller has its own class for testing, with different methods which implement test cases for the HTTP requests. For example, for a get request we will check for the typed returned, whether the action was successful and finally for the actual data returned. Due to numerous tests needed, in order to keep the code clean and reliable, the tests do not access directly the data from the database and they in fact work on some mock data.
