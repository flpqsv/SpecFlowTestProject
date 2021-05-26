@registration
@api
Feature: RegistrationFeature
	
    Scenario: It is possible to register client using API with POST request
        When I send POST request for registration with valid data
        Then Successful response about created account is provided
        
    Scenario: It is impossible to register client using API with POST request with existing email
        When I send POST request with already existing email
        Then Failed response about created account is provided

    Scenario: It is impossible to register client using API with POST request with no data provided
        When I send POST request with invalid data
        Then Failed response about created account is provided

    Scenario Outline: It is impossible to register client using API with POST request with invalid data provided
        When I send POST request with data
          | first_name   | last_name   | email   | password   | confirm_password   | phone   |
          | <first_name> | <last_name> |         | <password> | <confirm_password> | <phone> |
        Then Failed response about created account is provided
        Examples: 
          | first_name | last_name |  email     | password  | confirm_password | phone        |
          |            | Parker    |            | Mabel123! | Mabel123!        | 123.321.1122 |
          | MaBelle    |           |            | Mabel123! | Mabel123!        | 123.321.1122 |
          | MaBelle    | Parker    |            | random    | random           | 123.321.1122 |
          | MaBelle    | Parker    |            | Mabel123! | random           | 123.321.1122 |
          | MaBelle    | Parker    |            | Mabel123! | Mabel123!        |              |