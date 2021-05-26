@login
@api
Feature: AuthSignInFeature
	Simple calculator for adding two numbers

	Scenario: It is possible to sign in using API with POST request
		Given Client is created
		When I send POST request with valid data
		Then Successful response about authorization is provided

	Scenario: It is not possible to sign in using API with POST request with invalid email
		Given Client is created
		When I send POST request with invalid email
		Then Failed response about authorization is provided

	Scenario: It is not possible to sign in using API with POST request with invalid password
		Given Client is created
		When I send POST request with invalid password
		Then Failed response about authorization is provided

	Scenario: It is not possible to sign in using API with POST request to blocked account in NewBookModels
		When I send POST request with blocked data
		Then Failed response about authorization is provided