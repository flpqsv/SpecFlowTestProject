@registration @ui
Feature: Registration
In order to get my personal profile in NewBookModels
As a client of NewBookModels
I want to be able to sign up in NewBookModels

Scenario: It is possible to registrate in NewBookModels with valid data
	Given Sign up page is opened
	When I registrate with valid data
		|  first_name |  last_name |  	email 	|  password  |  confirm_password |     number    |
		|  MaBelle    |	  Parker   |     	 	|  Mabel123! |      Mabel123!    |  123.321.1122 |
	And I click Submit button
	Then Successfully created account
	
Scenario: It is impossible to registrate in NewBookModels with no data provided
	Given Sign up page is opened
	When I click Submit button
	Then Account is not created
	
Scenario: It is impossible to registrate in NewMookModels with invalid data provided
	Given Sign up page is opened                                                                 
	When I registrate with data                                                                  
	  |  first_name  |  last_name  |  uniqEmail  |  password  |  confirm_password  |  number  |
	  | <first_name> | <last_name> | <uniqEmail> | <password> | <confirm_password> | <number> |
	And I click Submit button
	Then Account is not created
	Examples:
	  |  first_name  |  last_name  |  uniqEmail  |  password  |  confirm_password  |     number    |
	  | 			 | 	Parker     |  uniqEmail  |  Mabel123! |      Mabel123!     |  123.321.1122 |
	  |  MaBelle     |	 		   |  uniqEmail  |  Mabel123! |      Mabel123!     |  123.321.1122 |
	  |  MaBelle     | 	Parker     | 			 |  Mabel123! |      Mabel123!     |  123.321.1122 |
	  |  MaBelle     | 	Parker     |  uniqEmail  |  		  |      Mabel123!     |  123.321.1122 |  
	  |  MaBelle     | 	Parker     |  uniqEmail  |  Mabel123! |  				   |  123.321.1122 |  
	  |  MaBelle     | 	Parker     |  uniqEmail  |  Mabel123! |      Mabel123!     | 		 	   |  
	  
	  
	  