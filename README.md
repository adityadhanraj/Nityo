# GetNextBirthdayTests

This repository contains test cases for the `GetNextBirthday` functionality.

## Overview

The `GetNextBirthday` functionality retrieves the next birthday based on the provided date.

## Dependencies

- NUnit
- NUnit3TestAdapter
- Moq
- Nunit test sdk

## Setup

Before running the tests, ensure that the required dependencies are installed.
## Test Cases

### Positive Scenarios

1. **When Valid Date is Provided Should Return NextBirthday**
   - Description: Verifies that the service returns the next birthday when a valid date is provided.
   
2. **When LeapyearDateProvided_Should_Return_NextBirthday_Response_Content**
   - Description: Verifies that the service handles leap year dates correctly.

3. **WhenCurrentDateProvided_Should_Return_NextBirthday_Response_Content**
   - Description: Verifies that the service handles the current date appropriately.

### Negative Scenarios

1. **WhenInvalidDateProvided_Should_Return_NotValidDate_Response**
   - Description: Verifies that the service returns an error message for an invalid date.

2. **WhenInvalidDateFormatProvided_Should_Return_NotValidDate_Response**
   - Description: Verifies that the service returns an error message for an invalid date format.

3. **WhenInvalidDateRangeProvided_Should_Return_NotValidDate_Response**
   - Description: Verifies that the service returns an error message for a date outside the valid range.

4. **WhenNullDateProvided_Should_Return_NotValidDate_Response**
   - Description: Verifies that the service returns an error message for a null date.
  
  
## Running the Tests

To run the tests, execute the test suite using NUnit in Visual Studio.

## Utility 
Added two utility functions
IsStringValidDate - to validate that valid date is passed
GetNextBirthday - to get the next birthday date(to be use in mcoking the service)

