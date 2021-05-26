@registration
@ui

Feature: Registration
In order to get my personal profile in NewBookModels
As a client of NewBookModels
I want to be able to sign up in NewBookModels

    Scenario: It is possible to register in NewBookModels with valid data
        Given Sign up page is opened
        When I register with valid data
          | first_name | last_name | email | password  | confirm_password | phone        |
          | MaBelle    | Parker    |       | Mabel123! | Mabel123!        | 123.321.1122 |
        And I click Submit button
        Then Successfully created account
        
    Scenario: It is impossible to register with the already existing email
        Given Sign up page is opened
        When I register with used email
          | first_name | last_name | email | password  | confirm_password | phone        |
          | MaBelle    | Parker    |       | Mabel123! | Mabel123!        | 123.321.1122 |
        And I click Submit button
        Then Account is not created
        And Error message email already exists is displayed on registration page

    Scenario: It is impossible to register in NewBookModels with no data provided
        Given Sign up page is opened
        When I click Submit button
        Then Account is not created

    Scenario Outline: It is impossible to register in NewMookModels with invalid data provided
        Given Sign up page is opened
        When I register with data
          | first_name   | last_name   | email   | password   | confirm_password   | phone    |
          | <first_name> | <last_name> |         | <password> | <confirm_password> | <phone> |
        And I click Submit button
        Then Account is not created
    Examples: 
      | first_name | last_name |  email     | password  | confirm_password | phone        |
      |            | Parker    |            | Mabel123! | Mabel123!        | 123.321.1122 |
      | MaBelle    |           |            | Mabel123! | Mabel123!        | 123.321.1122 |
      | MaBelle    | Parker    |            | random    | random           | 123.321.1122 |
      | MaBelle    | Parker    |            | Mabel123! | random           | 123.321.1122 |
      | MaBelle    | Parker    |            | Mabel123! | Mabel123!        |              |