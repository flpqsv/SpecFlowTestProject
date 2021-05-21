@login @ui
Feature: Login
In order to login in NewBookModels
As a client of NewBookModels
I want to be logged in NewBookModels

    Scenario Outline: It is possible to login in NewBookModels with valid data
        Given Client is created
        And Sign in page is opened
        When I login with data
          | email   | password   |
          | <email> | <password> |
        Then Successfully logged in NewBookModels as created client
        Examples:
          | email  | password |
          | asdasd | asd      |
          | asdasd | asd      |
          | asd    | asd      |
          | 343324 | asd      |
        
    
    Scenario: It is not possible to login in NewBookModels with invalid email
        Given Client is created
        And Sign in page is opened
        When I login with invalid email
          | email   | password   |
          | randomEmail | 123qweQWE! |
        Then Error message wrong email is displayed on Login page
        
    Scenario: It is not possible to login in NewBookModels with invalid password
        Given Client is created
        And Sign in page is opened
        When I login with invalid password
          | email                   | password   |
          | godedo6298@cnxingye.com | randomPass |
        Then Error message wrong password is displayed on Login page
        
  Scenario: It is not possible to login to blocked account in NewBookModels
    Given Sign in page is opened
    When I login with data
      | email                   | password  |
      | godedo6298@cnxingye.com | Mabel123! |
    Then Error message account is blocked is displayed on Login page
        