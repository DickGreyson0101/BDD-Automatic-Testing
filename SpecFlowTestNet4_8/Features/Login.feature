Feature: LogIn
As a user, I want to log in to the system so that I can access my dashboard

Scenario Outline: Verify login functionality
  Given I am on the login page
  When I enter "<email>" and "<password>"
  Then the login result should be "<expectedResult>"

  Examples: 
    | email                     | password          | expectedResult |
    | linh.phan@idealogic.com.vn| Welkom01          | true           |
    | linh.phan@idealogic.com.vn| wrongPassword     | false          |
    | invalid_email@example.com | Welkom01          | false          |
    | invalid_email@example.com | wrongPassword     | false          |
    |                           | Welkom01          | false          |
    | linh.phan@idealogic.com.vn|                   | false          |
    |                           |                   | false          |

Scenario: Verify Help link
  Given I am on the login page
  When I click on the "Help" link
  Then the URL should contain "https://bigredcloud.com/support/"
