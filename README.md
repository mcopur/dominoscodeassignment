# Dominos Refactoring Code Assignment

What I have encountered as an issue or bad implementation in the legacy implementation:

* The solution could not open properly, there was IIS configuration in the project file.
* VoucherController was missing somehow, it was excluded from the project.
* There were outdated and missing packages.
* Unit tests were not found by Visual Studio because of the missing NUnit Test Adapter.
* There was no dependency injection.
* There were some missing implementations on the controller.
* There were violations of single responsibility on controller and repository.
* There were missing unit tests.

What I did to solve these issues :
* I fixed solution opening issues by changing the project file.
* I included VoucherController to the project again.
* I installed and configure swagger to have self-documented Web API and to have a trying area for developers.
* I chose SimpleInjector as DI Container because it is fast, well-documented, reliable and easy to use.
* VoucherController was messy. I created a separated class for the repository and moved data interaction responsibilities to this class. After that, I injected this repository into the controller. I called repository functions instead of hardcoded controller function. During these changes, I always checked if I broke unit tests and if they were still working properly or not. Because this is a refactoring process, I have kept the same functionality. After these changes, I had a more readable, more maintainable and more testable controller.
* I also thought if I separate my data source as a different object, it would be better. Because it was tightly coupled to the repository. I thought maybe I will need another data source in the future like database, text file, excel file, etc instead of using JSON data source. So, I created IVoucherDataSource and I injected it into the repository. Now, my repository is more generic and more testable.
* I replaced "for loops" with LINQ, this is the modern way, a best practice and more readable.
* I completed not implemented methods in the controller.
* I checked the unit tests and  I added two new unit tests to increase code coverage.
* I upgraded .net framework, NSubstitute, and NUnit test framework versions.

What I could improve in the future:
* After investigating the best approach for caching scenario for this specific scenario in the company, I could implement a caching mechanism to improve performance.
* I could implement more secure Web API by implementing, for instance, token-based authentication. 
* I could implement pagination support for the getting voucher to increase performance.
* I could create a CI&CD Pipe Line for this Web API.
* I could add some validation rules for the web functions.
* I could add some extra unit tests for the worst case scenarios.
