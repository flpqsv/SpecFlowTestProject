@accountSettings
@ui
Feature: AccountSettingsFeature

    Scenario: It is possible to change email in account settings
        Given Client is created
        And Client is authorized
        And Account settings page is open
        When I click on edit email button
        And I insert valid password for changing email
        And I insert unique email in email field
        And I click on save button
        Then New email is being saved
        
    Scenario: It is possible to change phone number in account settings
        Given Client is created
        And Client is authorized
        And Account settings page is open
        When I click on edit phone number button
        And I insert valid password for changing phone number
        And I insert new phone number in phone field
        And I click on save button
        Then New phone number is being saved
        
    Scenario: It is possible to log out from account in account settings
        Given Client is created
        And Client is authorized
        And Account settings page is open
        When I click on log out button
        Then Client is not authorized
        
    Scenario: It is possible to change company information in account settings
        Given Client is created
        And Client is authorized
        And Account settings page is open
        When I click on profile tab
        And I click on profile edit button
        And I insert company name
        And I insert conpany website
        And I isert description
        And I click on save button
        Then Company information is being saved