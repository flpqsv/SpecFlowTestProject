@DB
Feature: DatabaseFeature

Scenario: Insert data in Products table
	When I add data with insert command
	  | id |  name   | quantity |
	  | 1  | Product |     32   |
	Then The data is added to Products table
	
Scenario: Select data from Products table
	Given Data is added with insert command
	When I select data with name <name> with select command
	Then The selected data exists

Scenario: Delete data from Products table
	When I select data with id <id> with delete command
	Then The data is deleted from Products table
	
Scenario: Update data in Products table
	Given Data is added with insert command
	When I change item name to <new_name> with update command
	Then Data is changed in Products table
	
Scenario: Create new table in Shop database
	When I add new table with create command
	Then Table is created
	
Scenario: Delete table in Shop database
	When I delete existing table in Shop database
	Then Table is successfully deleted