# InternetSecurities
 Task: 
Create a Web Service that communicates with a database of your choice.

Create a separate web-based application, that talks with the service allowing to browse, create, and
delete records.

Provide documentation, and explain the solution. Publish the code in GitHub and send us an URL to it.

*The domain of the task will be a sample news website. The database will be a SQL one.*

## The model
The model of a story/article is simple, but it can be expanded easily and new functionalities to be added. It has the following properties:
- int Id
- string Title
- string Body


## InternetSecurityAPI 

This is the soluwtion where the API is located. It provides functionality to create, edit and delete stories. It implements the following methods:
- GetNews - retrieves all the news in the database.
- GetStory(int id) - retrieves a particular story based on the id.
- CreateStory(News story) - adds a new story to the database.
- UpdateStory(int id, News story) - edits an already existing story in the database.
- DeleteStory(int id) - deletes a story from the database.

All actions concerning the database are going through a NewService so the API controller itself doesn't handle any database operations.

## InternetSecurity

This is the solution of the web application that uses the InternetSecurityAPI to browse, create and delete stories. The interface is straightforward. There are buttons for adding, deleting and editing a story.

When testing please ensure to change the url of the API at /Services/NewsService - apiUrl, as well as in /Views/Home/Index where the ajax call for the delete method is executed.

Please let me know if you would like any functionalities extensions to be implemented.
