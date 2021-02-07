# Assesment-RamMishra
 ### Step to run
- Set as start-up project to Assessment-RaceTrack
- Run the application.
- Default page will open(Track/Index) page.
- Display S#, Name, Type, Photo in grid along with remove action.
- "Add New Vehicle On Track" link will disable, it will enable after deleting vehicle from track.
- Remove action will remove the vehicle from grid and after refresh page(First time) gid will reflect with updated records.

------------



1. **Assessment-RaceTrack (Front-End)**
 - MVC Architecture
 - Created service class to communicate with repository.
  - Controller communicating with service class.
  - Created DTO in model folder.
  - Controller communicating with service class.
  - Created Unity container (App_Start/UnityConfig) to resolve dependencies.
2. **Assessment-RaceTrack.Core**
 - Created repository classes.
 - Created generic repository classes inside Repository/Common folder.
  - Used UnitOfWork(Partialy).
  
3. **Assessment-RaceTrack.Data**
 - Created dB context classes.
 - Created DB Initializer class for code first db generation.
 
4. **Assessment-RaceTrack.Models**
 - Created shared model classes.
 
5. **Assessment-RaceTrack.Tests**
 - Created test cases of business logics.
 - Implemented Mock for mocking the repositories.
 

------------


**Used Inheritance over Composition**

I have used inheritance because inheritance is more flexible to create instance of classes and also it is loosely coupled that's why easy to resolve the dependencies in project and easily mock the object for unit tests.
