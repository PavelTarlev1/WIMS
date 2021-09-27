**Design and implement a Work Item Management System (WIMS).**

**Functional Requirements**

**Application should support multiple teams. Each team has name, members and boards.**

* [x] Member has name, list of work items and activity history.
* [x] Name should be unique in the application.
* [x] Name is a string between 5 and 15 symbols.

* [x] Board has name, list of work items and activity history.
* [x] Name should be unique in the team.
* [x] Name is a string between 5 and 10 symbols.

**There are 3 types of work items: bug, story and feedback.**

* [x] Bug has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments and history.
* [x] Title is a string between 10 and 50 symbols.
* [x] Description is a string between 10 and 500 symbols.
* [x] Steps to reproduce is a list of strings.
* [x] Priority is one of the following: [High, Medium, Low]
* [x] Severity is one of the following: [Critical, Major, Minor]
* [x] Status is one of the following: [Active, Fixed]
* [x] Assignee is a member from the team.
* [x] Comments is a list of comments (string messages with author).
* [x] History is a list of all changes (string messages) that were done to the bug.


**Story has ID, title, description, priority, size, status, assignee, comments and history.**

* [x] Title is a string between 10 and 50 symbols.
* [x] Description is a string between 10 and 500 symbols.
* [x] Priority is one of the following: [High, Medium, Low]
* [x] Size is one of the following: [Large, Medium, Small]
* [x] Status is one of the following: [NotDone, InProgress, Done]
* [x] Assignee is a member from the team.
* [x] Comments is a list of comments (string messages with author).
* [x] History is a list of all changes (string messages) that were done to the story.


**Feedback has ID, title, description, rating, status, comments and history.**

* [x] Title is a string between 10 and 50 symbols.
* [x] Description is a string between 10 and 500 symbols.
* [x] Rating is an integer.
* [x] Status is one of the following: [New, Unscheduled, Scheduled, Done]
* [x] Comments is a list of comments (string messages with author).
* [x] History is a list of all changes (string messages) that were done to the feedback.

Note: IDs of work items should be unique in the application i.e. if we have a bug with ID X then we can't have Story of Feedback with ID X.

**Application should support the following operations:**

* [x] Create a new person
* [ ] Show all people
* [x] Show person's activity
* [x] Create a new team
* [x] Show all teams
* [x] Show team's activity
* [x] Add person to team
* [x] Show all team members
* [ ] Create a new board in a team
* [x] Show all team boards
* [x] Show board's activity
* [ ] Create a new Bug/Story/Feedback in a board
* [x] Change Priority/Severity/Status of a bug
* [x] Change Priority/Size/Status of a story
* [x] Change Rating/Status of a feedback
* [x] Assign/Unassign work item to a person
* [x] Add comment to a work item
* [ ] List work items with options:
* [ ] List all
* [ ] Filter bugs/stories/feedback only
* [ ] Filter by status and/or assignee
* [ ] Sort by title/priority/severity/size/rating

General Requirements

**Follow the OOP best practices:**

* [ ] Use data encapsulation
* [x] Properly use inheritance and polymorphism
* [x] Properly use interfaces and abstract classes
* [x] Properly use static members
* [x] Properly use enums
* [ ] Follow the principles of strong cohesion and loose coupling
* [x] Use LINQ Extension methods
* [x] Implement proper user input validation and display meaningful user messages
* [x] Implement proper exception handling
* [x] Use Git to keep your source code and for team collaboration

