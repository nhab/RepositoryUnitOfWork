# RepositoryUnitOfWork
An ASP.NET C# web mvc application demonstrates The usage of repository and unit of work patterns in Entity Framework Core.

## The Repository Pattern
we are able to create the data access logic in a separate class, called a Repository, which has the responsibility of persisting the application’s business model.

## The Unit of Work Pattern
The Unit of Work Pattern is a pattern that handles the transactions during data manipulation using the Repository Pattern. Unit of Work is referred to as a single transaction that involves multiple operations.

## Usage
1- Add Your Model to Models (i.e. : NewEntity)
2- Create A DBContext for your model having DBset of your model
3- Add a Constructor for your DBContext in your Generic repositor
4-Add your GenericRepository instance for your Entity in the UnitOfWork.cs
5- Add a controller for the new Entity and Use Your new Enint in your controller. i.e: ( var NewEntities = unitOfWork.NewEntityRepository.Get();)
6-you can optionally add view for the Actions of your conroller to creat a User Interface fro it.
