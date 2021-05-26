@accountSettings
@api
Feature: AccSettingsFeature
    
    Scenario: It is possible to change email using API with POST request
        Given Client is created
        When I send POST request with valid data for email change
        Then Successful response about changed email is provided
        
    Scenario: It is possible to change phone number using API with POST request
        Given Client is created
        When I send POST request with valid data for phone number change
        Then Successful response about changed phone number is provided
    
    Scenario: It is possible to change company information using API with PATCH request
        Given Client is created
        When I send PATCH request with valid data for company information change
        Then Successful response about changed company information is provided
        
    Scenario: It is impossible to change email with wrong password information using API with POST request
        Given Client is created
        When I send POST request with invalid data for email change
        Then Failed response about changed email is provided

