Feature: Employees
# https://github.com/karatelabs/karate/issues/1191
# https://github.com/karatelabs/karate?tab=readme-ov-file#karate-fork

Background:
* header Content-Type = 'application/json'

Scenario: Happy Path

    * def jsUtils = read('./js-utils.js')
    * def authApiRootUrl = jsUtils().getEnvVariable('AUTH_API_ROOT_URL')
    * def apiRootUrl = jsUtils().getEnvVariable('API_ROOT_URL')
    * def authLogin = jsUtils().getEnvVariable('AUTH_LOGIN')
    * def authPassword = jsUtils().getEnvVariable('AUTH_PASSWORD')
    
    # Authentication
    Given url authApiRootUrl
    And path '/auth/login'
    And request
    """
    {
        "login": "#(authLogin)",
        "password": "#(authPassword)"
    }
    """
    And method POST
    Then status 200

    * def accessToken = karate.toMap(response.accessToken.value)

    * configure headers = jsUtils().getAuthHeaders(accessToken)

    # Get employees list
    Given url apiRootUrl
    Given path '/employees/all'
    When method GET
    Then status 200
    And assert response.length > 0
    And match response[0].fullName == '#string'
    And match response[0].corporateEmail == '#string'
    And match response[0].phone == '#string'

    * def employeeId = response[0].employeeId

    # Get employee by employeeId
    Given url apiRootUrl
    Given path '/employees', employeeId
    When method GET
    Then status 200
    And match response.fullName == '#string'
    And match response.corporateEmail == '#string'
    And match response.phone == '#string'
